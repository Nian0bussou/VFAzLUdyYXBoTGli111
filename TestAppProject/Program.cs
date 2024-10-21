using GraphLib;

//  partie 1
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


var bfs_section = () =>
{ // BFS sectino
    var traversal1 = Pathfinding.TraversalBFS(a, 1);
    foreach (var node in traversal1)
        Console.Write($"{node} ");
    Console.WriteLine();


    Console.WriteLine();

    Console.WriteLine(Pathfinding.PathExistsBFS(a, 0, 4));
    Console.WriteLine(Pathfinding.PathExistsBFS(a, 1, 0));
    Console.WriteLine(Pathfinding.PathExistsBFS(a, 2, 5));
};

var dfs_section = () =>
{
    var traversal2 = Pathfinding.TraversalDFS(a, 1);
    foreach (var node in traversal2)
        Console.Write($"{node} ");
    Console.WriteLine();

    System.Console.WriteLine();

    Console.WriteLine(Pathfinding.PathExistsDFS(a, 0, 4));
    Console.WriteLine(Pathfinding.PathExistsDFS(a, 1, 0));
    Console.WriteLine(Pathfinding.PathExistsDFS(a, 2, 5));

};

// bfs_section();

dfs_section();



