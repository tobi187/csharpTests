using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetocode
{
    internal class MADNOOP
    {
        public List<Player> PlayerList { get; set; }
        public int Turn { get; private set; }
        public Player? Winner { get; set; }
        internal MADNOOP()
        {
            initGame();
        }

        internal void Play()
        {
            while (Winner == null)
            {
                PlayerList.ForEach(x => x.Move());
                LogState();
                Turn++;
            }
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"{Winner.Name} won after {Turn} Turns");
            Console.WriteLine("-----------------------------------------");
        }

        internal void LogState()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            PlayerList.ForEach(x => x.LogPosition());
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        internal void initGame()
        {
            Turn = 0;
            PlayerList =
                Enumerable.Range(0, 4)
                .Select(x => new Player($"Player {x + 1}", this, end: 100))
                .ToList();
        }
    }

    internal class Player
    {
        public string Name { get; }
        public int Position { get; set; } = 0;
        public int Finish { get; }
        public MADNOOP GameState { get; set; }

        private Random Random = new Random();

        internal Player(string name, MADNOOP game, int end = 20)
        {
            Name = name;
            GameState = game;
            Finish = end;
        }

        public void Move()
        {
            var nextPosition = WhipOutNumber() + Position;

            if (!CanMove(nextPosition)) return;

            Console.WriteLine($"{Name} moves to Position {nextPosition}");

            KickPlayers(nextPosition);

            Position = nextPosition;
        }

        private int WhipOutNumber()
        {
            if (Position == 0)
            {
                var trys =
                    new int[3].Select(_ => Random.Next(1, 7));
                if (!trys.Any(x => x == 6))
                    return 0;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Name} got out");
                Console.ForegroundColor = ConsoleColor.White;
            }

            return CheckForSix();
        }

        private int CheckForSix()
        {
            var num = Random.Next(1, 7);
            var sum = num;

            while (num == 6)
            {
                num = Random.Next(1, 7);
                if (Position + num + sum >= Finish)
                    return sum;
                sum += num;
            }

            return sum;
        }

        private bool CanMove(int nextPosition)
        {
            if (GameState.Winner != null)
                return false;

            if (nextPosition > Finish || nextPosition == 0)
                return false;

            if (nextPosition == Finish)
            {
                MeWon();
                return false;
            }

            return true;
        }

        private void KickPlayers(int nextPos)
        {
            foreach (var p in GameState.PlayerList)
            {
                if (nextPos == p.Position)
                {
                    p.GoToZero();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{Name} kicked {p.Name} out");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        private void MeWon()
        {
            GameState.Winner = this;
        }

        public void GoToZero()
        {
            Position = 0;
        }

        public void LogPosition()
        {
            Console.WriteLine($"{Name}: {Position}");
        }
    }
}
