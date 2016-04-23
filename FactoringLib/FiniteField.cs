using System;
using System.Collections.Generic;
using System.Text;

namespace FactoringLib
{
    /// <summary>
    /// Конечное поле
    /// </summary>
    public class FiniteField
    {

        #region Поля
        private int _p;
        private long _q;
        private int _n;
        private Polynomial _simplePoly;
        #endregion

        /// <summary>
        /// Создание конечного поля по заданным p и n
        /// </summary>
        /// <param name="p">Характеристика поля</param>
        /// <param name="n">Степень характеристики</param>
        public FiniteField(int p, int n)
        {
            _p = p;
            _n = n;
            _q = (long)Math.Pow(p, n);
        }

        #region Свойства
        /// <summary>
        /// Характеристика поля
        /// </summary>
        public int P
        {
            get
            {
                return _p;
            }
        }

        /// <summary>
        /// Мощность поля
        /// </summary>
        public long Q
        {
            get
            {
                return _q;
            }
        }

        /// <summary>
        /// Cтепень n характеристики
        /// </summary>
        public int N
        {
            get
            {
                return _n;
            }
        }

        /// <summary>
        /// Простой полином, образующий поле
        /// </summary>
        public Polynomial SimplePoly
        {
            get
            {
                return _simplePoly;
            }
            set
            {
                _simplePoly = value;
            }
        }
        #endregion

        #region Разложение полинома
        /// <summary>
        /// Разложение полинома на простые множители
        /// </summary>
        /// <param name="f">Полином</param>
        /// <returns>Разложение даннного полинома</returns>
        public FactoredPolynomial Factor(Polynomial f)
        {
            FactoredPolynomial fp;
            return Factor(f, out fp);
        }

        /// <summary>
        /// Разложение полинома на простые множители
        /// </summary>
        /// <param name="f">Полином</param>
        /// <param name="fp">Разложение в бесквадратную форму</param>
        /// <returns>Разложение даннного полинома</returns>
        public FactoredPolynomial Factor(Polynomial f, out FactoredPolynomial fp)
        {
            if (f.Degree < 2)
            {
                FactoredPolynomial sfp = new FactoredPolynomial();
                sfp.AddFactor(f, 1);
                fp = sfp;
                return sfp;
            }
            Polynomial divisor;
            Polynomial f2 = MadeMonic(f, out divisor);
            fp = SquareFreeFactor(f2);
            FactoredPolynomial res = new FactoredPolynomial();
            for (int i = 1; i < fp.Length; i++)
            {
                for (int j = 0; j < fp[i].Count; j++)
                {
                    res[i].AddRange(Berlekamp(fp[i][j]));
                }
            }
            res[0].Add(divisor);
            return res;
        }

        /// <summary>
        /// Полное разложение полинома
        /// </summary>
        /// <param name="f">Полином в бесквадратной форме</param>
        /// <returns>Полное разложение полинома</returns>
        private List<Polynomial> Berlekamp(Polynomial f)
        {
            int[,] Qm = FormQM(f);
            for (int i = 0; i < Qm.GetLength(0); i++)
            {
                Qm[i, i] -= 1;
            }
            Polynomial[] basis = GetBasis(Qm);
            List<Polynomial> res = new List<Polynomial>();
            res.Add(f);
            int r = 1;
            while (res.Count < basis.Length && r < basis.Length)
            {
                List<Polynomial> tmp = new List<Polynomial>();
                foreach (Polynomial p in res)
                {
                    Polynomial t = p;
                    for (int i = 0; i < P; i++)
                    {
                        Polynomial g = GCD(Minus(basis[r], new Polynomial(i)), p);
                        t = DividePolynomials(t, g);
                        if (g.Degree != 0)
                        {
                            tmp.Add(g);
                        }
                    }
                    if (t.Degree != 0)
                    {
                        tmp.Add(t);
                    }
                }
                res = tmp;
                r++;
            }
            return res;
        }

        /// <summary>
        /// Разложение полинома в бесквадратную форму
        /// </summary>
        /// <param name="f">Полином</param>
        /// <returns>Бесквадратное разложение полинома</returns>
        private FactoredPolynomial SquareFreeFactor(Polynomial f)
        {
            FactoredPolynomial F = new FactoredPolynomial();
            int i = 1;
            Polynomial df = Derivative(f);
            if (df.ToString() == "0")
            {
                F = PowP(SquareFreeFactor(GetPRoot(f)));
            }
            else
            {
                Polynomial g = GCD(f, df);
                Polynomial h = DividePolynomials(f, g);
                while (h.ToString() != "1")
                {
                    Polynomial hs = GCD(h, g);
                    Polynomial l = DividePolynomials(h, hs);
                    F.AddFactor(l, i);
                    i++;
                    h = hs;
                    g = DividePolynomials(g, hs);
                }
                if (g.ToString() != "1")
                {
                    g = GetPRoot(g);
                    F.AddFactors(PowP(SquareFreeFactor(g)));
                }
            }
            return F;
        }
        #endregion

