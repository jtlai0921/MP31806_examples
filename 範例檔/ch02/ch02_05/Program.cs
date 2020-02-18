using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch02_05
{
    class Program
    {
        static void Main(string[] args)
        {
            int M, N, P;
            int i, j;
            String strM;
            String strN;
            String strP;
            String tempstr;
            WriteLine("請輸入矩陣A的維數(M,N): ");
            Write("請先輸入矩陣A的M值: ");
            strM = ReadLine();
            M = int.Parse(strM);
            Write("接著輸入矩陣A的N值: ");
            strN = ReadLine();
            N = int.Parse(strN);
            int[,] A = new int[M, N];
            WriteLine("[請輸入矩陣A的各個元素]");
            WriteLine("注意！每輸入一個值按下Enter鍵確認輸入");
            for (i = 0; i < M; i++)
                for (j = 0; j < N; j++)
                {
                    Write("a" + i + j + "=");
                    tempstr = ReadLine();
                    A[i, j] = int.Parse(tempstr);
                }
            WriteLine("請輸入矩陣B的維數(N,P): ");
            Write("請先輸入矩陣B的N值: ");
            strN = ReadLine();
            N = int.Parse(strN);
            Write("接著輸入矩陣B的P值: ");
            strP = ReadLine();
            P = int.Parse(strP);
            int[,] B = new int[N, P];
            WriteLine("[請輸入矩陣B的各個元素]");
            WriteLine("注意！每輸入一個值按下Enter鍵確認輸入");
            for (i = 0; i < N; i++)
                for (j = 0; j < P; j++)
                {
                    Write("b" + i + j + "=");
                    tempstr = ReadLine();
                    B[i, j] = int.Parse(tempstr);
                }
            int[,] C = new int[M, P];
            MatrixMultiply(A, B, C, M, N, P);
            WriteLine("[AxB的結果是]");
            for (i = 0; i < M; i++)
            {
                for (j = 0; j < P; j++)
                {
                    Write(C[i, j]);
                    Write('\t');
                }
                WriteLine();
            }
            ReadKey();
        }

        static void MatrixMultiply(int[,] arrA, int[,] arrB, int[,] arrC, int M, int N, int P)
        {
            int i, j, k, Temp;
            if (M <= 0 || N <= 0 || P <= 0)
            {
                WriteLine("[錯誤:維數M,N,P必須大於0]");
                return;
            }
            for (i = 0; i < M; i++)
                for (j = 0; j < P; j++)
                {
                    Temp = 0;
                    for (k = 0; k < N; k++)
                        Temp = Temp + arrA[i,k] * arrB[k,j];
                    arrC[i,j] = Temp;
                }
        }
    }
}