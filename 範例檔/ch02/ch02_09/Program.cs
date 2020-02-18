﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch02_09
{
    class Program
    {
        const int ARRAY_SIZE = 5; //矩陣的維數大小    

        static int[,] A={ //下三角矩陣的內容 
                          {76, 0, 0, 0, 0}, 
                          {54, 51, 0, 0, 0}, 
                          {23, 8, 26, 0, 0}, 
                          {43, 35, 28, 18, 0}, 
                          {12, 9, 14, 35, 46}};  
        //一維陣列的陣列宣告 
        static int[] B= new int[ARRAY_SIZE * (1 + ARRAY_SIZE) / 2];
        static int GetValue(int i, int j)
        {
            int index = ARRAY_SIZE * i - i * (i + 1) / 2 + j;
            return B[index];
        }
        static void Main(string[] args)
        {
            int i = 0, j = 0;
            int index;
            Write("==========================================\n");
            Write("下三角形矩陣：\n");
            for (i = 0; i < ARRAY_SIZE; i++)
            {
                for (j = 0; j < ARRAY_SIZE; j++)
                    Write($"\t{A[i,j]}");
                WriteLine();
            }
            //將左下三角矩陣壓縮為一維陣列 
            index = 0;
            for (i = 0; i < ARRAY_SIZE; i++)
            {
                for (j = 0; j < ARRAY_SIZE; j++)
                {
                    if (A[i,j] != 0) B[index++] = A[i,j];
                }
            }
            Write("==========================================\n");
            Write("以一維的方式表示：\n");
            Write("\t[");
            for (i = 0; i < ARRAY_SIZE; i++)
            {
                for (j = i; j < ARRAY_SIZE; j++)
                    Write($" {GetValue(i, j)}");
            }
            Write(" ]");
            WriteLine();
            ReadKey();
        }
    }
}
