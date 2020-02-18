using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch05_03
{
    class Program
    {
        public static int front = -1, rear = -1, val;
        public static int[] queue = new int[5];
        static void Main(string[] args)
        {
            String strM;
            while (rear < 5 && val != -1)
            {
                Write("請輸入一個值以存入佇列，欲取出值請輸入0。(結束輸入-1)：");
                strM = ReadLine();
                val = int.Parse(strM);
                if (val == 0)
                {
                    if (front == rear)
                    {
                        Write("[佇列已經空了]\n");
                        break;
                    }
                    front++;
                    if (front == 5)
                        front = 0;
                    Write("取出佇列值 [" + queue[front] + "]\n");
                    queue[front] = 0;
                }
                else if (val != -1 && rear < 5)
                {
                    if (rear + 1 == front || rear == 4 && front <= 0)
                    {
                        Write("[佇列已經滿了]\n");
                        break;
                    }
                    rear++;
                    if (rear == 5)
                        rear = 0;
                    queue[rear] = val;
                }
            }
            Write("\n佇列剩餘資料：\n");
            if (front == rear)
                Write("佇列已空!!\n");
	        else 
	        {
                while (front != rear)
                {
                    front++;
                    if (front == 5)
                        front = 0;
                    Write("[" + queue[front] + "]");
                    queue[front] = 0;
                }
            }
            WriteLine();
            ReadKey();
        }
    }
}
