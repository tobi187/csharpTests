using KniffelServer.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace KniffelServer.Hubs
{
    public class WaitingRoomHub : Hub
    {
        public static ConcurrentDictionary<string, GameRoom> gameRooms = new();

        public async Task<string> CreateRoom()
        {
            var roomNr = Guid.NewGuid().ToString();
            await Groups.AddToGroupAsync(Context.ConnectionId, roomNr);
            gameRooms.TryAdd(roomNr, new GameRoom { GroupName = roomNr, Player1 = Context.ConnectionId });
            await Clients.All.SendAsync("UpdateGameRooms", new
            {
                groupList = gameRooms.Where(x => !x.Value.IsRoomFull).Select(x => x.Key).ToList()
            });
            return roomNr;
        }

        public async Task GetRooms()
        {
            await Clients.Caller.SendAsync("UpdateGameRooms", new
            {
                groupList = gameRooms.Where(x => !x.Value.IsRoomFull).Select(x => x.Key).ToList()
            });
        }

        public async Task<bool> JoinRoom(string roomNr)
        {
            var doesRoomExits = gameRooms.TryGetValue(roomNr, out var room);
            if (doesRoomExits && !room.IsRoomFull)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, roomNr);
                room.IsRoomFull = true;
                room.Player2 = Context.ConnectionId;
                await Clients.All.SendAsync("UpdateGameRooms", new
                {
                    groupList = gameRooms.Where(x => !x.Value.IsRoomFull).Select(x => x.Key).ToList()
                });

                await Clients.Group(room.GroupName).SendAsync("GameFound", room.GroupName, room.Player2);
                return true;
            }
            return false;
        }

        public Task LeaveRoom(string roomName)
        {
            gameRooms.TryRemove(roomName, out var room);
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }

        public async Task OnStart(string groupNumber)
        {
            await Clients.Caller.SendAsync("StartGameFirst", true);
            await Clients.OthersInGroup(groupNumber).SendAsync("StartGameFirst", false);
        }

        public async Task OnThrow(string groupNr)
        {

        }

        public async Task OnChange(string groupNr, string res, string sonder, string nums)
        {
            await Clients.Group(groupNr).SendAsync("PlayerChange", res, sonder, nums);
        }
    }
}
