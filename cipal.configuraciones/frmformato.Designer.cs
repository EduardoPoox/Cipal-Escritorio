namespace cipal.configuraciones
{
    partial class frmformato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmformato));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.gbgeneral = new Infragistics.Win.Misc.UltraGroupBox();
            this.chkvigente = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.btnbuscarformato = new Infragistics.Win.Misc.UltraButton();
            this.btnguardar = new Infragistics.Win.Misc.UltraButton();
            this.txtnombreformato = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.cmbtipoformato = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbgrupoformato = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.btncancelar = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbgrupogeneral = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblidtipoapoyo = new Infragistics.Win.Misc.UltraLabel();
            this.txtdirectorioformato = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblfolio = new Infragistics.Win.Misc.UltraLabel();
            this.ofdialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gbgeneral)).BeginInit();
            this.gbgeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkvigente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnombreformato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbtipoformato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbgrupoformato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbgrupogeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdirectorioformato)).BeginInit();
            this.SuspendLayout();
            // 
            // gbgeneral
            // 
            this.gbgeneral.Controls.Add(this.chkvigente);
            this.gbgeneral.Controls.Add(this.btnbuscarformato);
            this.gbgeneral.Controls.Add(this.btnguardar);
            this.gbgeneral.Controls.Add(this.txtnombreformato);
            this.gbgeneral.Controls.Add(this.cmbtipoformato);
            this.gbgeneral.Controls.Add(this.ultraLabel4);
            this.gbgeneral.Controls.Add(this.cmbgrupoformato);
            this.gbgeneral.Controls.Add(this.ultraLabel3);
            this.gbgeneral.Controls.Add(this.btncancelar);
            this.gbgeneral.Controls.Add(this.ultraLabel1);
            this.gbgeneral.Controls.Add(this.cmbgrupogeneral);
            this.gbgeneral.Controls.Add(this.lblidtipoapoyo);
            this.gbgeneral.Controls.Add(this.txtdirectorioformato);
            this.gbgeneral.Controls.Add(this.lblfolio);
            this.gbgeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbgeneral.Location = new System.Drawing.Point(0, 0);
            this.gbgeneral.Name = "gbgeneral";
            this.gbgeneral.Size = new System.Drawing.Size(441, 232);
            this.gbgeneral.TabIndex = 0;
            this.gbgeneral.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // chkvigente
            // 
            this.chkvigente.BackColor = System.Drawing.Color.Transparent;
            this.chkvigente.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkvigente.Location = new System.Drawing.Point(338, 95);
            this.chkvigente.Name = "chkvigente";
            this.chkvigente.Size = new System.Drawing.Size(93, 20);
            this.chkvigente.TabIndex = 42;
            this.chkvigente.Text = "Vigente";
            // 
            // btnbuscarformato
            // 
            this.btnbuscarformato.Location = new System.Drawing.Point(394, 141);
            this.btnbuscarformato.Name = "btnbuscarformato";
            this.btnbuscarformato.Size = new System.Drawing.Size(37, 36);
            this.btnbuscarformato.TabIndex = 41;
            this.btnbuscarformato.Text = "...";
            this.btnbuscarformato.Click += new System.EventHandler(this.btnbuscarformato_Click);
            // 
            // btnguardar
            // 
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Bottom;
            this.btnguardar.Appearance = appearance1;
            this.btnguardar.Location = new System.Drawing.Point(291, 183);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(140, 42);
            this.btnguardar.TabIndex = 40;
            this.btnguardar.Text = "GUARDAR";
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // txtnombreformato
            // 
            this.txtnombreformato.Location = new System.Drawing.Point(12, 142);
            this.txtnombreformato.Multiline = true;
            this.txtnombreformato.Name = "txtnombreformato";
            this.txtnombreformato.Size = new System.Drawing.Size(372, 35);
            this.txtnombreformato.TabIndex = 39;
            // 
            // cmbtipoformato
            // 
            this.cmbtipoformato.Location = new System.Drawing.Point(135, 94);
            this.cmbtipoformato.Name = "cmbtipoformato";
            this.cmbtipoformato.Size = new System.Drawing.Size(197, 21);
            this.cmbtipoformato.TabIndex = 38;
            // 
            // ultraLabel4
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel4.Appearance = appearance2;
            this.ultraLabel4.AutoSize = true;
            this.ultraLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ultraLabel4.Location = new System.Drawing.Point(12, 99);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(83, 14);
            this.ultraLabel4.TabIndex = 37;
            this.ultraLabel4.Text = "Tipo de formato";
            // 
            // cmbgrupoformato
            // 
            this.cmbgrupoformato.Location = new System.Drawing.Point(135, 67);
            this.cmbgrupoformato.Name = "cmbgrupoformato";
            this.cmbgrupoformato.Size = new System.Drawing.Size(197, 21);
            this.cmbgrupoformato.TabIndex = 36;
            // 
            // ultraLabel3
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel3.Appearance = appearance3;
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ultraLabel3.Location = new System.Drawing.Point(12, 72);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(98, 14);
            this.ultraLabel3.TabIndex = 35;
            this.ultraLabel3.Text = "Grupo de formatos";
            // 
            // btncancelar
            // 
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Bottom;
            this.btncancelar.Appearance = appearance4;
            this.btncancelar.Location = new System.Drawing.Point(157, 183);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(128, 42);
            this.btncancelar.TabIndex = 34;
            this.btncancelar.Text = "CANCELAR";
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // ultraLabel1
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel1.Appearance = appearance5;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.ultraLabel1.Location = new System.Drawing.Point(12, 122);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(46, 14);
            this.ultraLabel1.TabIndex = 30;
            this.ultraLabel1.Text = "Formato";
            // 
            // cmbgrupogeneral
            // 
            this.cmbgrupogeneral.Enabled = false;
            this.cmbgrupogeneral.Location = new System.Drawing.Point(135, 40);
            this.cmbgrupogeneral.Name = "cmbgrupogeneral";
            this.cmbgrupogeneral.Size = new System.Drawing.Size(197, 21);
            this.cmbgrupogeneral.TabIndex = 28;
            this.cmbgrupogeneral.ValueChanged += new System.EventHandler(this.cmbgrupogeneral_ValueChanged);
            // 
            // lblidtipoapoyo
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.lblidtipoapoyo.Appearance = appearance6;
            this.lblidtipoapoyo.AutoSize = true;
            this.lblidtipoapoyo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblidtipoapoyo.Location = new System.Drawing.Point(12, 43);
            this.lblidtipoapoyo.Name = "lblidtipoapoyo";
            this.lblidtipoapoyo.Size = new System.Drawing.Size(79, 14);
            this.lblidtipoapoyo.TabIndex = 29;
            this.lblidtipoapoyo.Text = "Grupo General";
            // 
            // txtdirectorioformato
            // 
            this.txtdirectorioformato.Enabled = false;
            this.txtdirectorioformato.Location = new System.Drawing.Point(135, 12);
            this.txtdirectorioformato.Name = "txtdirectorioformato";
            this.txtdirectorioformato.Size = new System.Drawing.Size(296, 21);
            this.txtdirectorioformato.TabIndex = 27;
            // 
            // lblfolio
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            this.lblfolio.Appearance = appearance7;
            this.lblfolio.AutoSize = true;
            this.lblfolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            this.lblfolio.Location = new System.Drawing.Point(10, 17);
            this.lblfolio.Name = "lblfolio";
            this.lblfolio.Size = new System.Drawing.Size(119, 14);
            this.lblfolio.TabIndex = 26;
            this.lblfolio.Text = "Directorio de Formatos";
            // 
            // ofdialog
            // 
            this.ofdialog.DefaultExt = "*.cer";
            this.ofdialog.FileName = "*.cer";
            this.ofdialog.InitialDirectory = "c:\\";
            this.ofdialog.Title = "Seleccione el archivo a cargar";
            // 
            // frmformato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 232);
            this.Controls.Add(this.gbgeneral);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmformato";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formato";
            this.Load += new System.EventHandler(this.frmformato_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbgeneral)).EndInit();
            this.gbgeneral.ResumeLayout(false);
            this.gbgeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkvigente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnombreformato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbtipoformato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbgrupoformato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbgrupogeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdirectorioformato)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox gbgeneral;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtnombreformato;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbtipoformato;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbgrupoformato;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraButton btncancelar;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbgrupogeneral;
        private Infragistics.Win.Misc.UltraLabel lblidtipoapoyo;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtdirectorioformato;
        private Infragistics.Win.Misc.UltraLabel lblfolio;
        private Infragistics.Win.Misc.UltraButton btnguardar;
        private Infragistics.Win.Misc.UltraButton btnbuscarformato;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkvigente;
        private System.Windows.Forms.OpenFileDialog ofdialog;
    }
}