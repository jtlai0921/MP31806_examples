using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch07_08
{
    // 圖形的相鄰矩陣類別宣告
    class Adjacency
    {
        static int INFINITE = 99999;
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
    // Floyd演算法類別
    class Floyd : Adjacency
    {
        private int[][] cost;
        private int capcity;
        // 建構子
        public Floyd(int[,] Weight_Path, int number):base(Weight_Path, number)
        {
            cost = new int[number][];
            capcity = Graph_Matrix.GetLength(0);
            for (int i = 0; i < capcity; i++)
                cost[i] = new int[number];
        }
        // 所有頂點兩兩之間的最短距離
        public void ShortestPath()
        {
            for (int i = 1; i < Graph_Matrix.GetLength(0); i++)
                for (int j = i; j < Graph_Matrix.GetLength(0); j++)
                    cost[i][j] = cost[j][i] = Graph_Matrix[i,j];
            for (int k = 1; k < Graph_Matrix.GetLength(0); k++)
                for (int i = 1; i < Graph_Matrix.GetLength(0); i++)
                    for (int j = 1; j < Graph_Matrix.GetLength(0); j++)
                        if (cost[i][k] + cost[k][j] < cost[i][j])
                            cost[i][j] = cost[i][k] + cost[k][j];
                Write("頂點 vex1 vex2 vex3 vex4 vex5 vex6\n");
            for (int i = 1; i < Graph_Matrix.GetLength(0); i++)
            {
                Write("vex" + i + " ");
                for (int j = 1; j < Graph_Matrix.GetLength(0); j++)
                {
                    // 調整顯示的位置, 顯示距離陣列
                    if (cost[i][j] < 10) Write(" ");
                    if (cost[i][j] < 100) Write(" ");
                    Write(" " + cost[i][j] + " ");
                }
                WriteLine();
        }
    }
}
class Program
    {
        static void Main(string[] args)
        {
            int[,] Weight_Path = { {1, 2, 10},{2, 3, 20}, 
                       {2, 4, 25},{3, 5, 18},
                       {4, 5, 22},{4, 6, 95},{5, 6, 77} };
            Floyd obj = new Floyd(Weight_Path,7);
            WriteLine("==========================");
            WriteLine("此範例圖形的相鄰矩陣如下: ");
            WriteLine("==========================");
            obj.PrintGraph_Matrix();
            WriteLine("==================================");
            WriteLine("所有頂點兩兩之間的最短距離: ");
            WriteLine("==================================");
            obj.ShortestPath();
            ReadKey();
        }
    }
}
