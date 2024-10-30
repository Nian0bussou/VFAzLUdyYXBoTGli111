using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GraphLib {
    public static class Pathfinding {
        public static List<int> TraversalBFS(IGraph graph, int start) {
            var frontier = new Queue<int>();
            var reached = new List<int>();

            frontier.Enqueue(start);
            reached.Add(start);

            while (frontier.Count > 0) {
                int currentNode = frontier.Dequeue();

                var neighbours = graph.GetNeighbours(currentNode);

                for (int i = 0; i < neighbours.Count; ++i) {
                    int next = neighbours[i];
                    if (!reached.Contains(next)) {
                        frontier.Enqueue(next);
                        reached.Add(next);
                    }
                }
            }

            return reached;
        }

        public static bool PathExistsBFS(IGraph graph, int start, int end) {
            bool pathExists = false;

            var frontier = new Queue<int>();
            var reached = new List<int>();

            frontier.Enqueue(start);
            reached.Add(start);

            while (frontier.Count > 0) {
                int currentNode = frontier.Dequeue();

                if (currentNode == end) {
                    pathExists = true;
                    break;
                }

                var neighbours = graph.GetNeighbours(currentNode);

                for (int i = 0; i < neighbours.Count; ++i) {
                    int next = neighbours[i];
                    if (!reached.Contains(next)) {
                        frontier.Enqueue(next);
                        reached.Add(next);
                    }
                }
            }

            return pathExists;
        }

        public static List<int> GetPathBFS(IGraph graph, int start, int end) {
            const int UNVISITED = -1;

            var path = new List<int>();
            var frontier = new Queue<int>();
            var cameFrom = new int[graph.Count];

            for (int i = 0; i < graph.Count; ++i)
                cameFrom[i] = UNVISITED;

            frontier.Enqueue(start);
            cameFrom[start] = start;

            while (frontier.Count > 0) {
                var current = frontier.Dequeue();

                // If reach end -> reconstruct the path
                if (current == end) {
                    int node = end;
                    while (node != start) {
                        path.Add(node);
                        node = cameFrom[node];
                    }
                    path.Add(start);
                    path.Reverse(); // Reverse: start -> end (was: end -> start)
                    return path;
                }

                foreach (var neighbor in graph.GetNeighbours(current)) {
                    if (cameFrom[neighbor] == UNVISITED) {
                        frontier.Enqueue(neighbor);
                        cameFrom[neighbor] = current; // where we came from
                    }
                }
            }

            return path;
        }

        public static List<int> TraversalDFS(IGraph graph, int start) {
            var frontier = new Stack<int>();
            var reached = new List<int>();

            frontier.Push(start);

            while (frontier.Count > 0) {
                int currentNode = frontier.Pop();

                var neighbours = graph.GetNeighbours(currentNode);

                for (int i = 0; i < neighbours.Count; ++i) {
                    int next = neighbours[i];
                    if (!reached.Contains(next)) {
                        frontier.Push(next);
                    }
                }
                reached.Add(currentNode);
            }

            return reached;
        }

        public static List<int> GetPathDFS(IGraph graph, int start, int end) {
            const int UNVISITED = -1;

            var path = new List<int>();
            var frontier = new Stack<int>();
            var cameFrom = new int[graph.Count];

            for (int i = 0; i < graph.Count; ++i)
                cameFrom[i] = UNVISITED;


            frontier.Push(start);
            cameFrom[start] = start;

            while (frontier.Count > 0) {
                var current = frontier.Pop();

                // If reach end -> reconstruct the path
                if (current == end) {
                    int node = end;
                    while (node != start) {
                        path.Add(node);
                        node = cameFrom[node];
                    }
                    path.Add(start);
                    path.Reverse(); // Reverse: start -> end (was: end -> start)
                    return path;
                }

                foreach (var neighbor in graph.GetNeighbours(current)) {
                    if (cameFrom[neighbor] == UNVISITED) {
                        frontier.Push(neighbor);
                        cameFrom[neighbor] = current; // where we came from
                    }
                }
            }

            return path;
        }

        public static bool PathExistsDFS(IGraph graph, int start, int end) {
            bool pathExists = false;

            var frontier = new Stack<int>();
            var reached = new List<int>();

            frontier.Push(start);
            reached.Add(start);

            while (frontier.Count > 0) {
                int currentNode = frontier.Pop();

                if (currentNode == end) {
                    pathExists = true;
                    break;
                }

                var neighbours = graph.GetNeighbours(currentNode);

                for (int i = 0; i < neighbours.Count; ++i) {
                    int next = neighbours[i];
                    if (!reached.Contains(next)) {
                        frontier.Push(next);
                        reached.Add(next);
                    }
                }
            }

            return pathExists;
        }

        public static List<int> GetPathDijkstra(IGraph graph, int start, int end) {

            var pq = new PriorityQueue<int>();

            var dists = new int[graph.Count];
            for (int i = 0; i < dists.Length; i++) dists[i] = int.MaxValue;

            var previous = new int[graph.Count];
            for (int i = 0; i < previous.Length; i++) previous[i] = -1;

            dists[start] = 0;

            pq.Enqueue(start, 0);

            while (pq.Count > 0) {
                // Get the node with the smallest distance (priority)
                int current = pq.Dequeue();

                // reached the end node, stop the search
                if (current == end) break;

                var neighbors = graph.GetNeighbours(current);

                foreach (var neighbor in neighbors) {
                    // calculate new distance to neighbor
                    int newDist = dists[current] + graph[current, neighbor];

                    // If a shorter path to the neighbor is found
                    if (newDist < dists[neighbor]) {
                        dists[neighbor] = newDist;   // Update distance
                        previous[neighbor] = current;    // Update previous node
                        pq.Enqueue(neighbor, newDist);   // Enqueue the neighbor with new priority
                    }
                }
            }
            if (dists[end] == int.MaxValue) return new List<int>();

            // Build the shortest path by backtracking from the end node
            var path = new List<int>();
            for (int at = end; at != -1; at = previous[at]) {
                path.Add(at);
            }

            // The path is constructed in reverse order, so reverse it before returning
            path.Reverse();
            return path;
        }

        public static List<int> GetPathAStar(IGraph graph, int start, int end, Func<int, int, float> Heuristic) {

            var pq = new PriorityQueue<int>();

            var dists = new int[graph.Count];
            for (int i = 0; i < dists.Length; i++) dists[i] = int.MaxValue;

            var previous = new int[graph.Count];
            for (int i = 0; i < previous.Length; i++) previous[i] = -1;

            dists[start] = 0;

            pq.Enqueue(start, 0);

            while (pq.Count > 0) {
                int current = pq.Dequeue();
                if (current == end) break;

                var neighbors = graph.GetNeighbours(current);

                foreach (var neighbor in neighbors) {
                    // calculate new distance to neighbor
                    int newDist = dists[current] + graph[current, neighbor];

                    if (newDist < dists[neighbor]) {
                        dists[neighbor] = newDist;
                        previous[neighbor] = current;

                        int priority = newDist + (int)MathF.Round(Heuristic(neighbor, end));

                        pq.Enqueue(neighbor, priority);       // Enqueue with priority f(n)
                    }
                }
            }
            if (dists[end] == int.MaxValue) return new List<int>();

            // Build the shortest path by backtracking from the end node
            var path = new List<int>();
            for (int at = end; at != -1; at = previous[at]) {
                path.Add(at);
            }

            // The path is constructed in reverse order, so reverse it before returning
            path.Reverse();
            return path;
        }
    }
}
