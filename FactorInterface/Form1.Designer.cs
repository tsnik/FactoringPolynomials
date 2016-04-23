namespace FactorInterface
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbControlFact = new System.Windows.Forms.TextBox();
            this.btnOpenPar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPoly = new System.Windows.Forms.TextBox();
            this.tbSquareFree = new System.Windows.Forms.TextBox();
            this.btnGenPoly = new System.Windows.Forms.Button();
            this.btnFactorise = new System.Windows.Forms.Button();
            this.tbFullFactorization = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblEqTitle = new System.Windows.Forms.Label();
            this.lblEq = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFindDivisor = new System.Windows.Forms.Button();
            this.btnSetDivisor = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbDivisor = new System.Windows.Forms.TextBox();
            this.tbN = new System.Windows.Forms.TextBox();
            this.tbP = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbControlFact
            // 
            this.tbControlFact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbControlFact.Location = new System.Drawing.Point(28, 173);
            this.tbControlFact.Name = "tbControlFact";
            this.tbControlFact.Size = new System.Drawing.Size(243, 20);
            this.tbControlFact.TabIndex = 0;
            this.tbControlFact.TextChanged += new System.EventHandler(this.tbControlFact_TextChanged);
            this.tbControlFact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbControlFact_KeyPress);
            // 
            // btnOpenPar
            // 
            this.btnOpenPar.Location = new System.Drawing.Point(28, 199);
            this.btnOpenPar.Name = "btnOpenPar";
            this.btnOpenPar.Size = new System.Drawing.Size(124, 23);
            this.btnOpenPar.TabIndex = 1;
            this.btnOpenPar.Text = "Раскрыть скобки";
            this.btnOpenPar.UseVisualStyleBackColor = true;
            this.btnOpenPar.Click += new System.EventHandler(this.btnOpenPar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Контрольное разложение";
            // 
            // tbPoly
            // 
            this.tbPoly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPoly.Location = new System.Drawing.Point(28, 234);
            this.tbPoly.Name = "tbPoly";
            this.tbPoly.Size = new System.Drawing.Size(243, 20);
            this.tbPoly.TabIndex = 3;
            this.tbPoly.TextChanged += new System.EventHandler(this.tbControlFact_TextChanged);
            this.tbPoly.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPoly_KeyPress);
            // 
            // tbSquareFree
            // 
            this.tbSquareFree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSquareFree.Location = new System.Drawing.Point(28, 261);
            this.tbSquareFree.Name = "tbSquareFree";
            this.tbSquareFree.ReadOnly = true;
            this.tbSquareFree.Size = new System.Drawing.Size(243, 20);
            this.tbSquareFree.TabIndex = 4;
            // 
            // btnGenPoly
            // 
            this.btnGenPoly.Location = new System.Drawing.Point(28, 332);
            this.btnGenPoly.Name = "btnGenPoly";
            this.btnGenPoly.Size = new System.Drawing.Size(146, 23);
            this.btnGenPoly.TabIndex = 5;
            this.btnGenPoly.Text = "Сгенерировать полином";
            this.btnGenPoly.UseVisualStyleBackColor = true;
            this.btnGenPoly.Click += new System.EventHandler(this.btnGenPoly_Click);
            // 
            // btnFactorise
            // 
            this.btnFactorise.Location = new System.Drawing.Point(180, 332);
            this.btnFactorise.Name = "btnFactorise";
            this.btnFactorise.Size = new System.Drawing.Size(75, 23);
            this.btnFactorise.TabIndex = 6;
            this.btnFactorise.Text = "Разложить";
            this.btnFactorise.UseVisualStyleBackColor = true;
            this.btnFactorise.Click += new System.EventHandler(this.btnFactorise_Click);
            // 
            // tbFullFactorization
            // 
            this.tbFullFactorization.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFullFactorization.Location = new System.Drawing.Point(28, 288);
            this.tbFullFactorization.Name = "tbFullFactorization";
            this.tbFullFactorization.ReadOnly = true;
            this.tbFullFactorization.Size = new System.Drawing.Size(243, 20);
            this.tbFullFactorization.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Полином";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Разложение в бесквадратную форму";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Полное разложение";
            // 
            // lblEqTitle
            // 
            this.lblEqTitle.AutoSize = true;
            this.lblEqTitle.Location = new System.Drawing.Point(28, 313);
            this.lblEqTitle.Name = "lblEqTitle";
            this.lblEqTitle.Size = new System.Drawing.Size(228, 13);
            this.lblEqTitle.TabIndex = 11;
            this.lblEqTitle.Text = "Совпадение с контрольным разложением: ";
            this.lblEqTitle.Visible = false;
            // 
            // lblEq
            // 
            this.lblEq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEq.AutoSize = true;
            this.lblEq.ForeColor = System.Drawing.Color.Green;
            this.lblEq.Location = new System.Drawing.Point(280, 313);
            this.lblEq.Name = "lblEq";
            this.lblEq.Size = new System.Drawing.Size(22, 13);
            this.lblEq.TabIndex = 12;
            this.lblEq.Text = "Да";
            this.lblEq.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFindDivisor);
            this.groupBox1.Controls.Add(this.btnSetDivisor);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbDivisor);
            this.groupBox1.Controls.Add(this.tbN);
            this.groupBox1.Controls.Add(this.tbP);
            this.groupBox1.Location = new System.Drawing.Point(28, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 129);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры поля";
            // 
            // btnFindDivisor
            // 
            this.btnFindDivisor.Location = new System.Drawing.Point(166, 100);
            this.btnFindDivisor.Name = "btnFindDivisor";
            this.btnFindDivisor.Size = new System.Drawing.Size(116, 23);
            this.btnFindDivisor.TabIndex = 7;
            this.btnFindDivisor.Text = "Найти полином";
            this.btnFindDivisor.UseVisualStyleBackColor = true;
            this.btnFindDivisor.Click += new System.EventHandler(this.btnFindDivisor_Click);
            // 
            // btnSetDivisor
            // 
            this.btnSetDivisor.Location = new System.Drawing.Point(7, 101);
            this.btnSetDivisor.Name = "btnSetDivisor";
            this.btnSetDivisor.Size = new System.Drawing.Size(139, 23);
            this.btnSetDivisor.TabIndex = 6;
            this.btnSetDivisor.Text = "Установить полином";
            this.btnSetDivisor.UseVisualStyleBackColor = true;
            this.btnSetDivisor.Click += new System.EventHandler(this.btnSetDivisor_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(135, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Образующий полином";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(135, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Степень n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(135, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Характеристика";
            // 
            // tbDivisor
            // 
            this.tbDivisor.Location = new System.Drawing.Point(7, 74);
            this.tbDivisor.Name = "tbDivisor";
            this.tbDivisor.Size = new System.Drawing.Size(100, 20);
            this.tbDivisor.TabIndex = 2;
            // 
            // tbN
            // 
            this.tbN.Location = new System.Drawing.Point(7, 47);
            this.tbN.Name = "tbN";
            this.tbN.Size = new System.Drawing.Size(100, 20);
            this.tbN.TabIndex = 1;
            this.tbN.Text = "20";
            this.tbN.TextChanged += new System.EventHandler(this.tbP_TextChanged);
            // 
            // tbP
            // 
            this.tbP.Location = new System.Drawing.Point(7, 20);
            this.tbP.Name = "tbP";
            this.tbP.Size = new System.Drawing.Size(100, 20);
            this.tbP.TabIndex = 0;
            this.tbP.Text = "7";
            this.tbP.TextChanged += new System.EventHandler(this.tbP_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 382);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblEq);
            this.Controls.Add(this.lblEqTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFullFactorization);
            this.Controls.Add(this.btnFactorise);
            this.Controls.Add(this.btnGenPoly);
            this.Controls.Add(this.tbSquareFree);
            this.Controls.Add(this.tbPoly);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpenPar);
            this.Controls.Add(this.tbControlFact);
            this.MinimumSize = new System.Drawing.Size(500, 420);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Разложение полинома над конечным полем";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbControlFact;
        private System.Windows.Forms.Button btnOpenPar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPoly;
        private System.Windows.Forms.TextBox tbSquareFree;
        private System.Windows.Forms.Button btnGenPoly;
        private System.Windows.Forms.Button btnFactorise;
        private System.Windows.Forms.TextBox tbFullFactorization;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEqTitle;
        private System.Windows.Forms.Label lblEq;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbDivisor;
        private System.Windows.Forms.TextBox tbN;
        private System.Windows.Forms.TextBox tbP;
        private System.Windows.Forms.Button btnFindDivisor;
        private System.Windows.Forms.Button btnSetDivisor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}

