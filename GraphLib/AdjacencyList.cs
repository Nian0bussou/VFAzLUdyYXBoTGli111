using System;
using System.Collections.Generic;
using System.Linq;
using GraphLib;

public class AdjacencyList : IGraph {
    private List<int>[] neighbours;
    private List<int>[] edgeCosts;

    // Constructor initializes adjacency and edge cost lists for a given count of nodes
    public AdjacencyList(int count) {
        neighbours = new List<int>[count];
        edgeCosts = new List<int>[count];
        for (int i = 0; i < count; i++) {
            neighbours[i] = new List<int>();
            edgeCosts[i] = new List<int>();
        }
    }

    // Indexer to access edge costs directly
    public int this[int a, int b] {
        get => GetEdge(a, b);
        set => AddEdge(a, b, value);
    }

    // Property to get the number of nodes in the graph
    public int Count => neighbours.Length;

    // Adds an edge from node 'a' to node 'b' with a given cost
    public void AddEdge(int a, int b, int cost) {
        EnsureNodeExists(a);
        EnsureNodeExists(b);

        // Check if the edge already exists to update cost
        int index = neighbours[a].IndexOf(b);
        if (index != -1) {
            edgeCosts[a][index] = cost;  // Update cost if edge exists
        } else {
            neighbours[a].Add(b);        // Add new edge and cost
            edgeCosts[a].Add(cost);
        }
    }

    // Gets the cost of the edge from node 'a' to node 'b'
    public int GetEdge(int a, int b) {
        EnsureNodeExists(a);
        int index = neighbours[a].IndexOf(b);
        return index != -1 ? edgeCosts[a][index] : throw new KeyNotFoundException("Edge does not exist.");
    }

    // Retrieves a list of all neighbors of a given node 'a'
    public List<int> GetNeighbours(int a) {
        EnsureNodeExists(a);
        return new List<int>(neighbours[a]);  // Return a copy to prevent modification
    }

    // Removes the edge from node 'a' to node 'b' if it exists
    public void RemoveEdge(int a, int b) {
        EnsureNodeExists(a);
        int index = neighbours[a].IndexOf(b);
        if (index != -1) {
            neighbours[a].RemoveAt(index);
            edgeCosts[a].RemoveAt(index);
        } else {
            throw new KeyNotFoundException("Edge does not exist.");
        }
    }

    // Helper method to expand lists if node index is out of bounds
    private void EnsureNodeExists(int node) {
        if (node < 0 || node >= neighbours.Length) {
            throw new ArgumentOutOfRangeException(nameof(node), "Node index is out of bounds.");
        }
    }

    public override string ToString() {

        for (int i = 0; i < neighbours.Length; i++) { }

        return "";
    }
}
