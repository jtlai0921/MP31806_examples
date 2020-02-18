using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch06_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, level;
            int[] data = { 6, 3, 5, 9, 7, 8, 4, 2 }; /*原始陣列*/
            int[] btree = new int[16];
            for (i = 0; i < 16; i++) btree[i] = 0;
            Write("原始陣列內容: \n");
            for (i = 0; i < 8; i++)
                Write("[" + data[i] + "] ");
            WriteLine();
            for (i = 0; i < 8; i++)     /*把原始陣列中的值逐一比對*/
            {
                for (level = 1; btree[level] != 0;) /*比較樹根及陣列內的值*/
                {
                    if (data[i] > btree[level]) /*如果陣列內的值大於樹根，則往右子樹比較*/
                        level = level * 2 + 1;
                    else     /*如果陣列內的值小於或等於樹根，則往左子樹比較*/
                        level = level * 2;
                }            /*如果子樹節點的值不為0，則再與陣列內的值比較一次*/
                btree[level] = data[i];  /*把陣列值放入二元樹*/
            }
            Write("二元樹內容：\n");
            for (i = 1; i < 16; i++)
                Write("[" + btree[i] + "] ");
            WriteLine();
            ReadKey();
        }
    }
}
