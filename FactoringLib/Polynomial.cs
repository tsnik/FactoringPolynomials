using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FactoringLib
{
    public class Polynomial : IComparable<Polynomial>
    {
        #region Поля
        private int[] _ks;
        #endregion

        #region Конструкторы
        /// <summary>
        /// Создает полином заданнной степени
        /// </summary>
        /// <param name="degree">Степень полинома</param>
        /// <param name="ks">Массив коэфициентов</param>
        public Polynomial(int[] ks)
        {
            this._ks = ks;
            Resize();
        }

        /// <summary>
        /// Создает полином нулевой степени с заданным коэфициентом 
        /// </summary>
        /// <param name="a">Коэфициент</param>
        public Polynomial(int a)
            : this(new int[] { a }){}

        /// <summary>
        /// Создает полином по умолчанию, равный нулю
        /// </summary>
        public Polynomial()
            : this(0)
        {
        }
        #endregion

        /// <summary>
        /// i-й коэфициент полинома
        /// </summary>
        /// <param name="i">Индекс коэфициента</param>
        /// <returns></returns>
        public int this[int i]
        {
            get
            {
                if (i >= _ks.Length)
                    return 0;
                return _ks[i];
            }
            set
            {
                if (i >= _ks.Length)
                {
                    Array.Resize<int>(ref _ks, i + 1);
                }
                _ks[i] = value;
                if (i == Degree && value == 0)
                {
                    Resize();
                }
            }
        }

        #region Свойства
        /// <summary>
        /// Является нормализованным
        /// </summary>
        public bool Monic
        {
            get
            {
                return this[Degree] == 1;
            }
        }

        /// <summary>
        /// Cтепень полинома
        /// </summary>
        public int Degree
        {
            get
            {
                return _ks.Length - 1;
                //return _degree;
            }
        }
        #endregion

        /// <summary>
        /// Удаление ведущих коэфициентов и расчет степени
        /// </summary>
        private void Resize()
        {
            int l = Degree;
            while (Degree != 0 && _ks[Degree] == 0)
            {
                l--;
                Array.Resize<int>(ref _ks, l + 1);
            }
        }

        /// <summary>
        /// Возвращает копию полинома
        /// </summary>
        /// <returns>Копия полинома</returns>
        public Polynomial Clone()
        {
            Polynomial p = new Polynomial();
            for (int i = 0; i <= this.Degree; i++)
            {
                p[i] = this[i];
            }
            return p;
        }

        #region Работа со строками
        /// <summary>
        /// Создает полином из строки
        /// </summary>
        /// <param name="s">Строка</param>
        /// <returns>Полином</returns>
        public static Polynomial Parse(String s)
        {
            Regex rg = new Regex(@"(((\+|-)?\d*)x(\^(\d+))?|((\+|-)?\d+))");
            MatchCollection ms = rg.Matches(s);
            int degree = 0;
            int[] ks = new int[1];
            foreach (Match m in ms)
            {
                if (degree == 0)
                {
                    degree = m.Groups[5].Value != "" ? int.Parse(m.Groups[5].Value) : 1; ;
                    ks = new int[degree + 1];
                }
                int td;
                int tk;
                if (m.Groups[6].Value != "")
                {
                    td = 0;
                    tk = int.Parse(m.Groups[6].Value);
                }
                else
                {
                    td = m.Groups[5].Value != "" ? int.Parse(m.Groups[5].Value) : 1;
                    tk = m.Groups[2].Value != "+" && m.Groups[2].Value != "" ? int.Parse(m.Groups[2].Value) : 1;
                }
                ks[td] = tk;
            }
            return new Polynomial(ks);
        }

        public override string ToString()
        {
            //string tmp = "";
            StringBuilder sb = new StringBuilder();
            for (int i = Degree; i >= 0; i--)
            {
                if (this[i] != 0 || Degree == 0)
                {
                    /*tmp += this[i] > 0 ? i != Degree ? "+" : "" : "";
                    tmp += this[i] > 1 || this[i] < 0 || i == 0 ? this[i].ToString() : "";
                    tmp += i != 0 ? "x" : "";
                    tmp += i > 1 ? "^" + i : "";*/
                    sb.Append(this[i] > 0 ? i != Degree ? "+" : "" : "");
                    sb.Append(this[i] > 1 || this[i] < 0 || i == 0 ? this[i].ToString() : "");
                    sb.Append(i != 0 ? "x" : "");
                    sb.Append(i > 1 ? "^" + i : "");
                }
            }
            //return tmp;
            return sb.ToString();
        }
        #endregion

        #region Переопределение операторов
        public static bool operator ==(Polynomial p1, Polynomial p2)
        {
            if(Object.ReferenceEquals(p1, null) || Object.ReferenceEquals(p2, null))
            {
                return Object.ReferenceEquals(p1, p2);
            }
            if (p1.Degree != p2.Degree)
                return false;
            for (int i = 0; i <= p1.Degree; i++)
            {
                if (p1[i] != p2[i])
                    return false;
            }
            return true;
        }

        public static bool operator !=(Polynomial p1, Polynomial p2)
        {
            return !(p1 == p2);
        }

        public int CompareTo(Polynomial p)
        {
            if (Object.ReferenceEquals(p, null))
                return 1;
            if (this.Degree != p.Degree)
                return this.Degree - p.Degree;
            for (int i = p.Degree; i >= 0; i--)
            {
                if (p[i] != this[i])
                    return this[i] - p[i];
            }
            return 0;
        }
        #endregion
    }
}
