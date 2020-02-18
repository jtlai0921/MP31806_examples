using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch02_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] num={{{33,45,67},
                     {23,71,56},
                     {55,38,66}},
                     {{21,9,15 },
                     {38,69,18},
                     {90,101,89}}};//宣告三維陣列 
            int min = num[0,0,0];//設定main為num陣列的第一個元素 
    
            for(int i=0;i<2;i++)
                for(int j=0;j<3;j++)    
                    for(int k=0;k<3;k++)   
                        if(min>=num[i,j,k])
                            min=num[i,j,k]; //利用三層迴圈找出最小值 
    
           Write("最小值= "+min+'\n');
           ReadKey();
        }
    }
}
