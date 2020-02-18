using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch07_02
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr=new int[5,5];//宣告矩陣arr
	        int i, j, tmpi, tmpj;
            int[,] data = { { 1, 2 }, { 2, 1 }, { 2, 3 }, 
                            { 2, 4 }, { 4, 3 } }; //圖形各邊的起點值及終點值
	        for (i=0;i<5;i++) //把矩陣清為0
		        for (j=0;j<5;j++)
			        arr[i,j]=0;
	        for (i=0;i<5;i++)  //讀取圖形資料
		        for (j=0;j<5;j++) //填入arr矩陣
		        {  
			        tmpi=data[i,0]; //tmpi為起始頂點
			        tmpj=data[i,1]; //tmpj為終止頂點
			        arr[tmpi,tmpj]=1; //有邊的點填入1
		        }
            Write("有向圖形矩陣：\n");
            for (i = 1; i < 5; i++)
            {
                for (j = 1; j < 5; j++)
                    Write("[" + arr[i,j] + "] "); //列印矩陣內容
                WriteLine();
            }
            ReadKey();
        }
    }
}
