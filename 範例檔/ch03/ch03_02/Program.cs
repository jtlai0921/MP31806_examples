using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch03_02
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

    public class StuLinkedList
    {
        public Node first;
        public Node last;
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

        public void Delete(Node delNode)
        {
            Node newNode;
            Node tmp;
            if (first.data == delNode.data)
            {
                first = first.next;
            }
            else if (last.data == delNode.data)
            {
                newNode = first;
                while (newNode.next != last) newNode = newNode.next;
                newNode.next = last.next;
                last = newNode;
            }
            else
            {
                newNode = first;
                tmp = first;
                while (newNode.data != delNode.data)
                {
                    tmp = newNode;
                    newNode = newNode.next;
                }
                tmp.next = delNode.next;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            StuLinkedList list = new StuLinkedList();
            int i, j, findword = 0;
            int[,] data = new int[12, 10];
            String[] name = new String[] { "Allen", "Scott",
                "Marry", "Jon", "Mark", "Ricky", "Lisa",
                "Jasica", "Hanson", "Amy", "Bob", "Jack" };
            WriteLine("座號成績座號成績座號成績座號成績\n ");
            for (i = 0; i < 12; i++)
            {
                data[i, 0] = i + 1;
                data[i, 1] = (Math.Abs(rand.Next(50))) + 50;
                list.Insert(data[i, 0], name[i], data[i, 1]);
            }
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 4; j++)
                    Write("[" + data[j * 3 + i, 0] + "]  [" + data[j * 3 + i, 1] + "]  ");
                WriteLine();
            }
            while (true)
            {
                Write("請輸入要刪除成績的座號，結束輸入-1： ");
                findword = int.Parse(ReadLine());
                if (findword == -1)
                    break;
                else
                {
                    Node current = new Node(list.first.data, list.first.names, list.first.np);
                    current.next = list.first.next;
                    while (current.data != findword) current = current.next;
                    list.Delete(current);
                }
                WriteLine("刪除後成績串列，請注意！要刪除的成績其座號必須在此串列中\n");
                list.Print();           
            }
            ReadKey();
        }
    }
}
