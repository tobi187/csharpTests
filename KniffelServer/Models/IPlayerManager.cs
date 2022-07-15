namespace KniffelServer.Models
{
    public interface IPlayerManager
    {
        Dictionary<Player, int> PlayersRooms { get; set; }
    }
}
