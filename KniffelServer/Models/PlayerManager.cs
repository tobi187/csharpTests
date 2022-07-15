namespace KniffelServer.Models
{
    public class PlayerManager : IPlayerManager
    {
        private Dictionary<Player, int> _playersRooms;
        public PlayerManager()
        {
            _playersRooms = new Dictionary<Player, int>();
        }
        public Dictionary<Player, int> PlayersRooms { get { return _playersRooms; } set { _playersRooms = value; } }
    }
}
