using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetocode
{
    internal class MAMN
    {
        public void workFlow()
        {
            // player - pos
            var players = new List<int>()
            {
                0,0,0,0
            };

            while (players.TrueForAll(x => x < 20))
            {
                players = OneTurn(players);
            }

            var winnerNr = players.IndexOf(players.Max()) + 1;

            Console.WriteLine("______________________________________________");
            Console.WriteLine("Player " + winnerNr + " won. Happy Glückwunsch");
            Console.WriteLine("______________________________________________");
            Console.WriteLine();
            showState(players);
        }

        public List<int> OneTurn(List<int> players)
        {
            var random = new Random();

            for (var i = 0; i < players.Count; i++)
            {
                var newPos = players[i] + random.Next(1, 7);

                showState(players);

                Console.WriteLine($"Player {i + 1} rennt auf Pos {newPos}");

                for (var j = 0; j < players.Count; j++)
                {
                    if (players[j] == newPos)
                    {
                        players[j] = 0;
                        Console.WriteLine($"Player {i + 1} klatscht Player {j + 1} raus");
                    }
                }
                players[i] = newPos;

                if (newPos > 19)
                    return players;
            }
            return players;
        }


        public void showState(List<int> pos)
        {
            Thread.Sleep(1000);
            Console.WriteLine("Spielstand:");
            for (var i = 0; i < pos.Count; i++)
            {
                Console.WriteLine($"Spieler {i + 1}: {pos[i]}");
            }
            Console.WriteLine();
        }
    }
}
