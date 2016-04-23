using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FactoringLib
{
    /// <summary>
    /// Разложение полиномов
    /// </summary>
    public class FactoredPolynomial
    {
        #region Поля
        private List<Polynomial>[] _factors;
        #endregion
        
        public FactoredPolynomial()
        {
            _factors = new List<Polynomial>[0];
        }

        #region Свойства
        /// <summary>
        /// Список полиномов заданной степени
        /// </summary>
        /// <param name="i">Степень</param>
        /// <returns>Список полиномов</returns>
        public List<Polynomial> this[int i]
        {
            get
            {
                if (i >= _factors.Length)
                {
                    Array.Resize<List<Polynomial>>(ref _factors, i + 1);
                }
                if (_factors[i] == null)
                {
                    _factors[i] = new List<Polynomial>();
                }
                return _factors[i];
            }
        }

        /// <summary>
        /// Длина массива списков полиномов
        /// </summary>
        public int Length
        {
            get
            {
                return _factors.Length;
            }
        }
        #endregion

        #region Добавление множителей
        /// <summary>
        /// Доавление полинома в заданной степени
        /// </summary>
        /// <param name="p">Полином</param>
        /// <param name="degree">Степень</param>
        public void AddFactor(Polynomial p, int degree)
        {
            for (int i = 1; i < _factors.Length; i++)
            {
                for (int j = 0; j < this[i].Count; j++)
                {
                    if (_factors[i][j] == p)
                    {
                        _factors[i].RemoveAt(j);
                        this[degree + i].Add(p);
                        return;
                    }
                }
            }
            this[degree].Add(p);
        }

        /// <summary>
        /// Добавление разложения полиномов
        /// </summary>
        /// <param name="p">Полином</param>
        public void AddFactors(FactoredPolynomial p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                this[i].AddRange(p[i]);
            }
        }
        #endregion

        /// <summary>
        /// Возведение разложения в степень
        /// </summary>
        /// <param name="a">Степень</param>
        public void Pow(int a)
        {
            for (int i = _factors.Length - 1; i >= 0; i--)
            {
                this[i * a].AddRange(this[i]);
                _factors[i] = new List<Polynomial>();
            }
        }

        #region Работа со строками
        public override string ToString()
        {
            string s = "";
            if (this[0].Count > 0 && this[0][0].ToString() != "1")
            {
                s += this[0][0].ToString();
            }
            for (int i = this.Length - 1; i > 0; i--)
            {
                string tmps = "";
                this[i].Sort();
                foreach (Polynomial p in _factors[i])
                {
                    if (p.ToString() != "1")
                    {
                        tmps += "(" + p.ToString() + ")";
                        if (i != 1)
                            tmps += "^" + i.ToString();
                    }
                }
                s += tmps;
            }
            if (s == "")
            {
                s += "0";
            }
            return s;
        }

        /// <summary>
        /// Получение разложения из строки
        /// </summary>
        /// <param name="s">Строка</param>
        /// <returns>Разложение</returns>
        public static FactoredPolynomial Parse(string s)
        {
            Regex rg = new Regex(@"(^\d+)|(\(.+?\))(\^(\d+))?");
            MatchCollection ms = rg.Matches(s);
            FactoredPolynomial fp = new FactoredPolynomial();
            if (s == "")
            {

            }
            foreach (Match m in ms)
            {
                Polynomial p;
                int d;
                if (m.Groups[1].Value == "")
                {
                    p = Polynomial.Parse(m.Groups[2].Value);
                    d = m.Groups[3].Value == "" ? 1 : int.Parse(m.Groups[4].Value);
                }
                else
                {
                    p = Polynomial.Parse(m.Groups[1].Value);
                    d = 0;
                }
                fp.AddFactor(p, d);
            }
            return fp;
        }
        #endregion

        #region Переопределение операторов
        public static bool operator ==(FactoredPolynomial f1, FactoredPolynomial f2)
        {
            if (Object.ReferenceEquals(f1, null) || Object.ReferenceEquals(f2, null))
            {
                return Object.ReferenceEquals(f1, f2);
            }
            return f1.ToString() == f2.ToString();
        }

        public static bool operator !=(FactoredPolynomial f1, FactoredPolynomial f2)
        {
            if (Object.ReferenceEquals(f1, null) || Object.ReferenceEquals(f2, null))
            {
                return !Object.ReferenceEquals(f1, f2);
            }
            return f1.ToString() != f2.ToString();
        }
        #endregion

    }
}
