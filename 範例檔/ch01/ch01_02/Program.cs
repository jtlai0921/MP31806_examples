using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch01_02
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            string str;
            
            WriteLine("使用遞迴計算費氏級數");
            Write("請輸入一個整數:");
            str = ReadLine();
            num = int.Parse(str);
            if (num < 0)
                WriteLine("輸入數字必須大於0");
            else
                Write("Fibonacci(" + num + ")=" + Fibonacci(num) + "\n");
            ReadKey();
        }
        static int Fibonacci(int n)
        {
            if (n == 0)      // 第0項為 0
                return (0);
            else if (n == 1) // 第1項為 1
                return (1);
            else
                return (Fibonacci(n - 1) + Fibonacci(n - 2));
            // 遞迴呼叫函數 第N項為n-1 跟 n-2項之和
        }
    }
}
