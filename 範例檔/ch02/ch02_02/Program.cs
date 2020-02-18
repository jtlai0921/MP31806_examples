using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch02_02
{
    class Program
    {
        static void Main(string[] args)
        {
            //變數宣告
            int intCreate = 1000000;//產生亂數次數
            Random Rand = new Random();   //產生的亂數號碼
            int[][] intArray = new int[2][];//置放亂數陣列
            intArray[0] = new int[42];
            intArray[1] = new int[42];
            //將產生的亂數存放至陣列
            int intRand;
            while (intCreate-- > 0)
            {
                intRand = Rand.Next(42);
                intArray[0][intRand]++;
                intArray[1][intRand]++;
            }
            //對intArray[0]陣列做排序
            Array.Sort(intArray[0]);
            //找出最大數六個數字號碼
            for (int i = 41; i > (41 - 6); i--)
            {
                //逐一檢查次數相同者
                for (int j = 41; j >= 0; j--)
                {
                    //當次數符合時印出
                    if (intArray[0][i] == intArray[1][j])
                    {
                        WriteLine($"亂數號碼 {j + 1} 出現 {intArray[0][i] } 次");
                        intArray[1][j] = 0; //將找到的數值將次數歸零
                        break;  //中斷內迴圈，繼續外迴圈
                    }
                }
            }
            ReadKey();
        }
    }
}
