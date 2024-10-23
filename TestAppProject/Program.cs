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

// Console.WriteLine(a);


var bfs_section = () => { // BFS sectino
        var traversal1 = Pathfinding.TraversalBFS(a, 1);
        foreach (var node in traversal1)
                Console.Write($"{node} ");
        Console.WriteLine();


        Console.WriteLine();

        Console.WriteLine(Pathfinding.PathExistsBFS(a, 0, 4));
        Console.WriteLine(Pathfinding.PathExistsBFS(a, 1, 0));
        Console.WriteLine(Pathfinding.PathExistsBFS(a, 2, 5));

        Console.WriteLine();

        int[] starts = { 1, 0, 0, 0 };
        int[] ends =
         { 3, 4, 5, 6 };
        for (int i = 0; i < starts.Length; ++i) {
                var path = Pathfinding.GetPathBFS(a, starts[i], ends[i]);
                for (int j = 0; j < path.Count; ++j) {
                        Console.Write($"{path[j]}-");
                }
                Console.WriteLine();
        }

        Console.WriteLine();
};

var dfs_section = () => {
        var traversal2 = Pathfinding.TraversalDFS(a, 1);
        foreach (var node in traversal2)
                Console.Write($"{node} ");
        Console.WriteLine();

        System.Console.WriteLine();

        Console.WriteLine(Pathfinding.PathExistsDFS(a, 0, 4));
        Console.WriteLine(Pathfinding.PathExistsDFS(a, 1, 0));
        Console.WriteLine(Pathfinding.PathExistsDFS(a, 2, 5));

        System.Console.WriteLine();

        int[] starts = { 1, 0, 0, 0 };
        int[] ends =
         { 3, 4, 5, 6 };
        for (int i = 0; i < starts.Length; ++i) {
                var path = Pathfinding.GetPathDFS(a, starts[i], ends[i]);
                for (int j = 0; j < path.Count; ++j) {
                        Console.Write($"{path[j]}-");
                }
                Console.WriteLine();
        }

};

var dijkstra_section = () => {
        int[] starts = { 1, 0, 0, 0 };
        int[] ends = { 3, 4, 5, 6 };
        for (int i = 0; i < starts.Length; ++i) {
                var path = Pathfinding.GetPathDijkstra(a, starts[i], ends[i]);
                for (int j = 0; j < path.Count; ++j) {
                        Console.Write($"{path[j]}-");
                }
                Console.WriteLine();
        }
};

// bfs_section();
// dfs_section();
// dijkstra_section();

var file_test = () => {

        string file = "matrix.txt";

        var A = new AdjacencyMatrix(file);

        System.Console.WriteLine(A);
};

file_test();