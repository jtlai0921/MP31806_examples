using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch08_10
{
    class Program
    {
        static void Main(string[] args)
        {
            String filep = @"D:\C#\ch08\ch08_10\datafile.txt";
            String filep1 = @"D:\C#\ch08\ch08_10\sort1.txt";
            String filep2 = @"D:\C#\ch08\ch08_10\sort2.txt";
            String filepa = @"D:\C#\ch08\ch08_10\sortdata.txt";

            FileInfo fp = new FileInfo(filep);  //宣告檔案指標
            FileInfo fp1 = new FileInfo(filep1);
            FileInfo fp2 = new FileInfo(filep2);
            FileInfo fpa = new FileInfo(filepa);
           
            if (File.Exists(filep) ==false)
                Write("開啟資料檔失敗\n");
            else if (File.Exists(filep1) == false)
                Write("開啟分割檔 1 失敗\n");
            else if (File.Exists(filep2) == false)
                Write("開啟分割檔 2 失敗\n");
            else if (File.Exists(filepa) == false)
                Write("開啟合併檔失敗\n");
            else
            {
                Write("檔案分割中......\n");
                Me(fp, fp1, fp2, fpa);
                Write("資料排序中......\n");
                Write("資料處理完成!!\n");
            }

            Write("原始檔datafile.txt資料內容為：\n");
            Showdata(fp);
            Write("\n分割檔sort1.txt資料內容為：\n");
            Showdata(fp1);
            Write("\n分割檔sort2.txt資料內容為：\n");
            Showdata(fp2);
            Write("\n排序後sortdata.txt資料內容為：\n");
            Showdata(fpa);
            ReadKey();
        }

        public static void Showdata(FileInfo p)
        {
            char str;
            int str1;
            StreamReader pfile = File.OpenText(p.FullName);
                     
		    while (true)
		    {  
			    str1=pfile.Read();		
			    str=(char) str1;		
			    if(str1==-1)
				    break;
			    Write("["+str+"]");
            }
            Write("\n");
        }

        public static void Me(FileInfo p, FileInfo p1, FileInfo p2, FileInfo pa)
        {  
		    char str1,str2;
		    int n1=0,n2,n;

            StreamReader pfile3 = File.OpenText(p.FullName);
            StreamWriter pfile1 = File.CreateText(p1.FullName);
            StreamWriter pfile2 = File.CreateText(p2.FullName);
            StreamWriter pfilea = File.CreateText(pa.FullName);
                    	
		    while(true)
		    {
			    n2=pfile3.Read();
			    if(n2==-1)
				    break;
			    n1++;
		    }
		    pfile3.Close();
            StreamReader pfile = File.OpenText(p.FullName);
             
		    for(n2=0;n2<(n1/2);n2++)
		    {
			    str1=(char) pfile.Read();
                pfile1.Write(str1);
		    }
		    pfile1.Close();
		    Bubble(p1, n2);
		    while(true)
		    {
			    n=pfile.Read();
			    str2=(char) n;
			    if(n==-1)
				    break;
			    pfile2.Write(str2);
		    }
		    pfile2.Close();
		    Bubble(p2, n1/2);
            pfilea.Close();		
		    Merge(pa, p1, p2);
            pfile.Close();		//關閉檔案
	    }
	
	    public static void Bubble(FileInfo p1, int size)
        {  
		    char str1;
		    int[] data =new int[100];
		    int i, j, tmp, flag, ii;
            StreamReader pfile = File.OpenText(p1.FullName);
            
		    for(i=0;i<size;i++)
		    {
			    ii=pfile.Read();
			    if(ii==-1)
				    break;			
			    data[i]=ii;
		    }
		    pfile.Close();      //關閉檔案
            StreamWriter pfile1 = File.CreateText(p1.FullName);
            	
		    for(i=size;i>0;i--)
		    {
			    flag=0;
			    for(j=0;j<i;j++)
			    {
				    if(data[j + 1]<data[j])
				    {
					    tmp=data[j];
					    data[j]=data[j + 1];
					    data[j + 1]=tmp;
					    flag++;
				    }
			    }
			    if(flag==0)
				    break;
		    }
		    for(i=1;i<=size;i++)
		    {
			    str1=(char) data[i];
                pfile1.Write(str1);
		    }
		    pfile1.Close();		//關閉檔案
	    }

	    public static void Merge(FileInfo p, FileInfo p1, FileInfo p2)
        {  
		    char str1,str2;
		    int n1,n2;  //宣告變數n1，n2暫存資料檔data1及data2內的元素值
            StreamWriter pfile = File.CreateText(p.FullName);
            StreamReader pfile1 = File.OpenText(p1.FullName);
            StreamReader pfile2 = File.OpenText(p2.FullName);
            
            n1=pfile1.Read();	
		    n2=pfile2.Read();
		    while(n1!=-1 && n2!=-1)		//判斷是否已到檔尾
		    {  
			    if (n1 <= n2)
			    {  
				    str1=(char) n1;
                    pfile.Write(str1);	//如果n1比較小，則把n1存到fp裡
				    n1=pfile1.Read();	//接著讀下一筆 n1 的資料
			    }
			    else
			    {  
				    str2=(char) n2;
                    pfile.Write(str2);	//如果n1比較小，則把n1存到fp裡
	                n2=pfile2.Read();   //接著讀下一筆 n2的資料
			    }
		    }
		    if(n2!=-1)	//如果其中一個資料檔已讀取完畢，經判斷後
		    { 		//把另一個資料檔內的資料全部放到fp裡
			    while (true)
			    {  
				    if(n2==-1)
					    break;
				    str2=(char) n2;
                    pfile.Write(str2);	
				    n2=pfile2.Read();		
			    }
		    }
		    else if (n1!=-1)
		    { 
			    while (true)
			    {  
				    if(n1==-1)
					    break;
				    str1=(char) n1;
                    pfile.Write(str1);	
				    n1=pfile1.Read();		
			    }
		    }	
		    pfile.Close();
		    pfile1.Close();
		    pfile2.Close();
	    }
    }
}
