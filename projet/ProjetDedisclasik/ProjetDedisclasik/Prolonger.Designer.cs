
namespace ProjetDedisclasik
{
    partial class Prolonger
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
            this.ListeAlbums = new System.Windows.Forms.ListBox();
            this.prolong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListeAlbums
            // 
            this.ListeAlbums.FormattingEnabled = true;
            this.ListeAlbums.Location = new System.Drawing.Point(75, 107);
            this.ListeAlbums.Name = "ListeAlbums";
            this.ListeAlbums.Size = new System.Drawing.Size(295, 199);
            this.ListeAlbums.TabIndex = 0;
            // 
            // prolong
            // 
            this.prolong.Location = new System.Drawing.Point(542, 198);
            this.prolong.Name = "prolong";
            this.prolong.Size = new System.Drawing.Size(75, 23);
            this.prolong.TabIndex = 1;
            this.prolong.Text = "Prolonger";
            this.prolong.UseVisualStyleBackColor = true;
            this.prolong.Click += new System.EventHandler(this.prolong_Click);
            // 
            // Prolonger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.prolong);
            this.Controls.Add(this.ListeAlbums);
            this.Name = "Prolonger";
            this.Text = "Prolonger";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListeAlbums;
        private System.Windows.Forms.Button prolong;
    }
}