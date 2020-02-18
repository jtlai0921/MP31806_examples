using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch02_04
{
    class Program
    {
        static void MatrixAdd(int[,]  arrA, int[,] arrB, int[,] arrC, int dimX, int dimY)
        {
            int row, col;
            if (dimX <= 0 || dimY <= 0)
            {
                WriteLine("矩陣維數必須大於0");
                return;
            }
            for (row = 1; row <= dimX; row++)
            {
                for (col = 1; col <= dimY; col++)
                {
                    arrC[(row - 1),(col - 1)] = arrA[(row - 1),(col - 1)] + arrB[(row - 1),(col - 1)];
                }
            }
        }
        static void Main(string[] args)
        {
            int i;
            int j;
            const int ROWS = 3;
            const int COLS = 3;
            int[,] A = {{1,3,5},
                        {7,9,11},
                        {13,15,17}};
            int[,] B = {{9,8,7},
                        {6,5,4},
                        {3,2,1}};
            int[,] C = new int[ROWS,COLS];
            WriteLine("[矩陣A的各個元素]");  //印出矩陣A的內容
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                    Write(A[i,j] + " \t");
                WriteLine();
            }
            WriteLine("[矩陣B的各個元素]");  //印出矩陣B的內容
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                    Write(B[i,j] + " \t");
                WriteLine();
            }
            MatrixAdd(A, B, C, 3, 3);
            WriteLine("[顯示矩陣A和矩陣B相加的結果]"); //印出A+B的內容
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                    Write(C[i,j] + " \t");
                WriteLine();
            }
            ReadKey();
        }
    }
}