﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch04_06
{
    class Program
    {
        static int TRUE = 1, FALSE = 0, EIGHT = 8;
        static int[] queen = new int[EIGHT]; // 存放8個皇后之列位置					
        static int number = 0; //// 計算共有幾組解的總數
                              
        //按Enter鍵函數
        public static void PressEnter()
        {
            char tChar;
            Write("\n\n");
            WriteLine("...按下Enter鍵繼續...");
            tChar = (char)Read();
        }
        //決定皇后存放的位置
        public static void Decide_position(int value)
        {
            int i = 0;
            while (i < EIGHT)
            {
                // 是否受到攻擊的判斷式
                if (Attack(i, value) != 1)
                {
                    queen[value] = i;
                    if (value == 7)
                        Print_table();
                    else
                        Decide_position(value + 1);
                }
                i++;
            }
        }
        // 測試在(row,col)上的皇后是否遭受攻擊
        // 若遭受攻擊則傳回值為1，否則傳回0
        public static int Attack(int row, int col)
        {
            int i = 0, atk = FALSE;
            int offset_row = 0, offset_col = 0;

            while ((atk != 1) && i < col)
            {
                offset_col = Math.Abs(i - col);
                offset_row = Math.Abs(queen[i] - row);
                // 判斷兩皇后是否在同一列或在同一對角線上
                if ((queen[i] == row) || (offset_row == offset_col))
                    atk = TRUE;
                i++;
            }
            return atk;
        }

        // 輸出所需要的結果
        public static void Print_table()
        {
            int x = 0, y = 0;
            number += 1;
            WriteLine();
            Write("八皇后問題的第" + number + "組解\n\t");
            for (x = 0; x < EIGHT; x++)
            {
                for (y = 0; y < EIGHT; y++)
                    if (x == queen[y])
                        Write("<*>");
				else
                        Write("<->");
                Write("\n\t");
            }
            PressEnter();
        }
        static void Main(string[] args)
        {
            number = 0;
            Decide_position(0);
            ReadKey();
        }
    }
}
