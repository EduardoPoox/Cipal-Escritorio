
namespace cipal.gestion
{
    partial class frmapoyodetalle
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
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmapoyodetalle));
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.gbgeneral = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtsimbologia = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.btnagregarunidad = new Infragistics.Win.Misc.UltraButton();
            this.btnagregarconcepto = new Infragistics.Win.Misc.UltraButton();
            this.cmbidconcepto = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.cmbidunidad = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblidunidad = new Infragistics.Win.Misc.UltraLabel();
            this.txtdescripcion = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbldescripcionconcepto = new Infragistics.Win.Misc.UltraLabel();
            this.txtcatidad = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblcantidad = new Infragistics.Win.Misc.UltraLabel();
            this.btncancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnguardar = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.gbgeneral)).BeginInit();
            this.gbgeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtsimbologia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbidconcepto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbidunidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcatidad)).BeginInit();
            this.SuspendLayout();
            // 
            // gbgeneral
            // 
            this.gbgeneral.Controls.Add(this.txtsimbologia);
            this.gbgeneral.Controls.Add(this.ultraLabel2);
            this.gbgeneral.Controls.Add(this.btnagregarunidad);
            this.gbgeneral.Controls.Add(this.btnagregarconcepto);
            this.gbgeneral.Controls.Add(this.cmbidconcepto);
            this.gbgeneral.Controls.Add(this.ultraLabel1);
            this.gbgeneral.Controls.Add(this.cmbidunidad);
            this.gbgeneral.Controls.Add(this.lblidunidad);
            this.gbgeneral.Controls.Add(this.txtdescripcion);
            this.gbgeneral.Controls.Add(this.lbldescripcionconcepto);
            this.gbgeneral.Controls.Add(this.txtcatidad);
            this.gbgeneral.Controls.Add(this.lblcantidad);
            this.gbgeneral.Controls.Add(this.btncancelar);
            this.gbgeneral.Controls.Add(this.btnguardar);
            this.gbgeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbgeneral.Location = new System.Drawing.Point(0, 0);
            this.gbgeneral.Name = "gbgeneral";
            this.gbgeneral.Size = new System.Drawing.Size(500, 241);
            this.gbgeneral.TabIndex = 2;
            this.gbgeneral.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            this.gbgeneral.Click += new System.EventHandler(this.gbgeneral_Click);
            // 
            // txtsimbologia
            // 
            this.txtsimbologia.Location = new System.Drawing.Point(363, 38);
            this.txtsimbologia.Name = "txtsimbologia";
            this.txtsimbologia.Size = new System.Drawing.Size(129, 21);
            this.txtsimbologia.TabIndex = 4;
            // 
            // ultraLabel2
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel2.Appearance = appearance1;
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(296, 41);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(60, 14);
            this.ultraLabel2.TabIndex = 60;
            this.ultraLabel2.Text = "Simbología";
            // 
            // btnagregarunidad
            // 
            this.btnagregarunidad.Location = new System.Drawing.Point(265, 37);
            this.btnagregarunidad.Name = "btnagregarunidad";
            this.btnagregarunidad.Size = new System.Drawing.Size(25, 21);
            this.btnagregarunidad.TabIndex = 3;
            this.btnagregarunidad.Text = "+";
            this.btnagregarunidad.Click += new System.EventHandler(this.btnagregarunidad_Click);
            // 
            // btnagregarconcepto
            // 
            this.btnagregarconcepto.Location = new System.Drawing.Point(468, 12);
            this.btnagregarconcepto.Name = "btnagregarconcepto";
            this.btnagregarconcepto.Size = new System.Drawing.Size(25, 21);
            this.btnagregarconcepto.TabIndex = 1;
            this.btnagregarconcepto.Text = "+";
            this.btnagregarconcepto.Click += new System.EventHandler(this.btnagregarconcepto_Click);
            // 
            // cmbidconcepto
            // 
            this.cmbidconcepto.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cmbidconcepto.Location = new System.Drawing.Point(87, 12);
            this.cmbidconcepto.Name = "cmbidconcepto";
            this.cmbidconcepto.Size = new System.Drawing.Size(375, 21);
            this.cmbidconcepto.TabIndex = 0;
            this.cmbidconcepto.ValueChanged += new System.EventHandler(this.cmbidconcepto_ValueChanged);
            // 
            // ultraLabel1
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel1.Appearance = appearance2;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(7, 12);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(58, 14);
            this.ultraLabel1.TabIndex = 32;
            this.ultraLabel1.Text = "Conceptos";
            // 
            // cmbidunidad
            // 
            this.cmbidunidad.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cmbidunidad.Location = new System.Drawing.Point(87, 37);
            this.cmbidunidad.Name = "cmbidunidad";
            this.cmbidunidad.Size = new System.Drawing.Size(172, 21);
            this.cmbidunidad.TabIndex = 2;
            this.cmbidunidad.ValueChanged += new System.EventHandler(this.cmbidunidad_ValueChanged);
            // 
            // lblidunidad
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.lblidunidad.Appearance = appearance3;
            this.lblidunidad.AutoSize = true;
            this.lblidunidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblidunidad.Location = new System.Drawing.Point(8, 41);
            this.lblidunidad.Name = "lblidunidad";
            this.lblidunidad.Size = new System.Drawing.Size(52, 14);
            this.lblidunidad.TabIndex = 29;
            this.lblidunidad.Text = "Unidades";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Location = new System.Drawing.Point(5, 84);
            this.txtdescripcion.Multiline = true;
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(487, 76);
            this.txtdescripcion.TabIndex = 5;
            // 
            // lbldescripcionconcepto
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.lbldescripcionconcepto.Appearance = appearance4;
            this.lbldescripcionconcepto.AutoSize = true;
            this.lbldescripcionconcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldescripcionconcepto.Location = new System.Drawing.Point(7, 64);
            this.lbldescripcionconcepto.Name = "lbldescripcionconcepto";
            this.lbldescripcionconcepto.Size = new System.Drawing.Size(131, 14);
            this.lbldescripcionconcepto.TabIndex = 27;
            this.lbldescripcionconcepto.Text = "Descripción del concepto";
            // 
            // txtcatidad
            // 
            this.txtcatidad.Location = new System.Drawing.Point(363, 166);
            this.txtcatidad.MaskInput = "{LOC}nn,nnn,nnn.nn";
            this.txtcatidad.Name = "txtcatidad";
            this.txtcatidad.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtcatidad.PromptChar = ' ';
            this.txtcatidad.Size = new System.Drawing.Size(129, 21);
            this.txtcatidad.TabIndex = 6;
            // 
            // lblcantidad
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.lblcantidad.Appearance = appearance5;
            this.lblcantidad.AutoSize = true;
            this.lblcantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcantidad.Location = new System.Drawing.Point(296, 170);
            this.lblcantidad.Name = "lblcantidad";
            this.lblcantidad.Size = new System.Drawing.Size(50, 14);
            this.lblcantidad.TabIndex = 8;
            this.lblcantidad.Text = "Cantidad";
            // 
            // btncancelar
            // 
            appearance6.Image = ((object)(resources.GetObject("appearance6.Image")));
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btncancelar.Appearance = appearance6;
            this.btncancelar.Location = new System.Drawing.Point(296, 193);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(97, 39);
            this.btncancelar.TabIndex = 8;
            this.btncancelar.Text = "CANCELAR";
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btnguardar
            // 
            appearance7.Image = ((object)(resources.GetObject("appearance7.Image")));
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnguardar.Appearance = appearance7;
            this.btnguardar.Location = new System.Drawing.Point(399, 193);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(94, 39);
            this.btnguardar.TabIndex = 7;
            this.btnguardar.Text = "AGREGAR";
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // frmapoyodetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 241);
            this.Controls.Add(this.gbgeneral);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmapoyodetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Concepto de apoyo";
            this.Load += new System.EventHandler(this.frmapoyodetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbgeneral)).EndInit();
            this.gbgeneral.ResumeLayout(false);
            this.gbgeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtsimbologia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbidconcepto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbidunidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcatidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox gbgeneral;
        private Infragistics.Win.Misc.UltraLabel lblcantidad;
        private Infragistics.Win.Misc.UltraButton btncancelar;
        private Infragistics.Win.Misc.UltraButton btnguardar;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtcatidad;
        private Infragistics.Win.Misc.UltraLabel lbldescripcionconcepto;
        private Infragistics.Win.Misc.UltraLabel lblidunidad;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtdescripcion;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbidunidad;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbidconcepto;
        private Infragistics.Win.Misc.UltraButton btnagregarconcepto;
        private Infragistics.Win.Misc.UltraButton btnagregarunidad;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtsimbologia;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
    }
}