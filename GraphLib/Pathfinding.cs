using System;
using System.Collections.Generic;
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

                for (int i = 0;i < neighbours.Count;++i) {
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

                for (int i = 0;i < neighbours.Count;++i) {
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

            for (int i = 0;i < graph.Count;++i)
                cameFrom[i] = UNVISITED;


            // COMPLÉTEZ

            return path;
        }

        public static List<int> TraversalDFS(IGraph graph, int start) {
            // COMPLÉTEZ

            return null!; //À changer
        }

        public static List<int> GetPathDFS(IGraph graph, int start, int end) {
            // COMPLÉTEZ

            return null!; //À changer
        }

        public static bool PathExistsDFS(IGraph graph, int start, int end) {
            // COMPLÉTEZ

            return false!; //À changer
        }

        public static List<int> GetPathDijkstra(IGraph graph, int start, int end) {
            // COMPLÉTEZ

            return null!; //À changer
        }
    }
}
