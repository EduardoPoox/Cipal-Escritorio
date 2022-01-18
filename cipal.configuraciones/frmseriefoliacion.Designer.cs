namespace cipal.configuraciones
{
    partial class frmseriefoliacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmseriefoliacion));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.gbgeneral = new Infragistics.Win.Misc.UltraGroupBox();
            this.chkvigente = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.btncancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnguardar = new Infragistics.Win.Misc.UltraButton();
            this.txtvaloractual = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtvalorinicial = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbtiposerie = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblidtipoapoyo = new Infragistics.Win.Misc.UltraLabel();
            this.txtfolio = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblfolio = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbgeneral)).BeginInit();
            this.gbgeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkvigente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvaloractual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvalorinicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbtiposerie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfolio)).BeginInit();
            this.SuspendLayout();
            // 
            // gbgeneral
            // 
            this.gbgeneral.Controls.Add(this.chkvigente);
            this.gbgeneral.Controls.Add(this.btncancelar);
            this.gbgeneral.Controls.Add(this.btnguardar);
            this.gbgeneral.Controls.Add(this.txtvaloractual);
            this.gbgeneral.Controls.Add(this.txtvalorinicial);
            this.gbgeneral.Controls.Add(this.ultraLabel2);
            this.gbgeneral.Controls.Add(this.ultraLabel1);
            this.gbgeneral.Controls.Add(this.cmbtiposerie);
            this.gbgeneral.Controls.Add(this.lblidtipoapoyo);
            this.gbgeneral.Controls.Add(this.txtfolio);
            this.gbgeneral.Controls.Add(this.lblfolio);
            this.gbgeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbgeneral.Location = new System.Drawing.Point(0, 0);
            this.gbgeneral.Name = "gbgeneral";
            this.gbgeneral.Size = new System.Drawing.Size(301, 197);
            this.gbgeneral.TabIndex = 1;
            this.gbgeneral.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // chkvigente
            // 
            this.chkvigente.BackColor = System.Drawing.Color.Transparent;
            this.chkvigente.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkvigente.Location = new System.Drawing.Point(96, 121);
            this.chkvigente.Name = "chkvigente";
            this.chkvigente.Size = new System.Drawing.Size(197, 20);
            this.chkvigente.TabIndex = 26;
            this.chkvigente.Text = "Vigente";
            // 
            // btncancelar
            // 
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Bottom;
            this.btncancelar.Appearance = appearance1;
            this.btncancelar.Location = new System.Drawing.Point(10, 148);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(128, 42);
            this.btncancelar.TabIndex = 25;
            this.btncancelar.Text = "CANCELAR";
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btnguardar
            // 
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Bottom;
            this.btnguardar.Appearance = appearance2;
            this.btnguardar.Location = new System.Drawing.Point(153, 148);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(140, 42);
            this.btnguardar.TabIndex = 24;
            this.btnguardar.Text = "GUARDAR";
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // txtvaloractual
            // 
            this.txtvaloractual.Enabled = false;
            this.txtvaloractual.Location = new System.Drawing.Point(96, 93);
            this.txtvaloractual.Name = "txtvaloractual";
            this.txtvaloractual.PromptChar = ' ';
            this.txtvaloractual.Size = new System.Drawing.Size(197, 21);
            this.txtvaloractual.TabIndex = 22;
            // 
            // txtvalorinicial
            // 
            this.txtvalorinicial.Location = new System.Drawing.Point(96, 66);
            this.txtvalorinicial.Name = "txtvalorinicial";
            this.txtvalorinicial.PromptChar = ' ';
            this.txtvalorinicial.Size = new System.Drawing.Size(197, 21);
            this.txtvalorinicial.TabIndex = 21;
            // 
            // ultraLabel2
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel2.Appearance = appearance3;
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.ultraLabel2.Location = new System.Drawing.Point(10, 98);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(36, 14);
            this.ultraLabel2.TabIndex = 20;
            this.ultraLabel2.Text = "Actual";
            // 
            // ultraLabel1
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel1.Appearance = appearance4;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.ultraLabel1.Location = new System.Drawing.Point(10, 73);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(33, 14);
            this.ultraLabel1.TabIndex = 19;
            this.ultraLabel1.Text = "Inicial";
            // 
            // cmbtiposerie
            // 
            this.cmbtiposerie.Location = new System.Drawing.Point(96, 12);
            this.cmbtiposerie.Name = "cmbtiposerie";
            this.cmbtiposerie.Size = new System.Drawing.Size(197, 21);
            this.cmbtiposerie.TabIndex = 17;
            // 
            // lblidtipoapoyo
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.lblidtipoapoyo.Appearance = appearance5;
            this.lblidtipoapoyo.AutoSize = true;
            this.lblidtipoapoyo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblidtipoapoyo.Location = new System.Drawing.Point(10, 16);
            this.lblidtipoapoyo.Name = "lblidtipoapoyo";
            this.lblidtipoapoyo.Size = new System.Drawing.Size(71, 14);
            this.lblidtipoapoyo.TabIndex = 18;
            this.lblidtipoapoyo.Text = "Tipo de Serie";
            // 
            // txtfolio
            // 
            this.txtfolio.Location = new System.Drawing.Point(96, 39);
            this.txtfolio.Name = "txtfolio";
            this.txtfolio.Size = new System.Drawing.Size(197, 21);
            this.txtfolio.TabIndex = 4;
            // 
            // lblfolio
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.lblfolio.Appearance = appearance6;
            this.lblfolio.AutoSize = true;
            this.lblfolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.lblfolio.Location = new System.Drawing.Point(10, 44);
            this.lblfolio.Name = "lblfolio";
            this.lblfolio.Size = new System.Drawing.Size(31, 14);
            this.lblfolio.TabIndex = 3;
            this.lblfolio.Text = "Serie";
            // 
            // frmseriefoliacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 197);
            this.Controls.Add(this.gbgeneral);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmseriefoliacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serie de Foliación";
            this.Load += new System.EventHandler(this.frmseriefoliacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbgeneral)).EndInit();
            this.gbgeneral.ResumeLayout(false);
            this.gbgeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkvigente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvaloractual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvalorinicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbtiposerie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfolio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox gbgeneral;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtfolio;
        private Infragistics.Win.Misc.UltraLabel lblfolio;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbtiposerie;
        private Infragistics.Win.Misc.UltraLabel lblidtipoapoyo;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtvaloractual;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtvalorinicial;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraButton btncancelar;
        private Infragistics.Win.Misc.UltraButton btnguardar;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkvigente;
    }
}