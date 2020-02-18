using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch07_07
{
    // 圖形的相鄰矩陣類別宣告
    class Adjacency
    {
        public static int INFINITE = 99999;
        public int[,] Graph_Matrix;
        // 建構子
        public Adjacency(int[,] Weight_Path, int number)
        {
            int i, j;
            int Start_Point, End_Point;
            Graph_Matrix = new int[number,number];
            for (i = 1; i < number; i++)
                for (j = 1; j < number; j++)
                    if (i != j)
                        Graph_Matrix[i,j] = INFINITE;
                    else
                        Graph_Matrix[i,j] = 0;
            for (i = 0; i < Weight_Path.GetLength(0); i++)
            {
                Start_Point = Weight_Path[i,0];
                End_Point = Weight_Path[i,1];
                Graph_Matrix[Start_Point,End_Point] = Weight_Path[i,2];
            }
        }
        // 顯示圖形的方法
        public void PrintGraph_Matrix()
        {
            for (int i = 1; i < Graph_Matrix.GetLength(0); i++)
            {
                for (int j = 1; j < Graph_Matrix.GetLength(1); j++)
                    if (Graph_Matrix[i,j] == INFINITE)
                        Write(" x ");
            else {
                    if (Graph_Matrix[i,j] == 0) Write(" ");
                        Write(Graph_Matrix[i,j] + " ");
                }
                WriteLine();
            }
        }
    }
    // Dijkstra演算法類別
    class Dijkstra :Adjacency
    {
        private int[] cost;
        private int[] selected;
        // 建構子
        public Dijkstra(int[,] Weight_Path, int number):base(Weight_Path, number) 
        {
            cost = new int[number];
            selected = new int[number];
            for (int i = 1; i < number; i++) selected[i] = 0;
        }
    // 單點對全部頂點最短距離
    public void ShortestPath(int source)
    {
        int shortest_distance;
        int shortest_vertex = 1;
        int i, j;
        for (i = 1; i < Graph_Matrix.GetLength(0); i++)
            cost[i] = Graph_Matrix[source,i];
        selected[source] = 1;
        cost[source] = 0;
        for (i = 1; i < Graph_Matrix.GetLength(0) - 1; i++)
        {
            shortest_distance = INFINITE;
            for (j = 1; j < Graph_Matrix.GetLength(0); j++)
                if (shortest_distance > cost[j] && selected[j] == 0)
                {
                    shortest_vertex = j;
                    shortest_distance = cost[j];
                }
            selected[shortest_vertex] = 1;
            for (j = 1; j < Graph_Matrix.GetLength(0); j++)
            {
                if (selected[j] == 0 &&
                    cost[shortest_vertex] + Graph_Matrix[shortest_vertex,j] < cost[j])
                {
                    cost[j] = cost[shortest_vertex] + Graph_Matrix[shortest_vertex,j];
                }
            }
        }
            WriteLine("==================================");
            WriteLine("頂點1到各頂點最短距離的最終結果");
            WriteLine("==================================");
        for (j = 1; j < Graph_Matrix.GetLength(0); j++)
            WriteLine("頂點1到頂點" + j + "的最短距離= " + cost[j]);
    }

}
class Program
    {
        static void Main(string[] args)
        {
            int[,] Weight_Path = { {1, 2, 10},{2, 3, 20}, 
                       {2, 4, 25},{3, 5, 18},
                       {4, 5, 22},{4, 6, 95},{5, 6, 77} };
            Dijkstra obj=new Dijkstra(Weight_Path,7);
            WriteLine("==========================");
            WriteLine("此範例圖形的相鄰矩陣如下: ");
            WriteLine("==========================");
            obj.PrintGraph_Matrix();
            obj.ShortestPath(1);
            ReadKey();
        }
    }
}
