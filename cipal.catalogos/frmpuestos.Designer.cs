
namespace cipal.catalogos
{
    partial class frmpuestos
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
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmpuestos));
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            this.gbgeneral = new Infragistics.Win.Misc.UltraGroupBox();
            this.grdpuestos = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.btnborrar = new Infragistics.Win.Misc.UltraButton();
            this.btncancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnguardar = new Infragistics.Win.Misc.UltraButton();
            this.txtnombre = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblnombre = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbgeneral)).BeginInit();
            this.gbgeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdpuestos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnombre)).BeginInit();
            this.SuspendLayout();
            // 
            // gbgeneral
            // 
            this.gbgeneral.Controls.Add(this.grdpuestos);
            this.gbgeneral.Controls.Add(this.btnborrar);
            this.gbgeneral.Controls.Add(this.btncancelar);
            this.gbgeneral.Controls.Add(this.btnguardar);
            this.gbgeneral.Controls.Add(this.txtnombre);
            this.gbgeneral.Controls.Add(this.lblnombre);
            this.gbgeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbgeneral.Location = new System.Drawing.Point(0, 0);
            this.gbgeneral.Name = "gbgeneral";
            this.gbgeneral.Size = new System.Drawing.Size(328, 405);
            this.gbgeneral.TabIndex = 2;
            this.gbgeneral.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            this.gbgeneral.Click += new System.EventHandler(this.gbgeneral_Click_1);
            // 
            // grdpuestos
            // 
            this.grdpuestos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdpuestos.DisplayLayout.Appearance = appearance1;
            this.grdpuestos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdpuestos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grdpuestos.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdpuestos.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.grdpuestos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdpuestos.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.grdpuestos.DisplayLayout.MaxColScrollRegions = 1;
            this.grdpuestos.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdpuestos.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdpuestos.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.grdpuestos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdpuestos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.grdpuestos.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdpuestos.DisplayLayout.Override.CellAppearance = appearance8;
            this.grdpuestos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdpuestos.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.grdpuestos.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.grdpuestos.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.grdpuestos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdpuestos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.grdpuestos.DisplayLayout.Override.RowAppearance = appearance11;
            this.grdpuestos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdpuestos.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.grdpuestos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdpuestos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdpuestos.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdpuestos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Horizontal;
            this.grdpuestos.Location = new System.Drawing.Point(5, 114);
            this.grdpuestos.Name = "grdpuestos";
            this.grdpuestos.Size = new System.Drawing.Size(317, 248);
            this.grdpuestos.TabIndex = 14;
            // 
            // btnborrar
            // 
            appearance13.Image = ((object)(resources.GetObject("appearance13.Image")));
            appearance13.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance13.ImageVAlign = Infragistics.Win.VAlign.Top;
            this.btnborrar.Appearance = appearance13;
            this.btnborrar.Location = new System.Drawing.Point(150, 74);
            this.btnborrar.Name = "btnborrar";
            this.btnborrar.Size = new System.Drawing.Size(79, 34);
            this.btnborrar.TabIndex = 13;
            this.btnborrar.Text = "BORRAR";
            this.btnborrar.Click += new System.EventHandler(this.btnborrar_Click);
            // 
            // btncancelar
            // 
            appearance14.Image = ((object)(resources.GetObject("appearance14.Image")));
            appearance14.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance14.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btncancelar.Appearance = appearance14;
            this.btncancelar.Location = new System.Drawing.Point(235, 368);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(87, 32);
            this.btncancelar.TabIndex = 2;
            this.btncancelar.Text = "CERRAR";
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btnguardar
            // 
            appearance15.Image = ((object)(resources.GetObject("appearance15.Image")));
            appearance15.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance15.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnguardar.Appearance = appearance15;
            this.btnguardar.Location = new System.Drawing.Point(235, 74);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(87, 34);
            this.btnguardar.TabIndex = 1;
            this.btnguardar.Text = "GUARDAR";
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(67, 12);
            this.txtnombre.Multiline = true;
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(255, 55);
            this.txtnombre.TabIndex = 0;
            // 
            // lblnombre
            // 
            appearance16.BackColor = System.Drawing.Color.Transparent;
            this.lblnombre.Appearance = appearance16;
            this.lblnombre.AutoSize = true;
            this.lblnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombre.Location = new System.Drawing.Point(5, 15);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(44, 14);
            this.lblnombre.TabIndex = 1;
            this.lblnombre.Text = "Nombre";
            // 
            // frmpuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 405);
            this.Controls.Add(this.gbgeneral);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmpuestos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puestos";
            this.Load += new System.EventHandler(this.frmpuesto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbgeneral)).EndInit();
            this.gbgeneral.ResumeLayout(false);
            this.gbgeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdpuestos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnombre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox gbgeneral;
        private Infragistics.Win.Misc.UltraButton btncancelar;
        private Infragistics.Win.Misc.UltraButton btnguardar;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtnombre;
        private Infragistics.Win.Misc.UltraLabel lblnombre;
        private Infragistics.Win.Misc.UltraButton btnborrar;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdpuestos;
    }
}