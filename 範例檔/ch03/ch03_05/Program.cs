using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch03_05
{
    class Node
    {
        public int coef;
        public int exp;
        public Node next;
        public Node(int coef, int exp)
        {
            this.coef = coef;
            this.exp = exp;
            this.next = null;
        }
    }
    class PolyLinkedList
    {
        public Node first;
        public Node last;

        public bool IsEmpty()
        {
            return first == null;
        }

        public void Create_link(int coef, int exp)
        {
            Node newNode = new Node(coef, exp);
            if (this.IsEmpty())
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

        public void Print_link()
        {
            Node current = first;
            while (current != null)
            {
                if (current.exp == 1 && current.coef != 0) // X^1時不顯示指數
                    Write(current.coef + "X + ");
			else if (current.exp != 0 && current.coef != 0)
                    Write(current.coef + "X^" + current.exp + " + ");
			else if (current.coef != 0)     // X^0時不顯示變數
                    Write(current.coef);
                current = current.next;
            }
            WriteLine();
        }

        public PolyLinkedList Sum_link(PolyLinkedList b)
        {
            int[] sum = new int[10];
            int i = 0, maxnumber;
            PolyLinkedList tempLinkedList = new PolyLinkedList();
            PolyLinkedList a = new PolyLinkedList();
            int[] tempexp = new int[10];
            Node ptr;
            a = this;
            ptr = b.first;
            while (a.first != null)  //判斷多項式1
            {
                b.first = ptr;       // 重複比較A及B的指數
                while (b.first != null)
                {
                    if (a.first.exp == b.first.exp) //指數相等，係數相加
                    {
                        sum[i] = a.first.coef + b.first.coef;
                        tempexp[i] = a.first.exp;
                        a.first = a.first.next;
                        b.first = b.first.next;
                        i++;
                    }
                    else if (b.first.exp > a.first.exp) //B指數較大，指定係數給C
                    {
                        sum[i] = b.first.coef;
                        tempexp[i] = b.first.exp;
                        b.first = b.first.next;
                        i++;

                    }
                    else if (a.first.exp > b.first.exp) //A指數較大，指定係數給C
                    {
                        sum[i] = a.first.coef;
                        tempexp[i] = a.first.exp;
                        a.first = a.first.next;
                        i++;
                    }
                } // end of inner while loop
            }   // end of outer while loop
            maxnumber = i - 1;
            for (int j = 0; j < maxnumber + 1; j++) tempLinkedList.Create_link(sum[j], maxnumber - j);
            return tempLinkedList;
        } // end of Sum_link
    } // end of class PolyLinkedList 

    class Program
    {
        static void Main(string[] args)
        {
            PolyLinkedList a = new PolyLinkedList();
            PolyLinkedList b = new PolyLinkedList();
            PolyLinkedList c = new PolyLinkedList();

            int[] data1 = { 8, 54, 7, 0, 1, 3, 0, 4, 2 };    //多項式A的係數
            int[] data2 = { -2, 6, 0, 0, 0, 5, 6, 8, 6, 9 }; //多項式B的係數
            Write("原始多項式：\nA=");

            for (int i = 0; i < data1.Length; i++)
                a.Create_link(data1[i], data1.Length - i - 1); //建立多項式A，係數由3遞減

            for (int i = 0; i < data2.Length; i++)
                b.Create_link(data2[i], data2.Length - i - 1); //建立多項式B，係數由3遞減

            a.Print_link();  //列印多項式A
            Write("B=");
            b.Print_link();  //列印多項式B
            Write("多項式相加結果：\nC=");
            c = a.Sum_link(b);  //C為A、B多項式相加結果
            c.Print_link();     //列印多項式C
            ReadKey();
        }
    }
}
