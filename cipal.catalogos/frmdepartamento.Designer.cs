
namespace cipal.catalogos
{
    partial class frmdepartamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmdepartamento));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.gbgeneral = new Infragistics.Win.Misc.UltraGroupBox();
            this.btncancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnguardar = new Infragistics.Win.Misc.UltraButton();
            this.txtnombre = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblnombre = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbgeneral)).BeginInit();
            this.gbgeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtnombre)).BeginInit();
            this.SuspendLayout();
            // 
            // gbgeneral
            // 
            this.gbgeneral.Controls.Add(this.btncancelar);
            this.gbgeneral.Controls.Add(this.btnguardar);
            this.gbgeneral.Controls.Add(this.txtnombre);
            this.gbgeneral.Controls.Add(this.lblnombre);
            this.gbgeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbgeneral.Location = new System.Drawing.Point(0, 0);
            this.gbgeneral.Name = "gbgeneral";
            this.gbgeneral.Size = new System.Drawing.Size(313, 121);
            this.gbgeneral.TabIndex = 3;
            this.gbgeneral.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // btncancelar
            // 
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btncancelar.Appearance = appearance1;
            this.btncancelar.Location = new System.Drawing.Point(106, 71);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(96, 43);
            this.btncancelar.TabIndex = 2;
            this.btncancelar.Text = "CANCELAR";
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btnguardar
            // 
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnguardar.Appearance = appearance2;
            this.btnguardar.Location = new System.Drawing.Point(208, 71);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(100, 43);
            this.btnguardar.TabIndex = 1;
            this.btnguardar.Text = "GUARDAR";
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(70, 9);
            this.txtnombre.Multiline = true;
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(238, 56);
            this.txtnombre.TabIndex = 0;
            // 
            // lblnombre
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.lblnombre.Appearance = appearance3;
            this.lblnombre.AutoSize = true;
            this.lblnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombre.Location = new System.Drawing.Point(7, 12);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(44, 14);
            this.lblnombre.TabIndex = 1;
            this.lblnombre.Text = "Nombre";
            // 
            // frmdepartamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 121);
            this.Controls.Add(this.gbgeneral);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmdepartamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Departamento";
            this.Load += new System.EventHandler(this.frmdepartamentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbgeneral)).EndInit();
            this.gbgeneral.ResumeLayout(false);
            this.gbgeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtnombre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox gbgeneral;
        private Infragistics.Win.Misc.UltraButton btnguardar;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtnombre;
        private Infragistics.Win.Misc.UltraLabel lblnombre;
        private Infragistics.Win.Misc.UltraButton btncancelar;
    }
}