using Microsoft.AspNetCore.SignalR;

namespace KniffelServer.Hubs
{
    public class GameHub : Hub
    {
        public GameHub()
        {
        }

        public async Task OnStart(string groupNumber, string playerID2)
        {
            await Groups.AddToGroupAsync(playerID2, groupNumber);
            await Groups.AddToGroupAsync(Context.ConnectionId, groupNumber);
            await Clients.Caller.SendAsync("StartGameFirst", true);
            await Clients.OthersInGroup(groupNumber).SendAsync("StartGameFirst", false);
        }

        public async Task OnThrow(string groupNr)
        {

        }

        public async Task OnChange(string groupNr, string res)
        {
            await Clients.Group(groupNr).SendAsync("PlayerChange", res);
        }
    }
}
