using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;//滙入靜態類別

namespace ch01_01
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine($"5!={Fac(5)}");
            ReadKey();
        }
        static int Fac(int n)
        {
            if (n == 0) //遞迴終止的條件
                return 1;
            else
                return n * Fac(n - 1); //遞迴呼叫
        }
    }
}
