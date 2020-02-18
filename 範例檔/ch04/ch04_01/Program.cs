using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch04_01
{
    class StackByArray
    { //以陣列模擬堆疊的類別宣告
        private int[] stack; //在類別中宣告陣列
        private int top;  //指向堆疊頂端的索引
                          //StackByArray類別建構子
        public StackByArray(int stack_size)
        {
            stack = new int[stack_size]; //建立陣列
            top = -1;
        }
        //類別方法：Push
        //存放頂端資料,並更正新堆疊的內容.
        public bool Push(int data)
        {
            if (top >= stack.Length)
            { //判斷堆疊頂端的索引是否大於陣列大小
                WriteLine("堆疊已滿,無法再加入");
                return false;
            }
            else
            {
                stack[++top] = data; //將資料存入堆疊
                return true;
            }
        }
        //類別方法：Empty
        //判斷堆疊是否為空堆疊,是則傳回true,不是則傳回false.
        public bool Empty()
        {
            if (top == -1) return true;
            else return false;
        }
        //類別方法：Pop
        //從堆疊取出資料
        public int Pop()
        {
            if (Empty()) //判斷堆疊是否為空的,如果是則傳回-1值
                return -1;
            else
                return stack[top--]; //先將資料取出後,再將堆疊指標往下移
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int value;
            StackByArray stack = new StackByArray(10);
            WriteLine("請依序輸入10筆資料：");
            for (int i = 0; i < 10; i++)
            {
                value = int.Parse(Console.ReadLine());
                stack.Push(value);
            }
            WriteLine("=============================");
            while (!stack.Empty()) //將堆疊資料陸續從頂端彈出
                WriteLine("堆疊彈出的順序為:" + stack.Pop());
            ReadKey();
        }
    }
}
