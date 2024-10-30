using System;
using System.Collections.Generic;
using GraphLib;

public class AdjacencyList : IGraph {
    private List<List<int>> neighbours;
    private List<List<int>> edgeCosts;

    public AdjacencyList() {
        neighbours = new List<List<int>>();
        edgeCosts = new List<List<int>>();
    }

    // Indexer to get or set the cost of an edge between nodes a and b.
    public int this[int a, int b] {
        get {
            int index = neighbours[a].IndexOf(b);
            if (index == -1)
                throw new ArgumentException("Edge does not exist.");
            return edgeCosts[a][index];
        }
        set {
            int index = neighbours[a].IndexOf(b);
            if (index == -1)
                throw new ArgumentException("Edge does not exist.");
            edgeCosts[a][index] = value;
        }
    }

    // Property to return the count of nodes.
    public int Count => neighbours.Count;

    // Method to add an edge between nodes a and b with a specified cost.
    public void AddEdge(int a, int b, int cost) {
        EnsureNodeExists(a);
        EnsureNodeExists(b);

        neighbours[a].Add(b);
        edgeCosts[a].Add(cost);
    }

    // Method to get the neighbors of a given node.
    public List<int> GetNeighbours(int a) {
        if (a < 0 || a >= Count)
            throw new ArgumentOutOfRangeException("Node does not exist.");
        return new List<int>(neighbours[a]);
    }

    // Method to remove an edge between nodes a and b.
    public void RemoveEdge(int a, int b) {
        int index = neighbours[a].IndexOf(b);
        if (index == -1)
            throw new ArgumentException("Edge does not exist.");

        neighbours[a].RemoveAt(index);
        edgeCosts[a].RemoveAt(index);
    }

    // Helper method to expand lists if node index is out of bounds.
    private void EnsureNodeExists(int node) {
        while (neighbours.Count <= node) {
            neighbours.Add(new List<int>());
            edgeCosts.Add(new List<int>());
        }
    }
}
