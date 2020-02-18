using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch07_03
{
    class Node
    {
        public int x;
        public Node next;
        public Node(int x)
        {
            this.x = x;
            this.next = null;
        }
    }
    class GraphLink
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
                Write("[" + current.x + "]");
                current = current.next;

            }
            WriteLine();
        }
        public void Insert(int x)
        {
            Node newNode = new Node(x);
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
            int[,] Data = //圖形陣列宣告
			{ {1,2},{2,1},{1,5},{5,1},{2,3},{3,2},{2,4},
		      {4,2},{3,4},{4,3},{3,5},{5,3},{4,5},{5,4} };
		    int DataNum;
            int i, j;
            WriteLine("圖形(a)的鄰接串列內容：");
            GraphLink[] Head = new GraphLink[6];		
		    for (i=1 ; i<6 ; i++ )
		    {
			    Head[i]=new GraphLink();
                Write("頂點"+i+"=>");
			    for(j=0 ; j<14 ;j++)
			    {
				    if(Data[j,0]==i)
				    {
					    DataNum = Data[j,1];
					    Head[i].Insert(DataNum);
                    }
                }
                Head[i].Print();
		    }
            ReadKey();
        }
    }
}
