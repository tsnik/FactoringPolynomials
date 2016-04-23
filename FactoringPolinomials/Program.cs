using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FactoringLib;

namespace FactoringPolinomials
{
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test(7, 10);
            t.InitSimpleFactors();
            while (true)
            {
               // string s;
                //s = Console.ReadLine();
                //Polynomial p = Polynomial.Parse(s);
                //s = Console.ReadLine();
                //Polynomial p2 = Polynomial.Parse(s);

                //Polynomial p = new Polynomial(6, new int[] { 2, 2, 1, 2, 0, 0, 1 });
                //Polynomial p = new Polynomial(7, new int[] { 1, 3, 0, 2, 2, 0, 3, 1 });
                //Polynomial p = new Polynomial(2, new int[] { 1, 2, 1 });
                /*List<Polynomial> simplp = new List<Polynomial>();
                FiniteField f = new FiniteField(5, 4);
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Polynomial p = new Polynomial(1, new int[] { j, i });
                        List<Polynomial> pl = f.Berlekamp(p);
                        if (pl.Count == 1)
                            simplp.Add(p);
                    }
                }*/
                //FactoredPolynomial fp = f.SquareFreeFactor(p);
                
                //Console.WriteLine(f.GCD(p, p2).ToString());
                //Console.WriteLine(p.ToString());
                //Console.WriteLine(p2.ToString());
                FactoredPolynomial fp = new FactoredPolynomial();
                //Polynomial p = new Polynomial(14, new int[] { 0, 0, 4, 4, 2, 0, 0, 1, 1, 3, 0, 0, 2, 2, 1 });
                //fp[1].Add(new Polynomial(6, new int[] { 1, 8, 10, 8, 1, 8, 1 }));
                //fp[1].Add(p);
                //Polynomial p = new Polynomial(2, new int[] { 2, 2, 1 });
                //fp[5].Add(p);
                //t.OpenBraces(fp);
                Console.WriteLine(t.Run());
                Console.ReadLine();
            }
        }



    }
}