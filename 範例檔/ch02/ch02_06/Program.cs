using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch02_06
{
    class Program
    {
        static void Main(string[] args)
        {
            int M, N, row, col;
            String strM;
            String strN;
            String tempstr;
            WriteLine("[輸入MxN矩陣的維度]");
            Write("請輸入維度M: ");
            strM = ReadLine();
            M = int.Parse(strM);
            Write("請輸入維度N: ");
            strN = ReadLine();
            N = int.Parse(strN);
            int[,] arrA=new int[M,N];
	        int[,] arrB=new int[N,M];
	        WriteLine("[請輸入矩陣內容]");
	        for(row=1;row<=M;row++)
	        {
		        for(col=1;col<=N;col++)
		        {
			        Write("a"+row+col+"=");
                    tempstr= ReadLine();
                    arrA[row - 1,col - 1]= int.Parse(tempstr);
		        }
            }
            WriteLine("[輸入矩陣內容為]\n");
	        for(row=1;row<=M;row++)
	        {
		        for(col=1;col<=N;col++)
		        {
			        Write(arrA[(row - 1),(col - 1)]);
                    Write('\t');
		        }
		    WriteLine();
	        }
	        //進行矩陣轉置的動作
	        for(row=1;row<=N;row++)
		        for(col=1;col<=M;col++)
			        arrB[(row - 1),(col - 1)]=arrA[(col - 1),(row - 1)];

	        WriteLine("[轉置矩陣內容為]");
	        for(row=1;row<=N;row++)
	        {
		        for(col=1;col<=M;col++)
		        {
			        Write(arrB[(row - 1),(col - 1)]);
                    Write('\t');
		        }
		        WriteLine();
	        }
            ReadKey();
        }
    }
}
