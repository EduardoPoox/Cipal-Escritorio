
namespace cipal
{
    partial class frmIntro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntro));
            this.pblogoizquierdo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pblogoizquierdo)).BeginInit();
            this.SuspendLayout();
            // 
            // pblogoizquierdo
            // 
            this.pblogoizquierdo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pblogoizquierdo.Image = ((System.Drawing.Image)(resources.GetObject("pblogoizquierdo.Image")));
            this.pblogoizquierdo.Location = new System.Drawing.Point(12, 12);
            this.pblogoizquierdo.Name = "pblogoizquierdo";
            this.pblogoizquierdo.Size = new System.Drawing.Size(776, 426);
            this.pblogoizquierdo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pblogoizquierdo.TabIndex = 48;
            this.pblogoizquierdo.TabStop = false;
            // 
            // frmIntro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pblogoizquierdo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmIntro";
            this.Text = "frmIntro";
            ((System.ComponentModel.ISupportInitialize)(this.pblogoizquierdo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pblogoizquierdo;
    }
}