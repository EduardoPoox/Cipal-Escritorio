
namespace cipal.gestion
{
    partial class frminventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frminventario));
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.gbgeneral = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnagregarunidad = new Infragistics.Win.Misc.UltraButton();
            this.btnagregarconcepto = new Infragistics.Win.Misc.UltraButton();
            this.txtexistencia = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblexistencia = new Infragistics.Win.Misc.UltraLabel();
            this.cmbidunidad = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblidunidad = new Infragistics.Win.Misc.UltraLabel();
            this.cmbidconcepto = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblidconcepto = new Infragistics.Win.Misc.UltraLabel();
            this.btncancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnguardar = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.gbgeneral)).BeginInit();
            this.gbgeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtexistencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbidunidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbidconcepto)).BeginInit();
            this.SuspendLayout();
            // 
            // gbgeneral
            // 
            this.gbgeneral.Controls.Add(this.btnagregarunidad);
            this.gbgeneral.Controls.Add(this.btnagregarconcepto);
            this.gbgeneral.Controls.Add(this.txtexistencia);
            this.gbgeneral.Controls.Add(this.lblexistencia);
            this.gbgeneral.Controls.Add(this.cmbidunidad);
            this.gbgeneral.Controls.Add(this.lblidunidad);
            this.gbgeneral.Controls.Add(this.cmbidconcepto);
            this.gbgeneral.Controls.Add(this.lblidconcepto);
            this.gbgeneral.Controls.Add(this.btncancelar);
            this.gbgeneral.Controls.Add(this.btnguardar);
            this.gbgeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbgeneral.Location = new System.Drawing.Point(0, 0);
            this.gbgeneral.Name = "gbgeneral";
            this.gbgeneral.Size = new System.Drawing.Size(330, 143);
            this.gbgeneral.TabIndex = 3;
            this.gbgeneral.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // btnagregarunidad
            // 
            this.btnagregarunidad.Location = new System.Drawing.Point(297, 66);
            this.btnagregarunidad.Name = "btnagregarunidad";
            this.btnagregarunidad.Size = new System.Drawing.Size(25, 21);
            this.btnagregarunidad.TabIndex = 59;
            this.btnagregarunidad.Text = "+";
            this.btnagregarunidad.Click += new System.EventHandler(this.btnagregarunidad_Click);
            // 
            // btnagregarconcepto
            // 
            this.btnagregarconcepto.Location = new System.Drawing.Point(297, 12);
            this.btnagregarconcepto.Name = "btnagregarconcepto";
            this.btnagregarconcepto.Size = new System.Drawing.Size(25, 21);
            this.btnagregarconcepto.TabIndex = 58;
            this.btnagregarconcepto.Text = "+";
            this.btnagregarconcepto.Click += new System.EventHandler(this.btnagregarconcepto_Click);
            // 
            // txtexistencia
            // 
            this.txtexistencia.Location = new System.Drawing.Point(94, 39);
            this.txtexistencia.Name = "txtexistencia";
            this.txtexistencia.Size = new System.Drawing.Size(228, 21);
            this.txtexistencia.TabIndex = 34;
            // 
            // lblexistencia
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.lblexistencia.Appearance = appearance1;
            this.lblexistencia.AutoSize = true;
            this.lblexistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblexistencia.Location = new System.Drawing.Point(12, 46);
            this.lblexistencia.Name = "lblexistencia";
            this.lblexistencia.Size = new System.Drawing.Size(58, 14);
            this.lblexistencia.TabIndex = 33;
            this.lblexistencia.Text = "Existencia";
            // 
            // cmbidunidad
            // 
            this.cmbidunidad.Location = new System.Drawing.Point(94, 66);
            this.cmbidunidad.Name = "cmbidunidad";
            this.cmbidunidad.Size = new System.Drawing.Size(197, 21);
            this.cmbidunidad.TabIndex = 30;
            // 
            // lblidunidad
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.lblidunidad.Appearance = appearance2;
            this.lblidunidad.AutoSize = true;
            this.lblidunidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblidunidad.Location = new System.Drawing.Point(12, 70);
            this.lblidunidad.Name = "lblidunidad";
            this.lblidunidad.Size = new System.Drawing.Size(41, 14);
            this.lblidunidad.TabIndex = 29;
            this.lblidunidad.Text = "Unidad";
            // 
            // cmbidconcepto
            // 
            this.cmbidconcepto.Location = new System.Drawing.Point(94, 12);
            this.cmbidconcepto.Name = "cmbidconcepto";
            this.cmbidconcepto.Size = new System.Drawing.Size(197, 21);
            this.cmbidconcepto.TabIndex = 25;
            // 
            // lblidconcepto
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.lblidconcepto.Appearance = appearance3;
            this.lblidconcepto.AutoSize = true;
            this.lblidconcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblidconcepto.Location = new System.Drawing.Point(12, 16);
            this.lblidconcepto.Name = "lblidconcepto";
            this.lblidconcepto.Size = new System.Drawing.Size(54, 14);
            this.lblidconcepto.TabIndex = 6;
            this.lblidconcepto.Text = "Concepto";
            // 
            // btncancelar
            // 
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btncancelar.Appearance = appearance4;
            this.btncancelar.Location = new System.Drawing.Point(125, 93);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(97, 39);
            this.btncancelar.TabIndex = 5;
            this.btncancelar.Text = "CANCELAR";
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btnguardar
            // 
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnguardar.Appearance = appearance5;
            this.btnguardar.Location = new System.Drawing.Point(228, 93);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(94, 39);
            this.btnguardar.TabIndex = 4;
            this.btnguardar.Text = "GUARDAR";
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // frminventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 143);
            this.Controls.Add(this.gbgeneral);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frminventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.frminventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbgeneral)).EndInit();
            this.gbgeneral.ResumeLayout(false);
            this.gbgeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtexistencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbidunidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbidconcepto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox gbgeneral;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtexistencia;
        private Infragistics.Win.Misc.UltraLabel lblexistencia;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbidunidad;
        private Infragistics.Win.Misc.UltraLabel lblidunidad;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbidconcepto;
        private Infragistics.Win.Misc.UltraLabel lblidconcepto;
        private Infragistics.Win.Misc.UltraButton btncancelar;
        private Infragistics.Win.Misc.UltraButton btnguardar;
        private Infragistics.Win.Misc.UltraButton btnagregarconcepto;
        private Infragistics.Win.Misc.UltraButton btnagregarunidad;
    }
}