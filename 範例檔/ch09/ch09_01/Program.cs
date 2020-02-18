using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch09_01
{
    class Program
    {
        static void Main(string[] args)
        {
            String strM;
            int[] data = new int[100];
            int i, j, find, val = 0;
            Random intRnd = new Random();
            for (i = 0; i < 80; i++)
                data[i] = (((intRnd.Next(150))) % 150 + 1);
            while (val != -1)
            {
                find = 0;
                Write("請輸入搜尋鍵值(1-150)，輸入-1離開：");
                strM = ReadLine();
                val = int.Parse(strM);
                for (i = 0; i < 80; i++)
                {
                    if (data[i] == val)
                    {
                        Write("在第" + (i + 1) + "個位置找到鍵值 [" + data[i] + "]\n");
                        find++;
                    }
                }
                if (find == 0 && val != -1)
                    Write("######沒有找到 [" + val + "]######\n");
            }
            Write("資料內容：\n");
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 8; j++)
                    Write(i * 8 + j + 1 + "[" + data[i * 8 + j] + "]  ");
                WriteLine();
            }
            ReadKey();
        }
    }
}
