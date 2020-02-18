using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch09_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, val = 1, num;
            int[] data = new int[50];
            String strM;
            Random intRnd = new Random();
            for (i = 0; i < 50; i++)
            {
                data[i] = val;
                val += (intRnd.Next(100) % 5 + 1);

            }
            while (true)
            {
                num = 0;
                Write("請輸入搜尋鍵值(1-" + data[49] + ")，輸入-1結束：");
                strM = ReadLine();
                val = int.Parse(strM);
                if (val == -1)
                    break;
                num = Interpolation(data, val);
                if (num == -1)
                    Write("##### 沒有找到[" + val + "] #####\n");
		        else
                    Write("在第 " + (num + 1) + "個位置找到 [" + data[num] + "]\n");
            }
            WriteLine("資料內容：");
            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < 10; j++)
                    Write((i * 10 + j + 1) + "-" + data[i * 10 + j] + " ");
                WriteLine();
            }
            ReadKey();
        }
        public static int Interpolation(int[] data, int val)
        {
            int low, mid, high;
            low = 0;
            high = 49;
            int tmp;
            Write("搜尋處理中......\n");
            while (low <= high && val != -1)
            {
                tmp = (int)((float)(val - data[low]) * (high - low) / (data[high] - data[low]));
                mid = low + tmp;    //內插法公式
                if (mid > 50 || mid < -1)
                    return -1;
                if (val < data[low] && val < data[high])
                    return -1;
                else if (val > data[low] && val > data[high])
                    return -1;
                if (val == data[mid])
                    return mid;
                else if (val < data[mid])
                {
                    Write(val + " 介於位置 " + (low + 1) + "[" + data[low] + "]及中間值 " + (mid + 1) + "[" + data[mid] + "]，找左半邊\n");
                    high = mid - 1;
                }
                else if (val > data[mid])
                {
                    Write(val + " 介於中間值位置 " + (mid + 1) + "[" + data[mid] + "]及 " + (high + 1) + "[" + data[high] + "]，找右半邊\n");
                    low = mid + 1;
                }
            }
            return -1;
        }
    }
}
