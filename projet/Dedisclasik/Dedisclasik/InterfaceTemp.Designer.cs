
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
            this.Prolonger = new System.Windows.Forms.Button();
            this.dateRetourAttendue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ToutProlonger = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // albumEmprunt
            // 
            this.albumEmprunt.FormattingEnabled = true;
            this.albumEmprunt.Location = new System.Drawing.Point(449, 36);
            this.albumEmprunt.Name = "albumEmprunt";
            this.albumEmprunt.Size = new System.Drawing.Size(316, 381);
            this.albumEmprunt.TabIndex = 0;
            this.albumEmprunt.SelectedIndexChanged += new System.EventHandler(this.albumEmprunt_SelectedIndexChanged);
            // 
            // Prolonger
            // 
            this.Prolonger.Location = new System.Drawing.Point(152, 297);
            this.Prolonger.Name = "Prolonger";
            this.Prolonger.Size = new System.Drawing.Size(75, 23);
            this.Prolonger.TabIndex = 1;
            this.Prolonger.Text = "Prolonger";
            this.Prolonger.UseVisualStyleBackColor = true;
            this.Prolonger.Click += new System.EventHandler(this.Prolonger_Click);
            // 
            // dateRetourAttendue
            // 
            this.dateRetourAttendue.AutoSize = true;
            this.dateRetourAttendue.Location = new System.Drawing.Point(149, 245);
            this.dateRetourAttendue.Name = "dateRetourAttendue";
            this.dateRetourAttendue.Size = new System.Drawing.Size(53, 13);
            this.dateRetourAttendue.TabIndex = 2;
            this.dateRetourAttendue.Text = "00/00/00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date de retour attendue:";
            // 
            // ToutProlonger
            // 
            this.ToutProlonger.Location = new System.Drawing.Point(23, 390);
            this.ToutProlonger.Name = "ToutProlonger";
            this.ToutProlonger.Size = new System.Drawing.Size(120, 27);
            this.ToutProlonger.TabIndex = 4;
            this.ToutProlonger.Text = "Tout prologoner";
            this.ToutProlonger.UseVisualStyleBackColor = true;
            this.ToutProlonger.Click += new System.EventHandler(this.ToutProlonger_Click);
            // 
            // InterfaceTemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ToutProlonger);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateRetourAttendue);
            this.Controls.Add(this.Prolonger);
            this.Controls.Add(this.albumEmprunt);
            this.Name = "InterfaceTemp";
            this.Text = "InterfaceTemp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox albumEmprunt;
        private System.Windows.Forms.Button Prolonger;
        private System.Windows.Forms.Label dateRetourAttendue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ToutProlonger;
    }
}