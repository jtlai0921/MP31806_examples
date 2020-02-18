using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch01_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 1;

            Write("請從鍵盤輸入n= ");
            int n = int.Parse(ReadLine());

            //以for迴圈計算 n! 
            for (int i = 1; i < n + 1; i++)
            {
                for (int j = i; j > 0; j--)
                    sum = sum * j;    // sum=sum*j
                WriteLine(i + "!=" + sum);
                sum = 1;
            }
            ReadKey();
        }
    }
}
