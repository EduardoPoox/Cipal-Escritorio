
namespace cipal.catalogos
{
    partial class frmunidades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmunidades));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            this.gbgeneral = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnborrar = new Infragistics.Win.Misc.UltraButton();
            this.grdunidades = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.lblsimbologia = new Infragistics.Win.Misc.UltraLabel();
            this.txtsimbologia = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtcvunidad = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblcvunidad = new Infragistics.Win.Misc.UltraLabel();
            this.btncancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnguardar = new Infragistics.Win.Misc.UltraButton();
            this.txtnombre = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblnombre = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbgeneral)).BeginInit();
            this.gbgeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdunidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsimbologia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcvunidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnombre)).BeginInit();
            this.SuspendLayout();
            // 
            // gbgeneral
            // 
            this.gbgeneral.Controls.Add(this.btnborrar);
            this.gbgeneral.Controls.Add(this.grdunidades);
            this.gbgeneral.Controls.Add(this.lblsimbologia);
            this.gbgeneral.Controls.Add(this.txtsimbologia);
            this.gbgeneral.Controls.Add(this.txtcvunidad);
            this.gbgeneral.Controls.Add(this.lblcvunidad);
            this.gbgeneral.Controls.Add(this.btncancelar);
            this.gbgeneral.Controls.Add(this.btnguardar);
            this.gbgeneral.Controls.Add(this.txtnombre);
            this.gbgeneral.Controls.Add(this.lblnombre);
            this.gbgeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbgeneral.Location = new System.Drawing.Point(0, 0);
            this.gbgeneral.Name = "gbgeneral";
            this.gbgeneral.Size = new System.Drawing.Size(382, 464);
            this.gbgeneral.TabIndex = 3;
            this.gbgeneral.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            // 
            // btnborrar
            // 
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnborrar.Appearance = appearance1;
            this.btnborrar.Location = new System.Drawing.Point(191, 96);
            this.btnborrar.Name = "btnborrar";
            this.btnborrar.Size = new System.Drawing.Size(80, 39);
            this.btnborrar.TabIndex = 15;
            this.btnborrar.Text = "BORRAR";
            this.btnborrar.Click += new System.EventHandler(this.btnborrar_Click);
            // 
            // grdunidades
            // 
            this.grdunidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdunidades.DisplayLayout.Appearance = appearance2;
            this.grdunidades.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdunidades.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.grdunidades.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdunidades.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.grdunidades.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdunidades.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.grdunidades.DisplayLayout.MaxColScrollRegions = 1;
            this.grdunidades.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdunidades.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdunidades.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            this.grdunidades.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdunidades.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.grdunidades.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdunidades.DisplayLayout.Override.CellAppearance = appearance9;
            this.grdunidades.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdunidades.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.grdunidades.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.TextHAlignAsString = "Left";
            this.grdunidades.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.grdunidades.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdunidades.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            this.grdunidades.DisplayLayout.Override.RowAppearance = appearance12;
            this.grdunidades.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdunidades.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.grdunidades.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdunidades.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdunidades.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdunidades.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Horizontal;
            this.grdunidades.Location = new System.Drawing.Point(5, 141);
            this.grdunidades.Name = "grdunidades";
            this.grdunidades.Size = new System.Drawing.Size(367, 277);
            this.grdunidades.TabIndex = 14;
            // 
            // lblsimbologia
            // 
            appearance14.BackColor = System.Drawing.Color.Transparent;
            this.lblsimbologia.Appearance = appearance14;
            this.lblsimbologia.AutoSize = true;
            this.lblsimbologia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsimbologia.Location = new System.Drawing.Point(11, 72);
            this.lblsimbologia.Name = "lblsimbologia";
            this.lblsimbologia.Size = new System.Drawing.Size(60, 14);
            this.lblsimbologia.TabIndex = 13;
            this.lblsimbologia.Text = "Simbologia";
            // 
            // txtsimbologia
            // 
            this.txtsimbologia.Location = new System.Drawing.Point(116, 69);
            this.txtsimbologia.Name = "txtsimbologia";
            this.txtsimbologia.Size = new System.Drawing.Size(256, 21);
            this.txtsimbologia.TabIndex = 2;
            // 
            // txtcvunidad
            // 
            this.txtcvunidad.Location = new System.Drawing.Point(116, 45);
            this.txtcvunidad.Name = "txtcvunidad";
            this.txtcvunidad.Size = new System.Drawing.Size(256, 21);
            this.txtcvunidad.TabIndex = 1;
            // 
            // lblcvunidad
            // 
            appearance15.BackColor = System.Drawing.Color.Transparent;
            this.lblcvunidad.Appearance = appearance15;
            this.lblcvunidad.AutoSize = true;
            this.lblcvunidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcvunidad.Location = new System.Drawing.Point(11, 50);
            this.lblcvunidad.Name = "lblcvunidad";
            this.lblcvunidad.Size = new System.Drawing.Size(76, 14);
            this.lblcvunidad.TabIndex = 10;
            this.lblcvunidad.Text = "Clave del SAT";
            // 
            // btncancelar
            // 
            appearance16.Image = ((object)(resources.GetObject("appearance16.Image")));
            appearance16.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance16.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btncancelar.Appearance = appearance16;
            this.btncancelar.Location = new System.Drawing.Point(290, 420);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(82, 39);
            this.btncancelar.TabIndex = 4;
            this.btncancelar.Text = "CERRAR";
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btnguardar
            // 
            appearance17.Image = ((object)(resources.GetObject("appearance17.Image")));
            appearance17.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance17.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnguardar.Appearance = appearance17;
            this.btnguardar.Location = new System.Drawing.Point(277, 96);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(95, 39);
            this.btnguardar.TabIndex = 3;
            this.btnguardar.Text = "GUARDAR";
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(116, 9);
            this.txtnombre.Multiline = true;
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(256, 33);
            this.txtnombre.TabIndex = 0;
            // 
            // lblnombre
            // 
            appearance18.BackColor = System.Drawing.Color.Transparent;
            this.lblnombre.Appearance = appearance18;
            this.lblnombre.AutoSize = true;
            this.lblnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombre.Location = new System.Drawing.Point(11, 9);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(44, 14);
            this.lblnombre.TabIndex = 1;
            this.lblnombre.Text = "Nombre";
            // 
            // frmunidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 464);
            this.Controls.Add(this.gbgeneral);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmunidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unidad";
            this.Load += new System.EventHandler(this.frmunidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbgeneral)).EndInit();
            this.gbgeneral.ResumeLayout(false);
            this.gbgeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdunidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsimbologia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcvunidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnombre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox gbgeneral;
        private Infragistics.Win.Misc.UltraButton btncancelar;
        private Infragistics.Win.Misc.UltraButton btnguardar;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtnombre;
        private Infragistics.Win.Misc.UltraLabel lblnombre;
        private Infragistics.Win.Misc.UltraLabel lblcvunidad;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtcvunidad;
        private Infragistics.Win.Misc.UltraLabel lblsimbologia;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtsimbologia;
        private Infragistics.Win.Misc.UltraButton btnborrar;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdunidades;
    }
}