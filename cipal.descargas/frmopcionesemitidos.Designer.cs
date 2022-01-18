namespace cipal.descargas
{
    partial class frmopcionesemitidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmopcionesemitidos));
            this.gbgeneral = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtuuid = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtfoliointerno = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.txtdirinformes = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.btnactivofijo = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.gbgeneral)).BeginInit();
            this.gbgeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtuuid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfoliointerno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdirinformes)).BeginInit();
            this.SuspendLayout();
            // 
            // gbgeneral
            // 
            this.gbgeneral.Controls.Add(this.txtuuid);
            this.gbgeneral.Controls.Add(this.txtfoliointerno);
            this.gbgeneral.Controls.Add(this.ultraLabel3);
            this.gbgeneral.Controls.Add(this.ultraLabel2);
            this.gbgeneral.Controls.Add(this.txtdirinformes);
            this.gbgeneral.Controls.Add(this.ultraLabel1);
            this.gbgeneral.Controls.Add(this.btnactivofijo);
            this.gbgeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbgeneral.Location = new System.Drawing.Point(0, 0);
            this.gbgeneral.Name = "gbgeneral";
            this.gbgeneral.Size = new System.Drawing.Size(699, 121);
            this.gbgeneral.TabIndex = 0;
            this.gbgeneral.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // txtuuid
            // 
            this.txtuuid.Enabled = false;
            this.txtuuid.Location = new System.Drawing.Point(381, 35);
            this.txtuuid.Name = "txtuuid";
            this.txtuuid.Size = new System.Drawing.Size(310, 21);
            this.txtuuid.TabIndex = 72;
            // 
            // txtfoliointerno
            // 
            this.txtfoliointerno.Enabled = false;
            this.txtfoliointerno.Location = new System.Drawing.Point(381, 10);
            this.txtfoliointerno.Name = "txtfoliointerno";
            this.txtfoliointerno.Size = new System.Drawing.Size(102, 21);
            this.txtfoliointerno.TabIndex = 71;
            // 
            // ultraLabel3
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel3.Appearance = appearance1;
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel3.Location = new System.Drawing.Point(288, 37);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(35, 16);
            this.ultraLabel3.TabIndex = 70;
            this.ultraLabel3.Text = "UUID";
            // 
            // ultraLabel2
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel2.Appearance = appearance2;
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(288, 12);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(73, 16);
            this.ultraLabel2.TabIndex = 69;
            this.ultraLabel2.Text = "Folio Interno";
            // 
            // txtdirinformes
            // 
            this.txtdirinformes.Enabled = false;
            this.txtdirinformes.Location = new System.Drawing.Point(12, 34);
            this.txtdirinformes.Name = "txtdirinformes";
            this.txtdirinformes.Size = new System.Drawing.Size(259, 21);
            this.txtdirinformes.TabIndex = 68;
            // 
            // ultraLabel1
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel1.Appearance = appearance3;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(11, 11);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(126, 16);
            this.ultraLabel1.TabIndex = 67;
            this.ultraLabel1.Text = "Directorio de Informes";
            // 
            // btnactivofijo
            // 
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Bottom;
            this.btnactivofijo.Appearance = appearance4;
            this.btnactivofijo.Location = new System.Drawing.Point(12, 61);
            this.btnactivofijo.Name = "btnactivofijo";
            this.btnactivofijo.Size = new System.Drawing.Size(130, 48);
            this.btnactivofijo.TabIndex = 6;
            this.btnactivofijo.Text = "ACTIVO FIJO";
            // 
            // frmopcionesemitidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 121);
            this.Controls.Add(this.gbgeneral);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmopcionesemitidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opciones de documentos emitidos";
            this.Load += new System.EventHandler(this.frmopcionesemitidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbgeneral)).EndInit();
            this.gbgeneral.ResumeLayout(false);
            this.gbgeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtuuid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfoliointerno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdirinformes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox gbgeneral;
        private Infragistics.Win.Misc.UltraButton btnactivofijo;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtuuid;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtfoliointerno;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtdirinformes;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
    }
}