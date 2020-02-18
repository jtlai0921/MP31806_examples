using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch08_02
{
    class Program
    {
        public static int[] data = new int[] { 4, 6, 2, 7, 8, 9 };//原始資料
        static void Main(string[] args)
        {
            WriteLine("改良氣泡排序法\n原始資料為：");
            Showdata();
            Bubble();
            ReadKey();
        }
        public static void Showdata()     //利用迴圈列印資料
        {
            int i;
            for (i = 0; i < data.Length; i++)
            {
                Write(data[i] + " ");
            }
            WriteLine();
        }

        public static void Bubble()
        {
            int i, j, tmp, flag;
            for (i = data.Length-1; i >= 0; i--)
            {
                flag = 0;  //flag用來判斷是否有執行交換的動作
                for (j = 0; j < i; j++)
                {
                    if (data[j + 1] < data[j])
                    {
                        tmp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = tmp;
                        flag++; //如果有執行過交換，則flag不為0
                    }
                }
                if (flag == 0)
                {
                    break;
                }

                //當執行完一次掃描就判斷是否做過交換動作，如果沒有交換過資料
                //，表示此時陣列已完成排序，故可直接跳出迴圈

                Write("第" + (data.Length - i) + "次排序：");
                for (j = 0; j < data.Length; j++)
                {
                    Write(data[j] + " ");
                }
                WriteLine();
            }

            Write("排序後結果為：");
            Showdata();
        }
    }
}
