
namespace Dedisclasik
{
    partial class InterfaceTemp
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
            this.albumEmprunt = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // albumEmprunt
            // 
            this.albumEmprunt.FormattingEnabled = true;
            this.albumEmprunt.Location = new System.Drawing.Point(449, 36);
            this.albumEmprunt.Name = "albumEmprunt";
            this.albumEmprunt.Size = new System.Drawing.Size(316, 381);
            this.albumEmprunt.TabIndex = 0;
            // 
            // InterfaceTemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.albumEmprunt);
            this.Name = "InterfaceTemp";
            this.Text = "InterfaceTemp";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox albumEmprunt;
    }
}