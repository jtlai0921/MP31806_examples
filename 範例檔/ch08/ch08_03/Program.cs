using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch08_03
{
    class Program
    {
        public static int[] data = new int[] { 9, 7, 5, 3, 4, 6 };
        static void Main(string[] args)
        {
            Write("原始資料為：");
            Showdata();
            Select();
            ReadKey();
        }

        static void Showdata()
        {
            int i;
            for (i = 0; i < 6; i++)
            {
                Write(data[i] + " ");
            }
            WriteLine();
        }
  
        static void Select()
        {
            int i, j, tmp, k;
            for (i = 0; i < 5; i++)         //掃描5次
            {
                for (j = i + 1; j < 6; j++)  //由i+1比較起，比較5次
                {
                    if (data[i] > data[j])  //比較第i及第j個元素
                    {
                        tmp = data[i];
                        data[i] = data[j];
                        data[j] = tmp;
                    }
                }
                Write("第" + (i + 1) + "次排序結果：");
                for (k = 0; k < 6; k++)
                {
                    Write(data[k] + " ");  //列印排序結果
                }
                WriteLine();
            }
        }
    }
}
