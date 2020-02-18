using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch09_04
{
    class Program
    {
        const int INDEXBOX = 10;   //雜湊表最大元素
        const int MAXNUM = 7;      //最大資料個數

        static void Main(string[] args)
        {
            int i;
            int[] index = new int[INDEXBOX];
            int[] data = new int[MAXNUM];
            Random rand = new Random();
            WriteLine("原始陣列值：");
            for (i = 0; i < MAXNUM; i++) //起始資料值
                data[i] = rand.Next(20) + 1;
            for (i = 0; i < INDEXBOX; i++)//清除雜湊表
                index[i] = -1;
            Print_data(data, MAXNUM);    //列印起始資料
            WriteLine("雜湊表內容：");
            for (i = 0; i < MAXNUM; i++) //建立雜湊表
            {
                Creat_table(data[i], index);
                Write("  " + data[i] + " =>");//列印單一元素的雜湊表位置
                Print_data(index, INDEXBOX);
            }
            WriteLine("完成雜湊表：");
            Print_data(index, INDEXBOX);//列印最後完成結果
            ReadKey();
        }
        public static void Print_data(int[] data, int max) //列印陣列副程式
        {
            int i;
            Write("\t");
            for (i = 0; i < max; i++)
                Write("[" + data[i] + "] ");
            WriteLine();
        }
        public static void Creat_table(int num, int[] index)  //建立雜湊表副程式
        {
            int tmp;
            tmp = num % INDEXBOX;  //雜湊函數=資料%INDEXBOX
            while (true)
            {
                if (index[tmp] == -1)  //如果資料對應的位置是空的
                {
                    index[tmp] = num;  //則直接存入資料
                    break;
                }
                else
                    tmp = (tmp + 1) % INDEXBOX; //否則往後找位置存放
            }
        }
    }
}
