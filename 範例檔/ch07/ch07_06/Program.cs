using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch07_06
{
    class Node
    {
        const int MaxLength = 20; // 定義鏈結串列最大長度
        public int[] from = new int[MaxLength];
        public int[] to = new int[MaxLength];
        public int[] find = new int[MaxLength];
        public int[] val = new int[MaxLength];
        public int[] Next = new int[MaxLength];// 鏈結串列的下一個節點位置

        public Node()     // Node建構子
        {
            for (int i = 0; i < MaxLength; i++)
                Next[i] = -2;   // -2表示未用節點
        }

        // ---------------------------------------------------
        // 搜尋可用節點位置
        // ---------------------------------------------------	
        public int FindFree()
        {
            int i;

            for (i = 0; i < MaxLength; i++)
                if (Next[i] == -2)
                    break;
            return i;
        }

        // ---------------------------------------------------
        // 建立鏈結串列
        // ---------------------------------------------------		
        public void Create(int Header, int FreeNode, int DataNum, int fromNum, int toNum, int findNum)
        {
            int Pointer;        // 現在的節點位置

            if (Header == FreeNode) // 新的鏈結串列
            {
                val[Header] = DataNum;  // 設定資料編號
                from[Header] = fromNum;
                find[Header] = findNum;
                to[Header] = toNum;
                Next[Header] = -1;  // 將下個節點的位置，-1表示空節點
            }
            else
            {
                Pointer = Header;   // 現在的節點為首節點							
                val[FreeNode] = DataNum;// 設定資料編號
                from[FreeNode] = fromNum;
                find[FreeNode] = findNum;
                to[FreeNode] = toNum;
                // 設定資料名稱
                Next[FreeNode] = -1;    // 將下個節點的位置，-1表示空節點
                                        // 找尋鏈結串列尾端
                while (Next[Pointer] != -1)
                    Pointer = Next[Pointer];

                // 將新節點串連在原串列尾端
                Next[Pointer] = FreeNode;
            }
        }

        // ---------------------------------------------------
        // 印出鏈結串列資料
        // ---------------------------------------------------		
        public void PrintList(int Header)
        {
            int Pointer;
            Pointer = Header;
            while (Pointer != -1)
            {
                Write("起始頂點[" + from[Pointer] + "]  終止頂點[");
                Write(to[Pointer] + "]  路徑長度[" + val[Pointer] + "]");
                WriteLine();
                Pointer = Next[Pointer];
            }
        }
    }
    class Program
    {
        public static int VERTS = 6;
        public static int[] v = new int[VERTS + 1];
        public static Node NewList = new Node();
        public static int Findmincost()
        {
            int minval = 100;
            int retptr = 0;
            int a = 0;
            while (NewList.Next[a] != -1)
            {
                if (NewList.val[a] < minval && NewList.find[a] == 0)
                {
                    minval = NewList.val[a];
                    retptr = a;
                }
                a++;
            }
            NewList.find[retptr] = 1;
            return retptr;
        }
        public static void Mintree()
        {
            int i, result = 0;
            int mceptr;
            int a = 0;
            for (i = 0; i <= VERTS; i++)
                v[i] = 0;
            while (NewList.Next[a] != -1)
            {
                mceptr = Findmincost();
                v[NewList.from[mceptr]]++;
                v[NewList.to[mceptr]]++;
                if (v[NewList.from[mceptr]] > 1 && v[NewList.to[mceptr]] > 1)
                {
                    v[NewList.from[mceptr]]--;
                    v[NewList.to[mceptr]]--;
                    result = 1;
                }
                else
                    result = 0;
                if (result == 0)
                {
                    Write("起始頂點[" + NewList.from[mceptr] + "]  終止頂點[");
                    Write(NewList.to[mceptr] + "]  路徑長度[" + NewList.val[mceptr] + "]");
                    WriteLine();
                }
                a++;
            }
        }
        static void Main(string[] args)
        {
            int[,] Data =			/*圖形陣列宣告*/

			{ {1,2,6},{1,6,12},{1,5,10},{2,3,3},{2,4,5},
		      {2,6,8},{3,4,7},{4,6,11},{4,5,9},{5,6,16} };
		    int DataNum;
            int fromNum;
            int toNum;
            int findNum;
            int Header = 0;
            int FreeNode;
            int i, j;
            WriteLine("建立圖形串列：");
            /*列印圖形的鄰接串列內容*/
		    for (i=0 ; i<10 ; i++ )
		    {
			    for(j=1 ; j<=VERTS ;j++)
			    {
				    if(Data[i,0]==j)
				    {
					    fromNum = Data[i,0];
					    toNum = Data[i,1];
					    DataNum = Data[i,2];
					    findNum=0;
					    FreeNode = NewList.FindFree();
					    NewList.Create(Header, FreeNode, DataNum, fromNum, toNum, findNum);
				    }
                }
		    }				
		    NewList.PrintList(Header);
            WriteLine("建立最小成本擴張樹");
            Mintree();
            ReadKey();
        }
    }
}
