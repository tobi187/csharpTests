namespace KniffelServer.Models
{
    public class GameManager : IGameManager
    {
        private int _numOfRooms;
        private int _countInRoom;

        public GameManager()
        {
            _numOfRooms = 0;
            _countInRoom = 0;
        }
        public int NumOfRooms { get => _numOfRooms; set => _numOfRooms = value; }
        public int CountInRoom { get => _countInRoom; set => _countInRoom = value; }
    }
}
