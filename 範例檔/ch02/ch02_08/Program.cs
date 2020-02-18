using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch02_08
{
    class Program
    {
        const int ARRAY_SIZE= 5;
        static int[,] A={ //上三角矩陣的內容 
                        {7, 8, 12, 21, 9}, 
                        {0, 5, 14,  17, 6}, 
                        {0, 0, 7, 23, 24}, 
                        {0, 0, 0,  32, 19}, 
                        {0, 0, 0,  0,  8}};  
        //一維陣列的陣列宣告 
        static int[] B =new int [ARRAY_SIZE * (1 + ARRAY_SIZE) / 2];

        static int GetValue(int i, int j)
        {
            int index =ARRAY_SIZE * i - i * (i + 1) / 2 + j;
            return B[index];
        }

        static void Main(string[] args)
        {
            int i = 0, j = 0;
            int index;
          
            WriteLine("==========================================");
            WriteLine("上三角形矩陣：");
            for (i = 0; i < ARRAY_SIZE; i++)
            {
                for (j = 0; j < ARRAY_SIZE; j++)
                    Write("\t"+ A[i,j]);
                WriteLine();
            }
            //將右上三角矩陣壓縮為一維陣列 
            index = 0;
            for (i = 0; i < ARRAY_SIZE; i++)
            {
                for (j = 0; j < ARRAY_SIZE; j++)
                {
                    if (A[i,j] != 0) B[index++] = A[i,j];
                }
            }
            WriteLine("==========================================");
            WriteLine("以一維的方式表示：");
            Write("\t[");
            for (i = 0; i < ARRAY_SIZE; i++)
            {
                for (j = i; j < ARRAY_SIZE; j++)
                    Write(" " + GetValue(i, j));
            }
            Write(" ]");
            WriteLine();
            ReadKey();
        }
    }
}
