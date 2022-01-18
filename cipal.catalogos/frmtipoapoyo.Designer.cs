
namespace cipal.catalogos
{
    partial class frmtipoapoyo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmtipoapoyo));
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
            this.gbgeneral = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnborrar = new Infragistics.Win.Misc.UltraButton();
            this.grdtipoapoyos = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.btncancelar = new Infragistics.Win.Misc.UltraButton();
            this.btnguardar = new Infragistics.Win.Misc.UltraButton();
            this.txtnombre = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblnombre = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbgeneral)).BeginInit();
            this.gbgeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdtipoapoyos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnombre)).BeginInit();
            this.SuspendLayout();
            // 
            // gbgeneral
            // 
            this.gbgeneral.Controls.Add(this.btnborrar);
            this.gbgeneral.Controls.Add(this.grdtipoapoyos);
            this.gbgeneral.Controls.Add(this.btncancelar);
            this.gbgeneral.Controls.Add(this.btnguardar);
            this.gbgeneral.Controls.Add(this.txtnombre);
            this.gbgeneral.Controls.Add(this.lblnombre);
            this.gbgeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbgeneral.Location = new System.Drawing.Point(0, 0);
            this.gbgeneral.Name = "gbgeneral";
            this.gbgeneral.Size = new System.Drawing.Size(307, 445);
            this.gbgeneral.TabIndex = 2;
            this.gbgeneral.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
            this.gbgeneral.Click += new System.EventHandler(this.gbgeneral_Click);
            // 
            // btnborrar
            // 
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnborrar.Appearance = appearance1;
            this.btnborrar.Location = new System.Drawing.Point(125, 61);
            this.btnborrar.Name = "btnborrar";
            this.btnborrar.Size = new System.Drawing.Size(79, 36);
            this.btnborrar.TabIndex = 12;
            this.btnborrar.Text = "BORRAR";
            this.btnborrar.Click += new System.EventHandler(this.btnborrar_Click);
            // 
            // grdtipoapoyos
            // 
            this.grdtipoapoyos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdtipoapoyos.DisplayLayout.Appearance = appearance2;
            this.grdtipoapoyos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdtipoapoyos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.grdtipoapoyos.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdtipoapoyos.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.grdtipoapoyos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdtipoapoyos.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.grdtipoapoyos.DisplayLayout.MaxColScrollRegions = 1;
            this.grdtipoapoyos.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdtipoapoyos.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdtipoapoyos.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            this.grdtipoapoyos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdtipoapoyos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.grdtipoapoyos.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdtipoapoyos.DisplayLayout.Override.CellAppearance = appearance9;
            this.grdtipoapoyos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdtipoapoyos.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.grdtipoapoyos.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.TextHAlignAsString = "Left";
            this.grdtipoapoyos.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.grdtipoapoyos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdtipoapoyos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            this.grdtipoapoyos.DisplayLayout.Override.RowAppearance = appearance12;
            this.grdtipoapoyos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdtipoapoyos.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.grdtipoapoyos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdtipoapoyos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdtipoapoyos.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdtipoapoyos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Horizontal;
            this.grdtipoapoyos.Location = new System.Drawing.Point(9, 103);
            this.grdtipoapoyos.Name = "grdtipoapoyos";
            this.grdtipoapoyos.Size = new System.Drawing.Size(292, 295);
            this.grdtipoapoyos.TabIndex = 11;
            // 
            // btncancelar
            // 
            this.btncancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance14.Image = ((object)(resources.GetObject("appearance14.Image")));
            appearance14.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance14.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btncancelar.Appearance = appearance14;
            this.btncancelar.Location = new System.Drawing.Point(225, 404);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(76, 36);
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
            this.btnguardar.Location = new System.Drawing.Point(208, 61);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(92, 36);
            this.btnguardar.TabIndex = 1;
            this.btnguardar.Text = "GUARDAR";
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(71, 12);
            this.txtnombre.Multiline = true;
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(229, 43);
            this.txtnombre.TabIndex = 0;
            // 
            // lblnombre
            // 
            appearance16.BackColor = System.Drawing.Color.Transparent;
            this.lblnombre.Appearance = appearance16;
            this.lblnombre.AutoSize = true;
            this.lblnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombre.Location = new System.Drawing.Point(9, 14);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(44, 14);
            this.lblnombre.TabIndex = 1;
            this.lblnombre.Text = "Nombre";
            // 
            // frmtipoapoyo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 445);
            this.Controls.Add(this.gbgeneral);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmtipoapoyo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo de apoyo";
            this.Load += new System.EventHandler(this.frmtipoapoyo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbgeneral)).EndInit();
            this.gbgeneral.ResumeLayout(false);
            this.gbgeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdtipoapoyos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnombre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox gbgeneral;
        private Infragistics.Win.Misc.UltraButton btncancelar;
        private Infragistics.Win.Misc.UltraButton btnguardar;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtnombre;
        private Infragistics.Win.Misc.UltraLabel lblnombre;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdtipoapoyos;
        private Infragistics.Win.Misc.UltraButton btnborrar;
    }
}