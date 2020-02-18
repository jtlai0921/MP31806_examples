using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch05_01
{
    class Program
    {
        public static int front = -1, rear = -1, max = 20;
        public static int val;
        public static char ch;
        public static int[] queue = new int[max];

        static void Main(string[] args)
        {
            String strM;
            int M = 0;
            while (rear < max - 1 && M != 3)
            {
                Write("[1]存入一個數值[2]取出一個數值[3]結束: ");
                strM = ReadLine();
                M = int.Parse(strM);
                switch (M)
                {
                    case 1:
                        Write("\n[請輸入數值]: ");
                        strM = ReadLine();
                        val = int.Parse(strM);
                        rear++;
                        queue[rear] = val;
                        break;
                    case 2:
                        if (rear > front)
                        {
                            front++;
                            Write("\n[取出數值為]: [" + queue[front] + "]" + "\n");
                            queue[front] = 0;
                        }
                        else
                        {
                            Write("\n[佇列已經空了]\n");
                            break;
                        }
                        break;
                    default:
                        WriteLine();
                        break;
                }
            }
            if (rear == max - 1) Write("[佇列已經滿了]\n");
            Write("\n[目前佇列中的資料]:");
            if (front >= rear)
            {
                Write("沒有\n");
                Write("[佇列已經空了]\n");
            }
            else
            {
                while (rear > front)
                {
                    front++;
                    Write("[" + queue[front] + "]");
                }
                Write("\n");
            }
            ReadKey();
        }
    }
}
