namespace cipal.catalogos
{
    partial class frmimpuesto
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmimpuesto));
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.gbvehiculo = new Infragistics.Win.Misc.UltraGroupBox();
            this.txttasa = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.cmbtipodeimpuesto = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.lbltasa = new Infragistics.Win.Misc.UltraLabel();
            this.txtnombre = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblnombre = new Infragistics.Win.Misc.UltraLabel();
            this.txtclavesat = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblcvimpuesto = new Infragistics.Win.Misc.UltraLabel();
            this.btncancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnguardar = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.gbvehiculo)).BeginInit();
            this.gbvehiculo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txttasa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbtipodeimpuesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtclavesat)).BeginInit();
            this.SuspendLayout();
            // 
            // gbvehiculo
            // 
            this.gbvehiculo.Controls.Add(this.txttasa);
            this.gbvehiculo.Controls.Add(this.cmbtipodeimpuesto);
            this.gbvehiculo.Controls.Add(this.ultraLabel1);
            this.gbvehiculo.Controls.Add(this.lbltasa);
            this.gbvehiculo.Controls.Add(this.txtnombre);
            this.gbvehiculo.Controls.Add(this.lblnombre);
            this.gbvehiculo.Controls.Add(this.txtclavesat);
            this.gbvehiculo.Controls.Add(this.lblcvimpuesto);
            this.gbvehiculo.Controls.Add(this.btncancelar);
            this.gbvehiculo.Controls.Add(this.btnguardar);
            this.gbvehiculo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbvehiculo.Location = new System.Drawing.Point(0, 0);
            this.gbvehiculo.Name = "gbvehiculo";
            this.gbvehiculo.Size = new System.Drawing.Size(411, 179);
            this.gbvehiculo.TabIndex = 5;
            this.gbvehiculo.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // txttasa
            // 
            this.txttasa.Location = new System.Drawing.Point(115, 108);
            this.txttasa.MaskInput = "{LOC}nn,nnn,nnn.nn";
            this.txttasa.Name = "txttasa";
            this.txttasa.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txttasa.PromptChar = ' ';
            this.txttasa.Size = new System.Drawing.Size(287, 21);
            this.txttasa.TabIndex = 25;
            // 
            // cmbtipodeimpuesto
            // 
            this.cmbtipodeimpuesto.Location = new System.Drawing.Point(115, 12);
            this.cmbtipodeimpuesto.Name = "cmbtipodeimpuesto";
            this.cmbtipodeimpuesto.Size = new System.Drawing.Size(288, 21);
            this.cmbtipodeimpuesto.TabIndex = 18;
            // 
            // ultraLabel1
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel1.Appearance = appearance1;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(9, 15);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(91, 14);
            this.ultraLabel1.TabIndex = 24;
            this.ultraLabel1.Text = "Tipo de Impuesto";
            // 
            // lbltasa
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.lbltasa.Appearance = appearance2;
            this.lbltasa.AutoSize = true;
            this.lbltasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltasa.Location = new System.Drawing.Point(9, 113);
            this.lbltasa.Name = "lbltasa";
            this.lbltasa.Size = new System.Drawing.Size(29, 14);
            this.lbltasa.TabIndex = 23;
            this.lbltasa.Text = "Tasa";
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(115, 39);
            this.txtnombre.Multiline = true;
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(288, 37);
            this.txtnombre.TabIndex = 19;
            // 
            // lblnombre
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.lblnombre.Appearance = appearance3;
            this.lblnombre.AutoSize = true;
            this.lblnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombre.Location = new System.Drawing.Point(9, 39);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(44, 14);
            this.lblnombre.TabIndex = 22;
            this.lblnombre.Text = "Nombre ";
            // 
            // txtclavesat
            // 
            this.txtclavesat.Location = new System.Drawing.Point(115, 81);
            this.txtclavesat.Name = "txtclavesat";
            this.txtclavesat.Size = new System.Drawing.Size(288, 21);
            this.txtclavesat.TabIndex = 21;
            // 
            // lblcvimpuesto
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.lblcvimpuesto.Appearance = appearance4;
            this.lblcvimpuesto.AutoSize = true;
            this.lblcvimpuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcvimpuesto.Location = new System.Drawing.Point(9, 85);
            this.lblcvimpuesto.Name = "lblcvimpuesto";
            this.lblcvimpuesto.Size = new System.Drawing.Size(76, 14);
            this.lblcvimpuesto.TabIndex = 20;
            this.lblcvimpuesto.Text = "Clave del SAT";
            // 
            // btncancelar
            // 
            this.btncancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btncancelar.Appearance = appearance5;
            this.btncancelar.Location = new System.Drawing.Point(179, 134);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(102, 39);
            this.btncancelar.TabIndex = 6;
            this.btncancelar.Text = "CANCELAR";
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btnguardar
            // 
            this.btnguardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.Image = ((object)(resources.GetObject("appearance6.Image")));
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnguardar.Appearance = appearance6;
            this.btnguardar.Location = new System.Drawing.Point(295, 134);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(107, 39);
            this.btnguardar.TabIndex = 5;
            this.btnguardar.Text = "GUARDAR";
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // frmimpuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 179);
            this.Controls.Add(this.gbvehiculo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmimpuesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impuesto";
            this.Load += new System.EventHandler(this.frmimpuesto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbvehiculo)).EndInit();
            this.gbvehiculo.ResumeLayout(false);
            this.gbvehiculo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txttasa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbtipodeimpuesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtclavesat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox gbvehiculo;
        private Infragistics.Win.Misc.UltraButton btncancelar;
        private Infragistics.Win.Misc.UltraButton btnguardar;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txttasa;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbtipodeimpuesto;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel lbltasa;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtnombre;
        private Infragistics.Win.Misc.UltraLabel lblnombre;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtclavesat;
        private Infragistics.Win.Misc.UltraLabel lblcvimpuesto;
    }
}