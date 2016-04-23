using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoringPolinomials
{
    delegate Polynomial MultiplyFunc(Polynomial p1, Polynomial p2);
    class FactoredPolynomial
    {
        private List<Polynomial>[] _factors;

        public FactoredPolynomial()
        {
            _factors = new List<Polynomial>[0];
        }

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

        public int Length
        {
            get
            {
                return _factors.Length;
            }
        }

        public void AddFactor(Polynomial p, int degree)
        {
            this[degree].Add(p);
        }

        public void AddFactors(FactoredPolynomial p, MultiplyFunc mult)
        {
            for (int i = 0; i < p.Length; i++)
            {
                this[i].AddRange(p[i]);
            }
        }

        public void Pow(int a)
        {
            for (int i = _factors.Length - 1; i >= 0; i--)
            {
                this[i * a].AddRange(this[i]);
                _factors[i] = new List<Polynomial>();
            }
        }

        public override string ToString()
        {
            string s = "";
            for (int i = this.Length - 1; i > 0; i--)
            {
                string tmps = "";
                _factors[i].Sort();
                foreach (Polynomial p in _factors[i])
                {
                    if (p.ToString()!="1")
                    {
                    tmps += "(" + p.ToString() + ")";
                    if (i != 1)
                        tmps += "^" + i.ToString();
                    }
                }
                s += tmps;
            }
            return s;
        }

        public static bool operator ==(FactoredPolynomial f1, FactoredPolynomial f2)
        {
            return f1.ToString() == f2.ToString();
        }

        public static bool operator !=(FactoredPolynomial f1, FactoredPolynomial f2)
        {
            return f1.ToString() != f2.ToString();
        }

    }
}