        #region Операции над полиномами
        /// <summary>
        /// Сложение полиномов
        /// </summary>
        /// <param name="p1">Первое слагаемое</param>
        /// <param name="p2">Второе слагаемое</param>
        /// <param name="OverField">Проводить операции в поле</param>
        /// <returns>Сумма двух полиномов</returns>
        public Polynomial Summ(Polynomial p1, Polynomial p2, bool OverField = true)
        {
            Polynomial p = new Polynomial();
            int md = Math.Max(p1.Degree, p2.Degree);
            for (int i = md; i >= 0; i--)
            {
                p[i] = (p1[i] + p2[i]);
                if (OverField)
                    p[i] = DivOst(p[i], P);
            }
            return p;
        }

        /// <summary>
        /// Вычитание полиномов
        /// </summary>
        /// <param name="p1">Уменьшаемое</param>
        /// <param name="p2">Вычитаемое</param>
        /// <param name="OverField">Проводить операции в поле</param>
        /// <returns>Разность двух полиномов</returns>
        public Polynomial Minus(Polynomial p1, Polynomial p2, bool OverField = true)
        {
            Polynomial p = new Polynomial();
            int md = Math.Max(p1.Degree, p2.Degree);
            for (int i = md; i >= 0; i--)
            {
                p[i] = (p1[i] - p2[i]);
                if (OverField)
                    p[i] = DivOst((int)p[i], P);
            }
            return p;
        }

        /// <summary>
        /// Делит два полинома с остатком
        /// </summary>
        /// <param name="p1">Делимое</param>
        /// <param name="p2">Делитель</param>
        /// <param name="ost">Остаток</param>
        /// <returns>Результат деления</returns>
        public Polynomial DividePolynomials(Polynomial p1, Polynomial p2, out Polynomial ost)
        {
            ost = p1.Clone();
            if (p2.Degree > p1.Degree)
                return new Polynomial();
            Polynomial res = new Polynomial();
            Polynomial p = new Polynomial();
            while (ost.Degree >= p2.Degree && (ost.Degree != 0 || ost[0] != 0))
            {
                res[ost.Degree - p2.Degree] = Div(ost[ost.Degree], p2[p2.Degree]);
                Polynomial tmp = new Polynomial();
                for (int i = 0; i <= p2.Degree; i++)
                {
                    tmp[i + (ost.Degree - p2.Degree)] = Multiply(p2[i], res[ost.Degree - p2.Degree]);
                }
                ost = Minus(ost, tmp, true);
            }
            return res;
        }

        /// <summary>
        /// Делит два полинома в поле
        /// </summary>
        /// <param name="p1">Делимое</param>
        /// <param name="p2">Делитель</param>
        /// <returns>Результат деления</returns>
        public Polynomial DividePolynomials(Polynomial p1, Polynomial p2)
        {
            Polynomial p;
            return DividePolynomials(p1, p2, out p);
        }

        /// <summary>
        /// Произведение полиномов
        /// </summary>
        /// <param name="p1">Первый множитель</param>
        /// <param name="p2">Второй множитель</param>
        /// <param name="infield">Проводить операции в поле</param>
        /// <returns>Произведение двух полиномов</returns>
        public Polynomial Multiply(Polynomial p1, Polynomial p2, bool infield = true)
        {
            Polynomial p = new Polynomial();
            for (int i = p1.Degree; i >= 0; i--)
            {
                for (int j = p2.Degree; j >= 0; j--)
                {
                    p[i + j] = p[i + j] + p1[i] * p2[j];
                }
            }
            Polynomial res = p;
            if (!Object.ReferenceEquals(_simplePoly, null) && infield)
            {
                DividePolynomials(p, _simplePoly, out res);
            }
            for (int i = 0; i <= res.Degree; i++)
            {
                res[i] = DivOst((int)res[i], P);
            }
            return res;
        }

        /// <summary>
        /// Возведение полинома в степень
        /// </summary>
        /// <param name="p">Полином</param>
        /// <param name="deg">Степень</param>
        /// <returns>Полином в указанной степени</returns>
        public Polynomial Pow(Polynomial p, uint deg)
        {
            Polynomial z = new Polynomial(1);
            for (int i = 0; i < deg; i++)
            {
                z = Multiply(z, p);
            }
            return z;
        }

