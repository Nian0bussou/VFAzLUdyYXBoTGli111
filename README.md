# TP3 - GraphLib (Partie 1)


# notes

[DFS impl.](https://youtu.be/PMMc4VsIacU?si=Q_GkCmCrh_WWlK3l&t=670)


[gfg](https://www.geeksforgeeks.org/print-paths-given-source-destination-using-bfs/)

```csharp
private static void findpaths(List<List<int> > g, 
                              int src, int dst, int v)
{
    
    // Create a queue which stores
    // the paths
    Queue<List<int> > queue = new Queue<List<int>>();

    // Path vector to store the current path
    List<int> path = new List<int>();
    path.Add(src);
    queue.Enqueue(path);
    
    while (queue.Count!=0) 
    {
        path = queue.Dequeue();
        int last = path[path.Count - 1];

        // If last vertex is the desired destination
        // then print the path
        if (last == dst) 
        {
            printPath(path);
        }

        // Traverse to all the nodes connected to
        // current vertex and push new path to queue
        List<int> lastNode = g[last];
        for(int i = 0; i < lastNode.Count; i++)
        {
            if (isNotVisited(lastNode[i], path)) 
            {
                List<int> newpath = new List<int>(path);
                newpath.Add(lastNode[i]);
                queue.Enqueue(newpath);
            }
        }
    }
}
```

# bonus
  - text representation -> json ?
