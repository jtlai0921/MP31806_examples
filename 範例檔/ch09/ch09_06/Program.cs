using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch09_06
{
    class Node
    {
        public int val;
        public Node next;
        public Node(int val)
        {
            this.val = val;
            this.next = null;
        }
    }

    class Program
    {
        const int INDEXBOX = 7;   //雜湊表最大元素
        const int MAXNUM = 13;    //最大資料個數
        static Node[] indextable = new Node[INDEXBOX]; //宣告動態陣列

        static void Main(string[] args)
        {
            int i, num;
            int[] index = new int[INDEXBOX];
            int[] data = new int[MAXNUM];
            Random rand = new Random();
            for (i = 0; i < INDEXBOX; i++)
                indextable[i] = new Node(-1); //清除雜湊表
            Write("原始資料：\n\t");
            for (i = 0; i < MAXNUM; i++) //起始資料值
            {
                data[i] = rand.Next(30) + 1;
                Write("[" + data[i] + "]");
                if (i % 8 == 7)
                    Write("\n\t");
            }
            for (i = 0; i < MAXNUM; i++)
                Creat_table(data[i]); //建立雜湊表
            WriteLine();
            while (true)
            {
                Write("請輸入搜尋資料(1-30)，結束請輸入-1：");
                num = int.Parse(ReadLine());
                if (num == -1)
                    break;
                i = Findnum(num);
                if (i == 0)
                    WriteLine("#####沒有找到 " + num + " #####");
		        else
                    WriteLine("找到 " + num + "，共找了 " + i + " 次!");
            }
            WriteLine("\n雜湊表：");
            for (i = 0; i < INDEXBOX; i++)
                Print_data(i); //列印雜湊表
            ReadKey();
        }
        public static void Creat_table(int val) //建立雜湊表副程式
        {
            Node newnode = new Node(val);
            int hash;
            hash = val % 7; //雜湊函數除以7取餘數
            Node current = indextable[hash];
            if
             (current.next == null) indextable[hash].next = newnode;
            else
                while (current.next != null) current = current.next;
            current.next = newnode; //將節點加在串列
        }
        public static void Print_data(int val) //列印雜湊表副程式
        {
            Node head;
            int i = 0;
            head = indextable[val].next; //起始指標
            Write("   " + val + "：\t"); //索引位址
            while (head != null)
            {
                Write("[" + head.val + "]-");
                i++;
                if (i % 8 == 7) //控制長度
                    Write("\n\t");
                head = head.next;
            }
            WriteLine("\b "); //清除最後一個"-"符號
        }

        public static int Findnum(int num) //雜湊搜尋副程式
        {
            Node ptr;
            int i = 0, hash;
            hash = num % 7;
            ptr = indextable[hash].next;
            while (ptr != null)
            {
                i++;
                if (ptr.val == num)
                    return i;
                else
                    ptr = ptr.next;
            }
            return 0;
        }
    }
}
