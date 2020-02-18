using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;//滙入靜態類別

namespace ch02_10
{
    class Program
    {
        static int ITEMS = 6;
        static void Main(string[] args)
        {
            int[] PolyA = { 4, 3, 7, 0, 6, 2 }; //宣告多項式A
            int[] PolyB = { 4, 1, 5, 2, 0, 9 }; //宣告多項式B
            Write("多項式A=> ");
            PrintPoly(PolyA, ITEMS);   //印出多項式A
            Write("多項式B=> ");
            PrintPoly(PolyB, ITEMS);   //印出多項式B
            Write("A+B => ");
            PolySum(PolyA, PolyB);     //多項式A+多項式B
            ReadKey();
        }

        static void PrintPoly(int[] Poly, int items)
        {
            int i, MaxExp;
            MaxExp = Poly[0];
            for (i = 1; i <= Poly[0] + 1; i++)
            {
                MaxExp--;
                if (Poly[i] != 0)       //如果該項式0就跳過
                {
                    if ((MaxExp + 1) != 0)
                        Write(Poly[i] + "X^" + (MaxExp + 1));
			else
                        Write(Poly[i]);
                    if (MaxExp >= 0)
                        Write('+');
                }
            }
            WriteLine();
        }

        static void PolySum(int[] Poly1, int[] Poly2)
        {
            int i;
            int[] result = new int[ITEMS];
            result[0] = Poly1[0];
            for (i = 1; i <= Poly1[0] + 1; i++)
                result[i] = Poly1[i] + Poly2[i]; //等羃的係數相加
            PrintPoly(result, ITEMS);
        }
    }
}
