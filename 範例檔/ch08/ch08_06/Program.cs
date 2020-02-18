using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch08_06
{
    class Program
    {
        static int process = 0;
        static int size;
        static int[] data = new int[100];

        static void Main(string[] args)
        {
            Write("請輸入陣列大小(100以下)：");
            size = int.Parse(ReadLine());
            Inputarr();
            Write("原始資料是：");
            Showdata();

            Quick(data, size, 0, size - 1);
            Write("\n排序結果：");
            Showdata();
            ReadKey();
        }
        static void Inputarr()
        {
            //以亂數輸入
            Random rand = new Random();
            int i;
            for (i = 0; i < size; i++)
                data[i] = (Math.Abs(rand.Next(99))) + 1;
        }

        static void Showdata()
        {
            int i;
            for (i = 0; i < size; i++)
                Write(data[i] + " ");
            WriteLine();
        }

        static void Quick(int[] d, int size, int lf, int rg)
        {
            int i, j, tmp;
            int lf_idx;
            int rg_idx;
            int t;
            //1:第一筆鍵值為d[lf]
            if (lf < rg)
            {
                lf_idx = lf + 1;
                rg_idx = rg;

                //排序
                while (true)
                {
                    Write("[處理過程" + (process++) + "]=> ");
                    for (t = 0; t < size; t++)
                        Write("[" + d[t] + "] ");

                    Write("\n");

                    for (i = lf + 1; i <= rg; i++)  //2:由左向右找出一個鍵值大於d[lf]者
                    {
                        if (d[i] >= d[lf])
                        {
                            lf_idx = i;
                            break;
                        }
                        lf_idx++;
                    }

                    for (j = rg; j >= lf + 1; j--)   //3:由右向左找出一個鍵值小於d[lf]者
                    {
                        if (d[j] <= d[lf])
                        {
                            rg_idx = j;
                            break;
                        }
                        rg_idx--;
                    }

                    if (lf_idx < rg_idx)       //4-1:若lf_idx<rg_idx
                    {
                        tmp = d[lf_idx];
                        d[lf_idx] = d[rg_idx]; //則d[lf_idx]和d[rg_idx]互換
                        d[rg_idx] = tmp;       //然後繼續排序	
                    }
                    else
                    {
                        break; //否則跳出排序過程
                    }
                }

                //整理
                if (lf_idx >= rg_idx)     //5-1:若lf_idx大於等於rg_idx
                {                         //則將d[lf]和d[rg_idx]互換
                    tmp = d[lf];
                    d[lf] = d[rg_idx];
                    d[rg_idx] = tmp;
                    //5-2:並以rg_idx為基準點分成左右兩半
                    Quick(d, size, lf, rg_idx - 1); //以遞迴方式分別為左右兩半進行排序
                    Quick(d, size, rg_idx + 1, rg); //直至完成排序
                }
            }
        }
    }
}
