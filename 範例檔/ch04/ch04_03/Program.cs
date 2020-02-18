using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch04_03
{
    class Node //鏈結節點的宣告
    {
        public int data;
        public Node next;
        public Node(int data)
        {
            this.data = data;
            this.next = null;
        }
    }
    class StackByLink
    {
        public Node front; //指向堆疊底端的指標
        public Node rear;  //指向堆疊頂端的指標
        //類別方法：isEmpty()
        //判斷堆疊如果為空堆疊,則front==null;
        public bool IsEmpty()
        {
            return front == null;
        }
        //類別方法：Output_of_Stack()
        //列印堆疊內容
        public void Output_of_Stack()
        {
            Node current = front;
            while (current != null)
            {
                Write("[" + current.data + "]");
                current = current.next;
            }
            WriteLine();
        }
        //類別方法：Insert()
        //在堆疊頂端加入資料
        public void Insert(int data)
        {
            Node newNode = new Node(data);
            if (this.IsEmpty())
            {
                front = newNode;
                rear = newNode;
            }
            else
            {
                rear.next = newNode;
                rear = newNode;
            }
        }
        //類別方法：Pop()
        //在堆疊頂端刪除資料
        public void Pop()
        {
            Node newNode;
            if (this.IsEmpty())
            {
                Write("===目前為空堆疊===\n");
                return;
            }
            newNode = front;
            if (newNode == rear)
            {
                front = null;
                rear = null;
                Write("===目前為空堆疊===\n");
            }
            else
            {
                while (newNode.next != rear)
                    newNode = newNode.next;
                newNode.next = rear.next;
                rear = newNode;
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StackByLink stack_by_linkedlist = new StackByLink();
            int choice = 0;
            while (true)
            {
                Write("(0)結束(1)在堆疊加入資料(2)彈出堆疊資料:");
                choice = int.Parse(ReadLine());
                if (choice == 2)
                {
                    stack_by_linkedlist.Pop();
                    WriteLine("資料彈出後堆疊內容:");
                    stack_by_linkedlist.Output_of_Stack();
                }
                else if (choice == 1)
                {
                    Write("請輸入要加入堆疊的資料:");
                    choice = int.Parse(ReadLine());
                    stack_by_linkedlist.Insert(choice);
                    WriteLine("資料加入後堆疊內容:");
                    stack_by_linkedlist.Output_of_Stack();
                }
                else if (choice == 0)
                    break;
                else
                {
                    WriteLine("輸入錯誤!!");
                }
            }
            ReadKey();
        }
    }
}
