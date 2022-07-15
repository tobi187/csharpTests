using Microsoft.AspNetCore.SignalR;

namespace KniffelServer.Hubs
{
    public class GameHub : Hub
    {
        private readonly string groupNumber;

        public GameHub(string groupNumber)
        {
            this.groupNumber = groupNumber;
        }
    }
}