        /// <summary>
        /// Возведение разложенного полинома в степень p
        /// </summary>
        /// <param name="p">Разложение полинома</param>
        /// <returns>Разложение в степени p</returns>
        public FactoredPolynomial PowP(FactoredPolynomial p)
        {
            p.Pow(P);
            return p;
        }

        /// <summary>
        /// Извлечение корня p-ой степени из полинома
        /// </summary>
        /// <param name="p">Полином</param>
        /// <returns>Корень p-ой степени из введенного полинома</returns>
        private Polynomial GetPRoot(Polynomial p)
        {
            Polynomial np = new Polynomial();
            for (int i = 0; i <= p.Degree / P; i++)
            {
                np[i] = p[i * P];
            }
            return np;
        }

        /// <summary>
        /// Нормализует полином
        /// </summary>
        /// <param name="p">Полином</param>
        /// <param name="divisor">Возвращает значение старшего кожфициента</param>
        /// <returns>Нормализованный полином</returns>
        private Polynomial MadeMonic(Polynomial p, out Polynomial divisor)
        {
            divisor = new Polynomial(p[p.Degree]);
            return DividePolynomials(p, divisor);
        }

        /// <summary>
        /// Находит производную полинома
        /// </summary>
        /// <param name="p">Полином</param>
        /// <returns>Производная полинома</returns>
        public Polynomial Derivative(Polynomial p)
        {
            Polynomial dp = new Polynomial();
            for (int i = p.Degree; i > 0; i--)
            {
                dp[i - 1] = DivOst((int)(p[i] * i), P);
            }
            return dp;
        }
        #endregion

        /// <summary>
        /// Находит наибольший общий делитель двух полиномов
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>НОД двух полиномов</returns>
        public Polynomial GCD(Polynomial p1, Polynomial p2)
        {
            Polynomial a, b;
            if (p1.Degree >= p2.Degree)
            {
                a = p1.Clone();
                b = p2.Clone();
            }
            else
            {
                a = p2.Clone();
                b = p1.Clone();
            }
            if (a.ToString() == "0")
            {
                return b;
            }
            if (b.ToString() == "0")
            {
                return a;
            }
            while (true)
            {
                Polynomial rem;
                for (int i = 0; i <= b.Degree; i++)
                {
                    b[i] = Div(b[i], b[b.Degree]);
                }
                DividePolynomials(a, b, out rem);
                if (rem.Degree == 0 && rem[0] == 0)
                    return b;
                a = b;
                b = rem;
            }
        }

        #region Арифметические операции в поле
        /// <summary>
        /// Остаток от деления
        /// </summary>
        /// <param name="a">Делимое</param>
        /// <param name="b">Делитель</param>
        /// <returns>Остаток от деления</returns>
        public long DivOst(long a, long b)
        {
            long res = a % b;
            res = res < 0 ? res + b : res;
            return res;
        }

        /// <summary>
        /// Остаток от деления
        /// </summary>
        /// <param name="a">Делимое</param>
        /// <param name="b">Делитель</param>
        /// <returns>Остаток от деления</returns>
        public int DivOst(int a, int b)
        {
            return (int)DivOst((long)a, b);
        }

        /// <summary>
        /// Деление чисел в поле
        /// </summary>
        /// <param name="a">Делимое</param>
        /// <param name="b">Делитель</param>
        /// <returns>Частное</returns>
        public int Div(int a, int b)
        {
            for (int i = 0; i < P; i++)
            {
                if ((a + P * i) % b == 0)
                    return (a + P * i) / b;
            }
            return 0;
        }

        /// <summary>
        /// Возведение в степень в поле
        /// </summary>
        /// <param name="a">Число</param>
        /// <param name="b">Степень</param>
        /// <returns>Число в заданной степени</returns>
        public int Pow(long a, long b)
        {
            if (b < 0)
            {
                return Div(1, Pow(a, -b));
            }
            if (b == 0)
                return 1;
            if (b == 1)
                return (int)a;
            int d = Pow(a, b / 2);
            return ((int)Math.Pow(a, b % 2) * d * d) % P;
        }

        /// <summary>
        /// Произведение в поле
        /// </summary>
        /// <param name="a">Первый множитель</param>
        /// <param name="b">Второй множитель</param>
        /// <returns>Произведение</returns>
        public int Multiply(int a, int b)
        {
            return (a * b) % P;
        }
        #endregion


        #region Получение базиса
        /// <summary>
        /// Формирование матрицы Q для заданного полинома
        /// </summary>
        /// <param name="p">Полином</param>
        /// <returns>Матрица</returns>
        public int[,] FormQM(Polynomial p)
        {
            int n = p.Degree;
            int[,] Qm = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                Polynomial s;
                Polynomial tmp = new Polynomial();
                tmp[i * P] = 1;
                DividePolynomials(tmp, p, out s);
                for (int j = 0; j < n; j++)
                {
                    Qm[j, i] = s[j];
                }
            }
            return Qm;
        }

