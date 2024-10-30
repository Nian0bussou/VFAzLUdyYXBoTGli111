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

    public int this[int a, int b] {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    public int Count => neighbours.Count;

    public void AddEdge(int a, int b, int cost) { }

    public List<int> GetNeighbours(int a) {
        throw new NotImplementedException();
    }

    public void RemoveEdge(int a, int b) {
        throw new NotImplementedException();
    }

    // Helper method to expand lists if node index is out of bounds.
    private void EnsureNodeExists(int node) {
        throw new NotImplementedException();
    }
}
