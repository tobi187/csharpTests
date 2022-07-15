﻿using KniffelServer.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace KniffelServer.Hubs
{
    public class WaitingRoomHub : Hub
    {
        public static ConcurrentDictionary<string, GameRoom> gameRooms = new();


        public async Task<string> CreateRoom()
        {
            var roomNr = new Guid().ToString();
            await Groups.AddToGroupAsync(Context.ConnectionId, roomNr);
            gameRooms.TryAdd(roomNr, new GameRoom { GroupName = roomNr, Player1 = Context.ConnectionId });
            await Clients.All.SendAsync("UpdateGameRooms", new
            {
                groupList = gameRooms.Where(x => !x.Value.IsRoomFull).Select(x => x.Key).ToList()
            });
            return roomNr;
        }

        public async Task<List<string>> GetRooms()
        {
            var rooms = gameRooms.Where(x => !x.Value.IsRoomFull);
            return rooms.Select(x => x.Key).ToList();
        }

        public async Task<bool> JoinRoom(string roomNr)
        {
            var doesRoomExits = gameRooms.TryGetValue(roomNr, out var room);
            if (doesRoomExits && !room.IsRoomFull)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, roomNr);
                room.IsRoomFull = true;
                await Clients.All.SendAsync("UpdateGameRooms", new
                {
                    groupList = gameRooms.Where(x => !x.Value.IsRoomFull).Select(x => x.Key).ToList()
                });

                await Clients.Group(room.GroupName).SendAsync("GameFound", new
                {
                    roomNr = roomNr
                });
                return true;
            }
            return false;
        }

        public Task LeaveRoom(string roomName)
        {
            gameRooms.TryRemove(roomName, out var room);
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }
    }
}
