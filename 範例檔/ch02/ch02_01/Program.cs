using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch02_01
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAX = 300;
            //false為質數,true為非質數
            //宣告後若沒有給定初值,其預設值為false
            bool[] prime = new bool[MAX];
            prime[0] = true;//0為非質數
            prime[1] = true;//1為非質數
            int num = 2, i;
            //將1~MAX中不是質數者,逐一過濾掉,以此方式找到所有質數
            while (num < MAX)
            {
                if (!prime[num])
                {
                    for (i = num + num; i < MAX; i += num)
                    {
                        if (prime[i]) continue;
                        prime[i] = true;//設定為true,代表此數為非質數
                    }
                }
                num++;
            }
            //列印1~MAX間的所有質數
            WriteLine($"1到 {MAX} 間的所有質數:");
            for (i = 2, num = 0; i < MAX; i++)
            {
                if (!prime[i])
                {
                    Write(i + "\t");
                    num++;
                }
            }
            WriteLine("\n質數總數= " + num + "個");
            ReadKey();
        }
    }
}
