using GraphLib;

//  partie 1

{
    var a = new AdjacencyMatrix(6);

    a[0, 1] = 1;
    a[0, 2] = 3;

    a[1, 0] = 1;
    a[1, 3] = 4;
    a[1, 4] = 10;
    a[2, 3] = 3;

    a[3, 4] = 1;
    a[3, 6] = 1;

    Console.WriteLine(a);
}
