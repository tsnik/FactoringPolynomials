using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace FactoringLib
{
    public class Test
    {
        #region Коснтанты
        const int MAX_FACTOR_DEGREE = 4;
        #endregion

        #region Поля
        private int _p;
        private int _n;
        private List<Polynomial> _simpleFactors;
        private FiniteField _f;
        private Random _gen;
        #endregion

        public Test(int p, int n)
        {
            _gen = new Random();
            _f = new FiniteField(p, n);
            _simpleFactors = new List<Polynomial>();
            _p = p;
            _n = n;
        }

        #region Нераслагаемые полиномы
        public void InitSimpleFactors()
        {
            string filename = @"SimpleFactors" + _p.ToString() + "," + Math.Min(MAX_FACTOR_DEGREE, _n / 2).ToString() + ".txt";
            if (File.Exists(filename))
            {
                ReadSimpleFactorsFromFile(filename);
                return;
            }
            FindSimpleFactors();
            WriteSimpleFactorsToFile(filename);
        }

        public void FindSimpleFactors()
        {
            int[] a = GenNextPolynomial(null, Math.Min(MAX_FACTOR_DEGREE, _n / 2));
            while (a != null)
            {
                Polynomial p = new Polynomial((int[])a.Clone());
                a = GenNextPolynomial(a);
                if (p.Degree == 0)
                    continue;

                if (_f.ChechIrreducibility(p))
                {
                    _simpleFactors.Add(p);
                }
            }
            _simpleFactors.Sort();
        }

        public void ReadSimpleFactorsFromFile(string filename)
        {
            _simpleFactors.Clear();
            StreamReader file = new StreamReader(filename);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                _simpleFactors.Add(Polynomial.Parse(line));
            }
            file.Close();
        }

        public void WriteSimpleFactorsToFile(string filename)
        {
            StreamWriter file = new StreamWriter(filename);
            foreach (Polynomial p in _simpleFactors)
            {
                file.WriteLine(p.ToString());
            }
            file.Flush();
            file.Close();
        }
        #endregion

        #region Неразлагаемый образующий полином для поля
        public Polynomial Divisor
        {
            set
            {
                if (!CheckDivisor(value))
                {
                    throw new FormatException();
                }
                _f.SimplePoly = value;
            }
            get
            {
                return _f.SimplePoly;
            }
        }

        public void SetDivisor()
        {

            int[] k = new int[_n + 1];
            k[_n] = 1;
            int j = 0;
            while (true)
            {
                Polynomial p = new Polynomial(k);
                if (CheckDivisor(p))
                {
                    _f.SimplePoly = p;
                    break;
                }
                do
                {
                    k[j] = (k[j] + 1) % _p;
                    j++;
                }
                while (k[j - 1] == 0);
                j = 0;
            }
        }

        public bool CheckDivisor(Polynomial p)
        {
            if (p == null || p.Degree != _n)
                return false;
            /*FactoredPolynomial fp = _f.Factor(p);
            return fp.Length == 2 && fp[1].Count == 1 && fp[1][0].Degree > 0;*/
            return _f.ChechIrreducibility(p);
        }

        public void InitDivisor()
        {
            string filename = @"Divisor" + _p.ToString() + "," + _n.ToString() + ".txt";
            if (File.Exists(filename))
            {
                ReadDivisorFromFile(filename);
                return;
            }
            SetDivisor();
            WriteDivisorToFile(filename);
        }

        public void ReadDivisorFromFile(string filename)
        {
            StreamReader file = new StreamReader(filename);
            string line = file.ReadLine();
            Polynomial p = Polynomial.Parse(line);
            _f.SimplePoly = p;
            file.Close();
        }

        public void WriteDivisorToFile(string filename)
        {
            StreamWriter file = new StreamWriter(filename);
            file.WriteLine(_f.SimplePoly.ToString());
            file.Flush();
            file.Close();
        }
        #endregion

        public int[] GenNextPolynomial(int[] ba, int n = 1)
        {
            if (ba == null)
            {
                int[] sba = new int[n + 1];
                sba[0] = 1;
                return sba;

            }
            int[] nba = (int[])ba.Clone();
            int j = 0;
            do
            {
                if (j == ba.Length)
                    return null;
                nba[j] = (ba[j] + 1) % _p;
                j++;
            }
            while (nba[j - 1] == 0);
            j = 0;
            return nba;
        }


        #region Подготовка к тесту
        public FactoredPolynomial GenFactoredP()
        {
            FactoredPolynomial fp = new FactoredPolynomial();
            int d = 0;
            while (d < _n - 1)
            {
                Polynomial p = _simpleFactors[_gen.Next(_simpleFactors.Count)];
                int k = _gen.Next(1, 4);
                while (p.Degree > MAX_FACTOR_DEGREE || !p.Monic || d + p.Degree * k > _n - 1)
                {
                    k = _gen.Next(1, 4);
                    p = _simpleFactors[_gen.Next(_simpleFactors.Count)];
                }
                d += p.Degree * k;
                fp.AddFactor(p, k);
            }
            return fp;
        }

        public Polynomial OpenBraces(FactoredPolynomial p)
        {
            if (p.ToString() == "0")
            {
                return new Polynomial(0);
            }
            Polynomial po = new Polynomial(1);
            for (int i = 0; i < p.Length; i++)
            {
                for (int j = 0; j < p[i].Count; j++)
                {
                    for (int k = 0; k < i || (i == 0 && k == 0); k++)
                    {
                        po = _f.Multiply(po, p[i][j]);
                    }
                }
            }
            return po;
        }
        #endregion

        #region Запуск тестов
        public TestInfo Run()
        {
            return Run(GenFactoredP(), true);
        }

        public TestInfo Run(FactoredPolynomial c, bool check = false)
        {
            Polynomial controlp = OpenBraces(c);
            if (controlp.Degree == 0)
                return Run();
            string ps = controlp.ToString();
            Polynomial parsedP = Polynomial.Parse(ps);
            FactoredPolynomial SquareFree;
            FactoredPolynomial factoredP = _f.Factor(parsedP, out SquareFree);
            Polynomial res = OpenBraces(factoredP);
            TestInfo inf = new TestInfo(c, controlp, factoredP, res, SquareFree, res == controlp, check);
            return inf;
        }
        #endregion

    }
}
