using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetocode.EntwicklerHeld.Fluggesellschaft
{
    public class FlightService
    {
        private IEnumerable<Flight> availableFlights;

        public static FlightService Of(IEnumerable<Flight> availableFlights)
        {
            return new FlightService(availableFlights);
        }

        private FlightService(IEnumerable<Flight> availableFlights)
        {
            this.availableFlights = availableFlights;
        }

        public IEnumerable<Flight> GetFullFlights()
        {
            // Implement this
            // You can also add more methods or functions
            // Try to write clean code.

            return availableFlights
                .ToList()
                .Where(x => x.AvailableSeats < 1);

            //throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetFlightsForDestination(Airport destination)
        {
            // Implement this
            return availableFlights.
                Where(flight => flight.Destination == destination);
            //throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetFlightsForOrigin(Airport origin)
        {
            // Implement this
            return availableFlights.
                Where(flight => flight.Origin == origin)
                .ToList();
            //throw new NotImplementedException();
        }

        public List<Flight> GetShortestFlightByRoute(Airport origin, Airport destination)
        {
            /*
            var fF = new FastFlights(availableFlights.ToList());
            var pFlights = GetFlightsForOrigin(origin)
                        .Where(x => x.AvailableSeats > 0)
                        .Select(x => 
                        new FlightPlan(origin, destination, new List<Flight>() {x}, fF));

            fF.pFlights = pFlights.ToList();

            var result = fF.GetShortest();
            
            if (!result.Any())
                return new List<Flight>();
            return result.First().route;
            */
            var d = new Dijkstra(availableFlights.ToList(), origin, destination);
            return d.DoDijsktraMagic();
        }
    }

    // after googling algorythm
    public class Dijkstra
    {
        // how to implement visited
        public Flight currentNode;
        public Dictionary<Flight, TimeSpan> priorityQueue = new Dictionary<Flight, TimeSpan>();
        public Dictionary<Flight, Flight> prevNodes = new Dictionary<Flight, Flight>();
        public Dictionary<Flight, TimeSpan> totalCost = new Dictionary<Flight, TimeSpan>();
        public HashSet<Flight> visitedNodes = new HashSet<Flight>();
        public List<Flight> allFlight;
        public Airport start;
        public Airport goal;

        public Dijkstra(List<Flight> aV, Airport s, Airport g)
        {
            start = s;
            goal = g;
            allFlight = aV;
            foreach (var f in aV.Where(x => x.Origin == s))
                priorityQueue.Add(f, f.Duration);
            currentNode = priorityQueue.OrderBy(x => x.Value).First().Key;
            foreach (var f in aV)
            {
                if (f.Origin == s)
                    totalCost.Add(f, f.Duration);
                else
                    totalCost.Add(f, TimeSpan.MaxValue);
            }
        }

        public List<Flight> DoDijsktraMagic()
        {
            while (priorityQueue.Count != 0 && currentNode.Destination != goal)
            {
                currentNode = priorityQueue.OrderBy(x => x.Value).First().Key;
                priorityQueue.Remove(currentNode);
                UpdateQueues();
            }

            List<Flight> path = new List<Flight>();
            var cN = currentNode;

            if (cN.Destination != goal)
                return path;
            path.Add(cN);

            while (cN.Origin != start)
            {
                cN = prevNodes.Single(x => x.Key.Equals(cN)).Value;
                path.Add(cN);
            }

            path.Reverse();

            return path;
        }

        public void UpdateQueues()
        {
            var cWeight = totalCost[currentNode];

            foreach (var node in GetFlights())
            {
                if (visitedNodes.Any(x => x.Equals(node)))
                    continue;

                var newWeight = cWeight + node.Duration;

                if (newWeight < totalCost[node])
                {
                    totalCost[node] = newWeight;
                    prevNodes[node] = currentNode;
                }
                Enqueue(node, newWeight);
            }
            visitedNodes.Add(currentNode);
        }

        public void Enqueue(Flight node, TimeSpan val)
        {
            if (!priorityQueue.ContainsKey(node))
                priorityQueue.Add(node, val);
            if (val < priorityQueue[node])
                priorityQueue[node] = val;
        }

        public List<Flight> GetFlights()
        {
            return allFlight
                .Where(x => x.Origin == currentNode.Destination)
                .ToList();
        }
    }


    class PriorityQueue<TKey, TValue>
    {
        public Dictionary<TKey, TValue> queue = new Dictionary<TKey, TValue>();

        public void Enqueue(TKey flight, TValue prio)
        {
            //if (IsIn(flight))
            //    queue[flight] = prio;
            //else
            queue.Add(flight, prio);
        }

        public TValue Dequeue()
        {
            var prio = queue.OrderBy(x => x.Value).First();
            queue.Remove(prio.Key);
            return prio.Value;
        }

        public bool IsIn(TKey item)
        {
            if (queue.Any(x => x.Key.Equals(item)))
                return true;
            else
                return false;
        }

        public bool IsEmpty()
        {
            return queue.Count == 0;
        }
    }


    //test without google algorythms 
    public class FlightPlan
    {
        public List<Flight> route { get; set; }
        public Airport aOrigin { get; }
        public Airport aDestination { get; }
        public bool isAtDestination { get; set; }
        public FastFlights AllFlights { get; set; }
        public FlightPlan(Airport o, Airport d, List<Flight> startFlight, FastFlights a)
        {
            aOrigin = o;
            aDestination = d;
            isAtDestination = false;
            route = startFlight;
            AllFlights = a;
        }
        public string TString()
        {
            return string.Join(", ", route.Select(x => x.Destination));
        }

        public TimeSpan GetCurrentTime()
        {
            return route.Select(x => x.Duration).Aggregate((a, b) => a + b);
        }
        public Airport CurrentAirport()
        {
            return route.Last().Destination;
        }

        public void OneIteration(List<Flight> cFlights)
        {
            var cTime = GetCurrentTime();
            if (cFlights.Count == 0 || isAtDestination) return;

            foreach (var f in cFlights)
            {
                if (f.AvailableSeats < 1)
                    continue;
                if (cTime + f.Duration > AllFlights.shortestTime)
                    continue;
                var newRoute = route.ToList();
                newRoute.Add(f);
                AllFlights.pFlights.Add(new FlightPlan(aOrigin, aDestination, newRoute, AllFlights));
            }

            AllFlights.pFlights.Remove(this);
        }
        public void CheckMe()
        {
            if (CurrentAirport() == aDestination)
            {
                isAtDestination = true;
                if (GetCurrentTime() <= AllFlights.shortestTime)
                    AllFlights.shortestTime = GetCurrentTime();
                else
                    AllFlights.pFlights.Remove(this);
                return;
            }
            if (GetCurrentTime() > AllFlights.shortestTime)
            {
                AllFlights.pFlights.Remove(this);
            }
        }
    }

    public class FastFlights
    {
        public TimeSpan shortestTime { get; set; }
        public List<FlightPlan> pFlights { get; set; }
        public List<Flight> avFlights { get; set; }
        public int iteration { get; set; }

        public FastFlights(List<Flight> aV)
        {
            shortestTime = TimeSpan.FromHours(24);
            iteration = 1;
            avFlights = aV;
        }

        public List<FlightPlan> GetShortest()
        {
            var cList = pFlights.ToList();

            while (pFlights.Count > 1)
            {
                foreach (var item in cList)
                {
                    item.OneIteration(possFlights(item.CurrentAirport()));
                }
                cList = pFlights.ToList();
                foreach (var item in cList)
                {
                    item.CheckMe();
                }
                cList = pFlights.ToList();
                // warum wird shortest time nicht gelogt mit 24 h ??????? 
                Console.WriteLine(shortestTime);
            }
            //pFlights.ForEach(x => Console.WriteLine(x.TString()));
            var output = pFlights.Where(x => x.isAtDestination).ToList();
            Console.WriteLine(pFlights[0].aOrigin.Name + " - " + pFlights[0].aDestination.Name);
            Console.WriteLine(pFlights.Count);
            Console.WriteLine(pFlights[0].isAtDestination);
            return output;
        }

        public List<Flight> possFlights(Airport o)
        {
            return avFlights.Where(x => x.Origin == o).ToList();
        }
    }
}
