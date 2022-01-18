
namespace cipal.ingresos
{
    partial class frmregistroingreso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmregistroingreso));
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            this.gbingreso = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnagregarcontribuyente = new Infragistics.Win.Misc.UltraButton();
            this.btncambiarfolio = new Infragistics.Win.Misc.UltraButton();
            this.txtimporte = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.cmbidempleado = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.txtdescripcion = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lbldescripcion = new Infragistics.Win.Misc.UltraLabel();
            this.cmbtipoingreso = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblidtipoingreso = new Infragistics.Win.Misc.UltraLabel();
            this.lblimporte = new Infragistics.Win.Misc.UltraLabel();
            this.dtfecha = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.cmbidcontribuyente = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblfecha = new Infragistics.Win.Misc.UltraLabel();
            this.txtfolio = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblfolio = new Infragistics.Win.Misc.UltraLabel();
            this.btncancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnguardar = new Infragistics.Win.Misc.UltraButton();
            this.lblidempleado = new Infragistics.Win.Misc.UltraLabel();
            this.lblidcontribuyente = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbingreso)).BeginInit();
            this.gbingreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtimporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbidempleado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbtipoingreso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtfecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbidcontribuyente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfolio)).BeginInit();
            this.SuspendLayout();
            // 
            // gbingreso
            // 
            this.gbingreso.Controls.Add(this.btnagregarcontribuyente);
            this.gbingreso.Controls.Add(this.btncambiarfolio);
            this.gbingreso.Controls.Add(this.txtimporte);
            this.gbingreso.Controls.Add(this.cmbidempleado);
            this.gbingreso.Controls.Add(this.txtdescripcion);
            this.gbingreso.Controls.Add(this.lbldescripcion);
            this.gbingreso.Controls.Add(this.cmbtipoingreso);
            this.gbingreso.Controls.Add(this.lblidtipoingreso);
            this.gbingreso.Controls.Add(this.lblimporte);
            this.gbingreso.Controls.Add(this.dtfecha);
            this.gbingreso.Controls.Add(this.cmbidcontribuyente);
            this.gbingreso.Controls.Add(this.lblfecha);
            this.gbingreso.Controls.Add(this.txtfolio);
            this.gbingreso.Controls.Add(this.lblfolio);
            this.gbingreso.Controls.Add(this.btncancelar);
            this.gbingreso.Controls.Add(this.btnguardar);
            this.gbingreso.Controls.Add(this.lblidempleado);
            this.gbingreso.Controls.Add(this.lblidcontribuyente);
            this.gbingreso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbingreso.Location = new System.Drawing.Point(0, 0);
            this.gbingreso.Name = "gbingreso";
            this.gbingreso.Size = new System.Drawing.Size(603, 227);
            this.gbingreso.TabIndex = 3;
            this.gbingreso.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // btnagregarcontribuyente
            // 
            this.btnagregarcontribuyente.Location = new System.Drawing.Point(570, 36);
            this.btnagregarcontribuyente.Name = "btnagregarcontribuyente";
            this.btnagregarcontribuyente.Size = new System.Drawing.Size(25, 22);
            this.btnagregarcontribuyente.TabIndex = 58;
            this.btnagregarcontribuyente.Text = "+";
            this.btnagregarcontribuyente.Click += new System.EventHandler(this.btnagregarcontribuyente_Click);
            // 
            // btncambiarfolio
            // 
            this.btncambiarfolio.Location = new System.Drawing.Point(365, 9);
            this.btncambiarfolio.Name = "btncambiarfolio";
            this.btncambiarfolio.Size = new System.Drawing.Size(25, 22);
            this.btncambiarfolio.TabIndex = 57;
            this.btncambiarfolio.Text = "...";
            this.btncambiarfolio.Click += new System.EventHandler(this.btncambiarfolio_Click);
            // 
            // txtimporte
            // 
            this.txtimporte.Location = new System.Drawing.Point(493, 63);
            this.txtimporte.Name = "txtimporte";
            this.txtimporte.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.txtimporte.PromptChar = ' ';
            this.txtimporte.Size = new System.Drawing.Size(102, 21);
            this.txtimporte.TabIndex = 43;
            // 
            // cmbidempleado
            // 
            this.cmbidempleado.Location = new System.Drawing.Point(-100, -100);
            this.cmbidempleado.Name = "cmbidempleado";
            this.cmbidempleado.Size = new System.Drawing.Size(197, 21);
            this.cmbidempleado.TabIndex = 42;
            this.cmbidempleado.Visible = false;
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Location = new System.Drawing.Point(10, 120);
            this.txtdescripcion.Multiline = true;
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(583, 54);
            this.txtdescripcion.TabIndex = 36;
            // 
            // lbldescripcion
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.lbldescripcion.Appearance = appearance1;
            this.lbldescripcion.AutoSize = true;
            this.lbldescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldescripcion.Location = new System.Drawing.Point(10, 100);
            this.lbldescripcion.Name = "lbldescripcion";
            this.lbldescripcion.Size = new System.Drawing.Size(187, 14);
            this.lbldescripcion.TabIndex = 35;
            this.lbldescripcion.Text = "Descripción del concepto de ingreso";
            // 
            // cmbtipoingreso
            // 
            this.cmbtipoingreso.Location = new System.Drawing.Point(107, 9);
            this.cmbtipoingreso.Name = "cmbtipoingreso";
            this.cmbtipoingreso.Size = new System.Drawing.Size(108, 21);
            this.cmbtipoingreso.TabIndex = 34;
            this.cmbtipoingreso.ValueChanged += new System.EventHandler(this.cmbidtipoingreso_ValueChanged);
            // 
            // lblidtipoingreso
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.lblidtipoingreso.Appearance = appearance2;
            this.lblidtipoingreso.AutoSize = true;
            this.lblidtipoingreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblidtipoingreso.Location = new System.Drawing.Point(10, 12);
            this.lblidtipoingreso.Name = "lblidtipoingreso";
            this.lblidtipoingreso.Size = new System.Drawing.Size(82, 14);
            this.lblidtipoingreso.TabIndex = 33;
            this.lblidtipoingreso.Text = "Tipo de ingreso";
            // 
            // lblimporte
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.lblimporte.Appearance = appearance3;
            this.lblimporte.AutoSize = true;
            this.lblimporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblimporte.Location = new System.Drawing.Point(404, 67);
            this.lblimporte.Name = "lblimporte";
            this.lblimporte.Size = new System.Drawing.Size(43, 14);
            this.lblimporte.TabIndex = 32;
            this.lblimporte.Text = "Importe";
            // 
            // dtfecha
            // 
            this.dtfecha.DateTime = new System.DateTime(2021, 6, 21, 0, 0, 0, 0);
            this.dtfecha.Location = new System.Drawing.Point(493, 8);
            this.dtfecha.Name = "dtfecha";
            this.dtfecha.Size = new System.Drawing.Size(102, 21);
            this.dtfecha.TabIndex = 31;
            this.dtfecha.Value = new System.DateTime(2021, 6, 21, 0, 0, 0, 0);
            // 
            // cmbidcontribuyente
            // 
            this.cmbidcontribuyente.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cmbidcontribuyente.Location = new System.Drawing.Point(107, 36);
            this.cmbidcontribuyente.Name = "cmbidcontribuyente";
            this.cmbidcontribuyente.Size = new System.Drawing.Size(457, 21);
            this.cmbidcontribuyente.TabIndex = 22;
            // 
            // lblfecha
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.lblfecha.Appearance = appearance4;
            this.lblfecha.AutoSize = true;
            this.lblfecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfecha.Location = new System.Drawing.Point(404, 12);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(81, 14);
            this.lblfecha.TabIndex = 8;
            this.lblfecha.Text = "Fecha de Pago";
            // 
            // txtfolio
            // 
            this.txtfolio.Location = new System.Drawing.Point(274, 9);
            this.txtfolio.Name = "txtfolio";
            this.txtfolio.Size = new System.Drawing.Size(85, 21);
            this.txtfolio.TabIndex = 7;
            // 
            // lblfolio
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            this.lblfolio.Appearance = appearance5;
            this.lblfolio.AutoSize = true;
            this.lblfolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfolio.Location = new System.Drawing.Point(229, 12);
            this.lblfolio.Name = "lblfolio";
            this.lblfolio.Size = new System.Drawing.Size(29, 14);
            this.lblfolio.TabIndex = 6;
            this.lblfolio.Text = "Folio";
            // 
            // btncancelar
            // 
            appearance6.Image = ((object)(resources.GetObject("appearance6.Image")));
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btncancelar.Appearance = appearance6;
            this.btncancelar.Location = new System.Drawing.Point(398, 180);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(97, 39);
            this.btncancelar.TabIndex = 5;
            this.btncancelar.Text = "CANCELAR";
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btnguardar
            // 
            appearance7.Image = ((object)(resources.GetObject("appearance7.Image")));
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnguardar.Appearance = appearance7;
            this.btnguardar.Location = new System.Drawing.Point(501, 180);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(94, 39);
            this.btnguardar.TabIndex = 4;
            this.btnguardar.Text = "GUARDAR";
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // lblidempleado
            // 
            appearance8.BackColor = System.Drawing.Color.Transparent;
            this.lblidempleado.Appearance = appearance8;
            this.lblidempleado.AutoSize = true;
            this.lblidempleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblidempleado.Location = new System.Drawing.Point(-100, -100);
            this.lblidempleado.Name = "lblidempleado";
            this.lblidempleado.Size = new System.Drawing.Size(57, 14);
            this.lblidempleado.TabIndex = 1;
            this.lblidempleado.Text = "Empleado";
            this.lblidempleado.Visible = false;
            // 
            // lblidcontribuyente
            // 
            appearance9.BackColor = System.Drawing.Color.Transparent;
            this.lblidcontribuyente.Appearance = appearance9;
            this.lblidcontribuyente.AutoSize = true;
            this.lblidcontribuyente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblidcontribuyente.Location = new System.Drawing.Point(10, 38);
            this.lblidcontribuyente.Name = "lblidcontribuyente";
            this.lblidcontribuyente.Size = new System.Drawing.Size(75, 14);
            this.lblidcontribuyente.TabIndex = 0;
            this.lblidcontribuyente.Text = "Contribuyente";
            // 
            // frmregistroingreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 227);
            this.Controls.Add(this.gbingreso);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmregistroingreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso";
            this.Load += new System.EventHandler(this.frmingreso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbingreso)).EndInit();
            this.gbingreso.ResumeLayout(false);
            this.gbingreso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtimporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbidempleado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbtipoingreso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtfecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbidcontribuyente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfolio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox gbingreso;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtdescripcion;
        private Infragistics.Win.Misc.UltraLabel lbldescripcion;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbtipoingreso;
        private Infragistics.Win.Misc.UltraLabel lblidtipoingreso;
        private Infragistics.Win.Misc.UltraLabel lblimporte;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dtfecha;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbidcontribuyente;
        private Infragistics.Win.Misc.UltraLabel lblfecha;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtfolio;
        private Infragistics.Win.Misc.UltraLabel lblfolio;
        private Infragistics.Win.Misc.UltraButton btncancelar;
        private Infragistics.Win.Misc.UltraButton btnguardar;
        private Infragistics.Win.Misc.UltraLabel lblidempleado;
        private Infragistics.Win.Misc.UltraLabel lblidcontribuyente;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbidempleado;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtimporte;
        private Infragistics.Win.Misc.UltraButton btncambiarfolio;
        private Infragistics.Win.Misc.UltraButton btnagregarcontribuyente;
    }
}