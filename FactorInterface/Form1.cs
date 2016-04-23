using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FactoringLib;

namespace FactorInterface
{
    public partial class Form1 : Form
    {
        private Test _test;
        private FactoredPolynomial _fp;
        public Test Tst
        {
            get
            {
                if (_test == null)
                    InitTest();
                return _test;
            }
        }

        private bool InitTest()
        {
            try
            {
                int p = GetInt(tbP);
                int n = GetInt(tbN);
                _test = new Test(p, n);
                _test.InitSimpleFactors();
                _test.InitDivisor();
                tbDivisor.Text = _test.Divisor.ToString();
                return true;
            }
            catch (FormatException e)
            {
                return false;
            }
        }


        private int GetInt(TextBox tb)
        {
            try
            {
                return int.Parse(tb.Text);
            }
            catch (FormatException e)
            {
                tb.BackColor = Color.Red;
                MessageBox.Show("Допустимы только числовые значения");
                throw;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }


        private void btnGenPoly_Click(object sender, EventArgs e)
        {
            if (Tst == null)
                return;
            _fp = Tst.GenFactoredP();
            tbPoly.Text = Tst.OpenBraces(_fp).ToString();
            tbControlFact.Text = _fp.ToString();
            tbSquareFree.Text = "";
            tbFullFactorization.Text = "";
        }

        private void btnOpenPar_Click(object sender, EventArgs e)
        {
            if (Tst == null)
                return;
            FactoredPolynomial fp = FactoredPolynomial.Parse(tbControlFact.Text);
            tbPoly.Text = Tst.OpenBraces(fp).ToString();
            tbControlFact.Text = fp.ToString();
        }

        private void btnFactorise_Click(object sender, EventArgs e)
        {
            if (Tst == null)
                return;
            FactoredPolynomial fp;
            if (tbControlFact.Text != "")
            {
                fp = FactoredPolynomial.Parse(tbControlFact.Text);
                ShowResult(Tst.Run(fp, true));
                return;
            }
            else
            {
                fp = new FactoredPolynomial();
                fp[1].Add(Polynomial.Parse(tbPoly.Text));
            }
            ShowResult(Tst.Run(fp));
        }

        private void ShowResult(TestInfo inf)
        {
            tbPoly.Text = inf.BaseOpened.ToString();
            tbSquareFree.Text = inf.SquareFree.ToString();
            tbFullFactorization.Text = inf.Factored.ToString();
            if (inf.Check)
            {
                tbControlFact.Text = inf.BaseP.ToString();
                lblEqTitle.Visible = true;
                lblEq.Text = inf.FactorizationIdentity ? "ДА" : "НЕТ";
                lblEq.ForeColor = inf.FactorizationIdentity ? Color.Green : Color.Red;
                lblEq.Visible = true;
            }
        }


        private void tbControlFact_TextChanged(object sender, EventArgs e)
        {
            lblEq.Visible = false;
            lblEqTitle.Visible = false;
        }

        private void tbPoly_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbControlFact.Text = "";
            tbSquareFree.Text = "";
            tbFullFactorization.Text = "";
        }

        private void tbControlFact_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbPoly.Text = "";
            tbSquareFree.Text = "";
            tbFullFactorization.Text = "";
        }

        private void btnFindDivisor_Click(object sender, EventArgs e)
        {
            InitTest();
        }

        private void btnSetDivisor_Click(object sender, EventArgs e)
        {
            if (Tst == null)
                return;
            try
            {
                Tst.Divisor = Polynomial.Parse(tbDivisor.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ввведенный полином не является делителем для заданного поле");
            }
        }

        private void tbP_TextChanged(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = SystemColors.Window;
        }
    }
}
