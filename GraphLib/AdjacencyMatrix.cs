using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GraphLib {
    public class InvalidNodeCountException : ArgumentException { }
    public class InvalidEdgeCostException : ArgumentException { }

    public class AdjacencyMatrix : IGraph {
        private readonly int[,] data;
        private int count;
        private const int NO_EDGE = -1;

        public int Count {
            get => count;
            private set {
                if (value < 0)
                    throw new InvalidNodeCountException();
                count = value;
            }
        }

        public int this[int a, int b] {
            get => data[a, b];
            set => AddEdge(a, b, value);
        }

        public void AddEdge(int a, int b, int cost) {
            if (cost < 0)
                throw new InvalidEdgeCostException();

            data[a, b] = cost;
        }

        public List<int> GetNeighbours(int a) {
            var neighbours = new List<int>();

            for (int i = 0; i < Count; ++i)
                if (data[a, i] != NO_EDGE)
                    neighbours.Add(i);

            return neighbours;
        }

        public AdjacencyMatrix(int n) {
            Count = n;
            data = new int[Count, Count];

            InitData();
        }
        public AdjacencyMatrix(string path) {


            if (!File.Exists(path)) throw new FileNotFoundException($"file : {path} not found");

            StreamReader sr = new StreamReader(path);

            var strings = new List<string>();

            while (sr.EndOfStream) {
                strings.Add(sr.ReadLine());
            }

            var int_strinsg = new List<List<int>>();

            var non_empty_lines = new List<List<string>>();
            foreach (var str in strings) {
                var line = str.Trim().Split(" ");

                non_empty_lines.Add(line.ToList());
            }

            Count = non_empty_lines.Count;

            data = new int[Count, Count];

            for (int i = 0; i < non_empty_lines.Count; i++) {
                for (int j = 0; j < non_empty_lines[i].Count; j++) {

                    var tmp_str = non_empty_lines[i][j];

                    int.TryParse(tmp_str, out int n);

                    data[i, j] = n;
                }
            }

            sr.Close();



        }

        public override string ToString() {
            //On pourrait garder en mémoire la string au lieu de toujours la reconstruire à chaque fois...

            int rows = data.GetLength(0);
            int cols = data.GetLength(1);

            int maxWidth = FindMaxValueWidth(data);

            //** BONUS **
            //On pourrait calculer exactement le nombre de caractères nécessaires et 
            //donner cette valeur au constructeur de StringBuilder pour éviter
            //des "redimensionnage" du StringBuilder
            var sb = new StringBuilder();

            sb.Append(new string(' ', maxWidth + 1));
            for (int i = 0; i < cols; i++) {
                sb.Append($"{i.ToString().PadLeft(maxWidth)} ");
            }
            sb.AppendLine();
            sb.Append(new string(' ', maxWidth + 1));
            for (int i = 0; i < cols; i++) {
                sb.Append($"{"-".PadLeft(maxWidth, '-')}-");
            }
            sb.AppendLine();

            for (int i = 0; i < rows; i++) {
                sb.Append($"{i}| ");
                for (int j = 0; j < cols; j++) {
                    if (data[i, j] != NO_EDGE)
                        sb.Append($"{data[i, j].ToString().PadLeft(maxWidth)} ");
                    else
                        sb.Append($"{"-".ToString().PadLeft(maxWidth)} ");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        private void InitData() {
            for (int i = 0; i < Count; i++)
                for (int j = 0; j < Count; j++)
                    data[i, j] = NO_EDGE;
        }

        private int FindMaxValueWidth(IEnumerable data) {
            int maxWidth = 0;
            foreach (int value in data) {
                int valueLength = value.ToString().Length;
                if (valueLength > maxWidth) {
                    maxWidth = valueLength;
                }
            }

            return maxWidth;
        }
    }
}
