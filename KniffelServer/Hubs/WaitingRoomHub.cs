using KniffelServer.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace KniffelServer.Hubs
{
    public class WaitingRoomHub : Hub
    {
        public static ConcurrentDictionary<string, GameRoom> gameRooms = new();

        public async Task<string> CreateRoom(string name)
        {
            if (gameRooms.Values.Any(x => x.RoomName == name))
                return "Name already in Use";
            var roomNr = Guid.NewGuid().ToString();
            await Groups.AddToGroupAsync(Context.ConnectionId, roomNr);
            gameRooms.TryAdd(roomNr, new GameRoom { RoomName = name, GroupName = roomNr, Player1 = Context.ConnectionId });
            await Clients.All.SendAsync("UpdateGameRooms", new
            {
                groupList = gameRooms.Where(x => !x.Value.IsRoomFull).Select(x => x.Value.RoomName).ToList()
            });
            return roomNr;
        }

        public async Task GetRooms()
        {
            await Clients.Caller.SendAsync("UpdateGameRooms", new
            {
                groupList = gameRooms.Where(x => !x.Value.IsRoomFull).Select(x => x.Value.RoomName).ToList()
            });
        }

        public async Task<bool> JoinRoom(string roomName)
        {
            var room = gameRooms.SingleOrDefault(x => x.Value.RoomName == roomName).Value;
            if (room != null && !room.IsRoomFull)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, room.GroupName);
                room.IsRoomFull = true;
                room.Player2 = Context.ConnectionId;
                await Clients.All.SendAsync("UpdateGameRooms", new
                {
                    groupList = gameRooms.Where(x => !x.Value.IsRoomFull).Select(x => x.Value.RoomName).ToList()
                });

                await Clients.Group(room.GroupName).SendAsync("GameFound", room.GroupName, room.Player2);
                return true;
            }
            return false;
        }

        public async Task LeaveRoom(string roomName)
        {
            if (!gameRooms.TryRemove(roomName, out var room))
                return;
            await Clients.OthersInGroup(roomName).SendAsync("PlayerLeft");
            await Groups.RemoveFromGroupAsync(room.Player1, roomName);
            await Groups.RemoveFromGroupAsync(room.Player2, roomName);
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
