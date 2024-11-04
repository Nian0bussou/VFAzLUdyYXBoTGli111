using System;
using System.Collections.Generic;
using GraphLib;

public class AdjacencyList : IGraph {
    private List<int>[] neighbours;
    private List<int>[] edgeCosts;
    public AdjacencyList(int count) {
        neighbours = new List<int>[count];
        edgeCosts = new List<int>[count];
        for (int i = 0; i < count; i++) {
            neighbours[i] = new List<int>();
            edgeCosts[i] = new List<int>();
        }
    }
    public int this[int a, int b] {
        get => GetEdge(a, b);
        set => AddEdge(a, b, value);
    }
    public int Count => neighbours.Length;
    public void AddEdge(int a, int b, int cost) {
        int index = neighbours[a].IndexOf(b);
        if (index != -1) edgeCosts[a][index] = cost;
        else {
            neighbours[a].Add(b);
            edgeCosts[a].Add(cost);
        }
    }
    public int GetEdge(int a, int b) {
        int index = neighbours[a].IndexOf(b);
        return index != -1 ? edgeCosts[a][index] : throw new KeyNotFoundException("Edge does not exist.");
    }
    public List<int> GetNeighbours(int a) => new List<int>(neighbours[a]);
    public void RemoveEdge(int a, int b) {
        int index = neighbours[a].IndexOf(b);
        if (index != -1) {
            neighbours[a].RemoveAt(index);
            edgeCosts[a].RemoveAt(index);
        } else {
            throw new KeyNotFoundException("Edge does not exist.");
        }
    }
    public override string ToString() {
        string str = "";
        for (int i = 0; i < neighbours.Length; i++) {
            str += $"{i}: ";
            for (int j = 0; j < neighbours[i].Count; j++) {
                str += $"({neighbours[i][j]} : {edgeCosts[i][j]})  ";
            }
            str += Environment.NewLine;
        }
        return str;
    }
}