        /// <summary>
        /// Получение набора базисов из матрицы
        /// </summary>
        /// <param name="m">Матрица</param>
        /// <returns>Базисы</returns>
        public int[][] GetBasisM(int[,] m)
        {
            List<int> freev;
            int[][] rm = GetRowEchelonForm(m, out freev);
            int[][] res = new int[freev.Count][];
            int k = 0;
            foreach (int a in freev)
            {
                res[k] = new int[m.GetLength(0)];
                res[k][a] = 1;
                foreach (int b in freev)
                {
                    if (b != a)
                    {
                        res[k][b] = -1;
                    }
                }
                for (int i = 0; i < m.GetLength(0); i++)
                {
                    if (res[k][i] == -1)
                    {
                        res[k][i] = 0;
                        continue;
                    }
                    if (i != a)
                    {
                        res[k][i] = DivOst(-rm[i][a], P);
                    }
                }
                k++;
            }

            return res;
        }

        /// <summary>
        /// Приведение мтрицы к ступенчатому виду
        /// </summary>
        /// <param name="m">Матрица</param>
        /// <param name="freev">Свободные члены</param>
        /// <returns>Матрица в ступенчатом виде</returns>
        public int[][] GetRowEchelonForm(int[,] m, out List<int> freev)
        {
            int[][] nm = new int[m.GetLength(0)][];
            freev = new List<int>();
            for (int i = 0; i < m.GetLength(0); i++)
            {
                nm[i] = new int[m.GetLength(1)];
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    nm[i][j] = m[i, j];
                }
            }
            for (int i = 0; i < nm.Length; i++)
            {
                for (int j = i; j < nm[i].Length; j++)
                {
                    if (nm[j][i] != 0)
                    {
                        SwitchRows(nm, i, j);
                        DivideRow(nm[i], nm[i][i]);
                        for (int k = 0; k < nm.Length; k++)
                        {
                            if (k != i)
                            {
                                AddRow(nm[k], nm[i], -nm[k][i]);
                            }
                        }
                        break;
                    }
                    if (j == nm[i].Length - 1)
                    {
                        freev.Add(i);
                    }
                }
            }
            return nm;
        }

        #region Операции над строками
        /// <summary>
        /// Добавляет к первой строке вторую, умноженную на число
        /// </summary>
        /// <param name="a">Первая строка</param>
        /// <param name="b">Вторая</param>
        /// <param name="multiplier">Множитель</param>
        public void AddRow(int[] a, int[] b, int multiplier)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = DivOst((a[i] + b[i] * multiplier), P);
            }
        }

        /// <summary>
        /// Меняет строки в матрице местами
        /// </summary>
        /// <param name="m">Матрица</param>
        /// <param name="i">Номер 1 строки</param>
        /// <param name="j">Номер 2 строки</param>
        public void SwitchRows(int[][] m, int i, int j)
        {
            int[] tmp = m[i];
            m[i] = m[j];
            m[j] = tmp;
        }

        /// <summary>
        /// Делит строку на число
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="divisor">Делитель</param>
        public void DivideRow(int[] row, int divisor)
        {
            for (int i = 0; i < row.Length; i++)
            {
                row[i] = Div(row[i], divisor);
            }
        }
        #endregion

        /// <summary>
        /// Получение базиса в виде массива полиномов
        /// </summary>
        /// <param name="m">Матрица</param>
        /// <returns>Массив полиномов, представляющий базис</returns>
        public Polynomial[] GetBasis(int[,] m)
        {
            int[][] b = GetBasisM(m);
            Polynomial[] res = new Polynomial[b.Length];
            for (int i = 0; i < b.Length; i++)
            {
                Polynomial tmp = new Polynomial();
                for (int j = 0; j < b[i].Length; j++)
                {
                    tmp[j] = b[i][j];
                }
                res[i] = tmp;
            }
            return res;
        }
        #endregion

        /// <summary>
        /// Проверка полинома на неразлагаемость
        /// </summary>
        /// <param name="p">Полином</param>
        /// <returns>Результат проверки</returns>
        public bool ChechIrreducibility(Polynomial p)
        {
            Polynomial u = new Polynomial(new int[] { 0, 1 });
            for (int i = 1; i <= p.Degree / 2; i++)
            {
                Polynomial tmp;
                DividePolynomials(Pow(u, (uint)P), p, out tmp);
                u = tmp;
                Polynomial d = GCD(p, Minus(u, new Polynomial(new int[] { 0, 1 })));
                if (d.ToString()!="1")
                {
                    return false;
                }
            }
            return true;
        }

    }
}
