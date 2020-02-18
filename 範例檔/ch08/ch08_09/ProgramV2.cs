using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ConsoleApp1
{
   class Program
   {
      static void Main(string[] args)
      {
            String filep = @"D:\C#\ch08\ch08_09\data.txt";
            String filep1 = @"D:\C#\ch08\ch08_09\data1.txt";
            String filep2 = @"D:\C#\ch08\ch08_09\data2.txt";

            //呼叫FileInfo類別建立檔案實體fp, fp1, fp2
            FileInfo fp = new FileInfo(filep);  
         FileInfo fp1 = new FileInfo(filep1);
         FileInfo fp2 = new FileInfo(filep2);       
         
         if (File.Exists(filep) == false)
            WriteLine("開啟主檔失敗");
         else if (File.Exists(filep1) == false)
            WriteLine("開啟資料檔 1 失敗"); //開啟檔案成功時，指標會傳回FILE檔案
         else if (File.Exists(filep2) == false)    //指標，開啟失敗則傳回null值
            WriteLine("開啟資料檔 2 失敗");
         else
         {
            WriteLine("資料排序中......");
            Merge(fp, fp1, fp2);//呼叫方法
            WriteLine("資料處理完成!!");
         }
         using (StreamReader pfile1 = File.OpenText(filep1))
         {
            WriteLine("data1.txt資料內容為：");
            ReadData(pfile1);
         }

         using (StreamReader pfile2 = File.OpenText(filep2))
         {
            WriteLine("data2.txt資料內容為：");
            ReadData(pfile2);
         }

         using (StreamReader srd = File.OpenText(filep))
         {
            WriteLine("排序後data.txt資料內容為：");
            ReadData(srd);
         }
         
         ReadKey();
      }

      //Read()方法只能讀取一個字元
      public static void ReadData(StreamReader sr)
      {
         int pk; char wd;
         while (true)
         {
            pk = sr.Read();
            wd = (char)pk;
            if (pk == -1)
               break;
            Write($"[{wd}]");
         }
         WriteLine();   //換行
      }

      public static void Merge(FileInfo p, FileInfo p1, FileInfo p2)
      {
         char str1, str2;
         int n1, n2; //宣告變數n1，n2暫存資料檔data1及data2內的元素值

         StreamWriter pfile = File.CreateText(p.FullName);
         StreamReader pfile1 = File.OpenText(p1.FullName);
         StreamReader pfile2 = File.OpenText(p2.FullName);
         
         n1 = pfile1.Read();
         n2 = pfile2.Read();
         while (n1 != -1 && n2 != -1)     //判斷是否已到檔尾
         {
            if (n1 <= n2)
            {
               str1 = (char)n1;
               pfile.Write(str1); //如果n1比較小，則把n1存到fp裡
               n1 = pfile1.Read();  //接著讀下一筆 n1 的資料
            }
            else
            {
               str2 = (char)n2;
               pfile.Write(str2); //如果n2比較小，則把n2存到fp裡
               n2 = pfile2.Read();  //接著讀下一筆 n2的資料
            }
         }
         if (n2 != -1)
         {
            while (true)
            {
               if (n2 == -1)
                  break;
               str2 = (char)n2;
               pfile.Write(str2);
               n2 = pfile2.Read();
            }
         }
         else if (n1 != -1)
         {
            while (true)
            {
               if (n1 == -1)
                  break;
               str1 = (char)n1;
               pfile.Write(str1);
               n1 = pfile1.Read();
            }
         }
         pfile.Close();
         pfile1.Close();
         pfile2.Close();
      }
   }
}