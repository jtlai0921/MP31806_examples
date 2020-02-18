using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch04_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int j;
            String str;
            Write("請輸入盤子數量： ");
            str = ReadLine();
            j =int.Parse(str);
            Hanoi(j, 1, 2, 3);
            ReadKey();
        }
        public static void Hanoi(int n, int p1, int p2, int p3)
        {
            if (n == 1)
                WriteLine("盤子從 " + p1 + " 移到 " + p3);
	        else
		    {
                Hanoi(n - 1, p1, p3, p2);
                WriteLine("盤子從 " + p1 + " 移到 " + p3);
                Hanoi(n - 1, p2, p1, p3);
            }
        }
    }
 }
