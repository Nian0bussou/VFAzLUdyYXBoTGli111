

using System.Collections.Generic;
using GraphLib;

public class AdjacencyList : IGraph {

    List<List<int>>? neighbours;
    List<List<int>>? edgeCosts;


    public int this[int a, int b] { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public int Count => throw new System.NotImplementedException();

    public void AddEdge(int a, int b, int cost) {
        throw new System.NotImplementedException();
    }

    public List<int> GetNeighbours(int a) {
        throw new System.NotImplementedException();
    }

    public void RemoveEdge(int a, int b) {
        throw new System.NotImplementedException();
    }
}