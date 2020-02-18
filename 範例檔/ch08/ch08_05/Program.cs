using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch08_05
{
    class Program
    {
        static int[] data = new int[8];
        static int size = 8;

        static void Main(string[] args)
        {
            Inputarr();
            Write("您輸入的原始陣列是：");
            Showdata();
            Shell();
            ReadKey();
        }

        static void Inputarr()
        {
            int i = 0;
            for (i = 0; i < size; i++)
            {
                Write("請輸入第" + (i + 1) + "個元素：");
                try
                {
                    data[i] = int.Parse(ReadLine());
                }
                catch (Exception e) { }
            }
        }

        static void Showdata()
        {
            int i = 0;
            for (i = 0; i < size; i++)
            {
                Write(data[i] + " ");
            }
            WriteLine();
        }

        static void Shell()
        {
            int i;        //i為掃描次數
            int j;        //以j來定位比較的元素
            int k = 1;    //k列印計數
            int tmp;      //tmp用來暫存資料
            int jmp;      //設定間距位移量
            jmp = size / 2;
            while (jmp != 0)
            {
                for (i = jmp; i < size; i++)
                {
                    tmp = data[i];
                    j = i - jmp;
                    while (j >= 0 && tmp < data[j]) 
                        //插入排序法
                    {
                        data[j + jmp] = data[j];
                        j = j - jmp;
                    }
                    data[jmp + j] = tmp;
                }

                Write("第" + (k++) + "次排序：");
                Showdata();
                jmp = jmp / 2; //控制迴圈數
            }
        }
    }
}
