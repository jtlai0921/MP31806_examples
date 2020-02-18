using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch03_01
{
    public class Node
    {
        public int data;
        public int np;
        public String names;
        public Node next;
        public Node(int data, String names, int np)
        {
            this.np = np;
            this.names = names;
            this.data = data;
            this.next = null;
        }
    }

    public class LinkedList
    {
        private Node first;
        private Node last;
        public bool isEmpty()
        {
            return first == null;
        }
        public void Print()
        {
            Node current = first;
            while (current != null)
            {
                WriteLine("[" + current.data + " " + current.names + " " + current.np + "]");
                current = current.next;
            }
            WriteLine();
        }
        public void Insert(int data, String names, int np)
        {
            Node newNode = new Node(data, names, np);
            if (this.isEmpty())
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                last.next = newNode;
                last = newNode;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int num;
            String name;
            int score;

            WriteLine("請輸入5筆學生資料： ");
            LinkedList list = new LinkedList();
            for (int i = 1; i < 6; i++)
            {
                Write("請輸入座號： ");
                num = int.Parse(ReadLine());
                Write("請輸入姓名： ");
                name = ReadLine();
                Write("請輸入成績： ");
                score = int.Parse(ReadLine());
                list.Insert(num, name, score);
                WriteLine("-------------");
            }
            WriteLine(" 學 生 成 績 ");
            WriteLine(" 座號  姓名 成績 ===========");
            list.Print();
            ReadKey();
        }
    }
}
