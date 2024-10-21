using GraphLib;

//  partie 1

void bfs_section() { // BFS sectino
    var a = new AdjacencyMatrix(7);

    a[0, 1] = 1;
    a[0, 2] = 3;

    a[1, 0] = 1;
    a[1, 3] = 4;
    a[1, 4] = 10;
    a[2, 3] = 3;

    a[3, 4] = 1;
    a[3, 6] = 1;

    Console.WriteLine(a);

    var traversal1 = Pathfinding.TraversalBFS(a, 1);
    foreach (var node in traversal1)
        Console.Write($"{node} ");
    Console.WriteLine();


    Console.WriteLine();

    Console.WriteLine(Pathfinding.PathExistsBFS(a, 0, 4));
    Console.WriteLine(Pathfinding.PathExistsBFS(a, 1, 0));
    Console.WriteLine(Pathfinding.PathExistsBFS(a, 2, 5));
}

bfs_section();



