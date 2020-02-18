using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch03_03
{
    class Node
    {
        public int data;
        public Node next;
        public Node(int data)
        {
            this.data = data;
            this.next = null;
        }
    }

    class LinkedList
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
                Write("[" + current.data + "]");
                current = current.next;
            }
            WriteLine();
        }
        //串接兩個鏈結串列
        public LinkedList Concatenate(LinkedList head1, LinkedList head2)
        {
            LinkedList ptr;
            ptr = head1;
            while (ptr.last.next != null)
                ptr.last = ptr.last.next;
            ptr.last.next = head2.first;
            return head1;
        }
        //插入節點
        public void Insert(Node ptr)
        {
            Node tmp;
            Node newNode;
            if (this.isEmpty())
            {
                first = ptr;
                last = ptr;
            }
            else
            {
                if (ptr.next == first)//插入第一個節點
                {
                    ptr.next = first;
                    first = ptr;
                }
                else
                {
                    if (ptr.next == null)//插入最後一個節點
                    {
                        last.next = ptr;
                        last = ptr;
                    }
                    else//插入中間節點
                    {
                        newNode = first;
                        tmp = first;
                        while (ptr.next != newNode.next)
                        {
                            tmp = newNode;
                            newNode = newNode.next;
                        }
                        tmp.next = ptr;
                        ptr.next = newNode;
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list1 = new LinkedList();
            LinkedList list2 = new LinkedList();
            Node node1 = new Node(5);
            Node node2 = new Node(6);
            list1.Insert(node1);
            list1.Insert(node2);
            Node node3 = new Node(7);
            Node node4 = new Node(8);
            list2.Insert(node3);
            list2.Insert(node4);
            list1.Concatenate(list1, list2);
            list1.Print();
            ReadKey();
        }
    }
}
