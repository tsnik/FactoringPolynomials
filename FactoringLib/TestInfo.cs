using System;
using System.Collections.Generic;
using System.Text;

namespace FactoringLib
{
    public struct TestInfo
    {
        public FactoredPolynomial BaseP;
        public Polynomial BaseOpened;
        public FactoredPolynomial Factored;
        public Polynomial FactoredOpened;
        public FactoredPolynomial SquareFree;
        public bool FactorizationIdentity;
        public bool Succes;
        public bool Check;

        public TestInfo(FactoredPolynomial basep, Polynomial baseOpened, FactoredPolynomial factored, Polynomial factoredOpened, FactoredPolynomial squareFree,bool result, bool check)
        {
            BaseP = basep;
            BaseOpened = baseOpened;
            Factored = factored;
            FactoredOpened = factoredOpened;
            SquareFree = squareFree;
            Succes = result;
            FactorizationIdentity = BaseP == Factored;
            Check = check;
        }


        public override string ToString()
        {
            string s = "";
            s += "Тестовые данные: " + BaseP.ToString() + "\n";
            s += "Раскрытие скобок: " + BaseOpened.ToString() + "\n";
            s += "Бесквадратная форма" + SquareFree.ToString() + "\n";
            s += "Результат работы алгоритма: " + Factored.ToString() + "\n";
            s += "Раскрытие скобок: " + FactoredOpened.ToString() + "\n";
            s += "Разложения совпадают:" + (FactorizationIdentity ? "ДА" : "НЕТ") + "\n";
            s += "Алгоритм работает верно:" + (Succes ? "ДА" : "НЕТ") + "\n";
            return s;
        }
    }
}
