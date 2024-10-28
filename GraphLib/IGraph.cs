using System.Collections.Generic;

namespace GraphLib {
    public interface IGraph {
        public int Count { get; }
        public int this[int a, int b] { get; set; }
        public void AddEdge(int a, int b, int cost);
        public void RemoveEdge(int a, int b);
        public List<int> GetNeighbours(int a);
    }
}
