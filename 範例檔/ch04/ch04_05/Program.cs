using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch04_05
{
    public class Node
    {
        public int x;
        public int y;
        public Node next;
        public Node(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.next = null;
        }
    }
    public class TraceRecord
    {
        public Node first;
        public Node last;
        public bool IsEmpty()
        {
            return first == null;
        }
        public void Insert(int x, int y)
        {
            Node newNode = new Node(x, y);
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

        public void Delete()
        {
            Node newNode;
            if (this.IsEmpty())
            {
                Write("[佇列已經空了]\n");
                return;
            }
            newNode = first;
            while (newNode.next != last)
                newNode = newNode.next;
            newNode.next = last.next;
            last = newNode;

        }
    }
    class Program
    {
        public static int ExitX = 8; //定義出口的X座標在第八列
        public static int ExitY = 10;  //定義出口的Y座標在第十行
        public static int[,] MAZE = {{1,1,1,1,1,1,1,1,1,1,1,1},	//宣告迷宮陣列
			  {1,0,0,0,1,1,1,1,1,1,1,1},
                  {1,1,1,0,1,1,0,0,0,0,1,1},
                  {1,1,1,0,1,1,0,1,1,0,1,1},
                  {1,1,1,0,0,0,0,1,1,0,1,1},
                                  {1,1,1,0,1,1,0,1,1,0,1,1},
                  {1,1,1,0,1,1,0,1,1,0,1,1},
                  {1,1,1,1,1,1,0,1,1,0,1,1},
                      {1,1,0,0,0,0,0,0,1,0,0,1},
                      {1,1,1,1,1,1,1,1,1,1,1,1}};
        static void Main(string[] args)
        {
            int i, j, x, y;
            TraceRecord path = new TraceRecord();
            x = 1;
            y = 1;
            Write("[迷宮的路徑(0的部分)]\n");
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 12; j++)
                    Write(MAZE[i,j]);
                Write("\n");
            }
            while (x <= ExitX && y <= ExitY)
            {
                MAZE[x,y] = 2;
                if (MAZE[x - 1,y] == 0)
                {
                    x -= 1;
                    path.Insert(x, y);
                }
                else if (MAZE[x + 1,y] == 0)
                {
                    x += 1;
                    path.Insert(x, y);
                }
                else if (MAZE[x,y - 1] == 0)
                {
                    y -= 1;
                    path.Insert(x, y);
                }
                else if (MAZE[x,y + 1] == 0)
                {
                    y += 1;
                    path.Insert(x, y);
                }
                else if (ChkExit(x, y, ExitX, ExitY) == 1)
                    break;
                else
                {
                    MAZE[x,y] = 2;
                    path.Delete();
                    x = path.last.x;
                    y = path.last.y;
                }
            }
            Write("[老鼠走過的路徑(2的部分)]\n");
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 12; j++)
                    Write(MAZE[i,j]);
                WriteLine();
            }
            ReadKey();
        }
        public static int ChkExit(int x, int y, int ex, int ey)
        {
            if (x == ex && y == ey)
            {
                if (MAZE[x - 1,y] == 1 || MAZE[x + 1,y] == 1 || MAZE[x,y - 1] == 1 || MAZE[x,y + 1] == 2)
                    return 1;
                if (MAZE[x - 1,y] == 1 || MAZE[x + 1,y] == 1 || MAZE[x,y - 1] == 2 || MAZE[x,y + 1] == 1)
                    return 1;
                if (MAZE[x - 1,y] == 1 || MAZE[x + 1,y] == 2 || MAZE[x,y - 1] == 1 || MAZE[x,y + 1] == 1)
                    return 1;
                if (MAZE[x - 1,y] == 2 || MAZE[x + 1,y] == 1 || MAZE[x,y - 1] == 1 || MAZE[x,y + 1] == 1)
                    return 1;
            }
            return 0;
        }
    }
}
