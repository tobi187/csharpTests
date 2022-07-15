using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetocode.AdOfCode
{
    internal class Y2016D13
    {
        public readonly int favNumber = 10;
        public Dictionary<Node, List<Node>> GenerateAdjacencyList()
        {
            List<Node> nodes = new();
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    nodes.Add(new Node(j, i));
                }
            }
            Dictionary<Node, List<Node>> adjacencyList = new();
            foreach (var n in nodes)
            {
                var neighbours = n.FindNeighbours(nodes);
                adjacencyList.Add(n, neighbours);
            }
            return adjacencyList;
        }
    }

    class BFS
    {
        public List<Node> visited = new();
        public Dictionary<Node, List<Node>> adjacenyList;
        public Queue<Node> deque = new();
        public (int x, int y) start = (x: 1, y: 1);
        public (int x, int y) end = (x: 7, y: 4);
        public Dictionary<Node, int> pathLengths = new();
        public Dictionary<Node, Node> previous = new();
        public Node currentNode;

        public BFS(Dictionary<Node, List<Node>> adj)
        {
            adjacenyList = adj;
            currentNode = adj.Single(x => x.Key.coordinates == start).Key;
            deque.Enqueue(currentNode);
            visited.Add(currentNode);
            foreach (var n in adj.Keys) pathLengths.Add(n, int.MaxValue);
            pathLengths[currentNode] = 0;
        }

        public string DoBfsMagic()
        {
            while (deque.Count > 0)
            {
                currentNode = deque.Dequeue();
                UpdateQueues();
            }

            var path = new List<Node>() { currentNode };

            var cN = currentNode;

            while (path.Last().coordinates != start)
            {
                cN = previous[cN];
                path.Add(cN);
            }

            path.Reverse();

            return $"Way took {path.Count}. Way => {string.Join(" -> ", path.Select(x => x.ToString()))}";

        }

        public void UpdateQueues()
        {
            foreach (var node in adjacenyList[currentNode])
            {
                if (!visited.Contains(node) && node.isFree)
                {
                    visited.Add(node);
                    deque.Enqueue(node);
                    pathLengths[node] += 1;
                    previous[node] = currentNode;
                }
            }
        }

    }

    class Node
    {
        public (int x, int y) coordinates;
        public int x;
        public int y;
        public bool isFree;

        public Node(int xC, int yC)
        {
            x = xC;
            y = yC;
            coordinates = (xC, yC);
            calcWall();
        }

        public void calcWall()
        {
            var calc = x * x + 3 * x + 2 * x * y + y + y * y;
            isFree = Convert.ToString(calc + 1364, 2).Where(x => x == '1').Count() % 2 == 0;
        }

        public List<Node> FindNeighbours(List<Node> allNodes)
        {
            var neighbours = new List<Node>();
            foreach (var node in allNodes)
            {
                if (node.coordinates == (x - 1, y) || node.coordinates == (x + 1, y))
                    neighbours.Add(node);
                if (node.coordinates == (x, y - 1) || node.coordinates == (x, y + 1))
                    neighbours.Add(node);
            }
            return neighbours;
        }

        public override string ToString()
        {
            return $"{x}, {y}\n";
        }
    }


}
