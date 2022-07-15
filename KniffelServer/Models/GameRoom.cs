namespace KniffelServer.Models
{
    public class GameRoom
    {
        public string GroupName { get; set; }
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public bool IsRoomFull { get; set; }
    }
}
