using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch07_04
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
        public bool IsEmpty()
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
    }
    class Program
    {
        public static int[] run = new int[9];
        public static GraphLink[] Head = new GraphLink[9];
        public static void Dfs(int current)  //深度優先走訪副程式
        {
            run[current] = 1;
            Write("[" + current + "]");

            while ((Head[current].first) != null)
            {
                if (run[Head[current].first.x] == 0) //如果頂點尚未走訪，就進行dfs的遞迴呼叫
                    Dfs(Head[current].first.x);
                Head[current].first = Head[current].first.next;
            }
        }
        static void Main(string[] args)
        {
            int[,] Data =		//圖形邊線陣列宣告
			{ {1,2},{2,1},{1,3},{3,1},{2,4},{4,2},{2,5},{5,2},{3,6},{6,3},
		      {3,7},{7,3},{4,5},{5,4},{6,7},{7,6},{5,8},{8,5},{6,8},{8,6} };
		    int DataNum;
            int i, j;
            WriteLine("圖形的鄰接串列內容："); //列印圖形的鄰接串列內容
		    for (i=1 ; i<9 ; i++ ) //共有八個頂點
		    {
			    run[i]=0; //設定所有頂點成尚未走訪過
			    Head[i]=new GraphLink();
                Write("頂點"+i+"=>");
			    for(j=0 ; j<20 ;j++)  //二十條邊線
			    {
				    if(Data[j,0]==i)  //如果起點和串列首相等，則把頂點加入串列
				    {
					    DataNum = Data[j,1];
					    Head[i].Insert(DataNum);
                    }
                }
                Head[i].Print();  //列印圖形的鄰接串列內容
		    }
            WriteLine("深度優先走訪頂點：");  //列印深度優先走訪的頂點
            Dfs(1);
            WriteLine();
            ReadKey();
        }
    }
}
