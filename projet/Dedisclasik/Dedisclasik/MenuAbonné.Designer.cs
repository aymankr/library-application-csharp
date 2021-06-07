
namespace Dedisclasik
{
    partial class MenuAbonné
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
            this.afficheEmprunts = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // afficheEmprunts
            // 
            this.afficheEmprunts.Location = new System.Drawing.Point(357, 104);
            this.afficheEmprunts.Name = "afficheEmprunts";
            this.afficheEmprunts.Size = new System.Drawing.Size(151, 28);
            this.afficheEmprunts.TabIndex = 0;
            this.afficheEmprunts.Text = "Afficher mes emprunts";
            this.afficheEmprunts.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(357, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 31);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MenuAbonné
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 492);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.afficheEmprunts);
            this.Name = "MenuAbonné";
            this.Text = "MenuAbonné";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button afficheEmprunts;
        private System.Windows.Forms.Button button1;
    }
}