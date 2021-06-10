
namespace Dedisclasik
{
    partial class Connexion
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
            this.connexion_button = new System.Windows.Forms.Button();
            this.inscription_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mdpConnexion = new System.Windows.Forms.TextBox();
            this.loginConnexion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // connexion_button
            // 
            this.connexion_button.Location = new System.Drawing.Point(244, 219);
            this.connexion_button.Name = "connexion_button";
            this.connexion_button.Size = new System.Drawing.Size(137, 23);
            this.connexion_button.TabIndex = 15;
            this.connexion_button.Text = "Se connecter";
            this.connexion_button.UseVisualStyleBackColor = true;
            this.connexion_button.Click += new System.EventHandler(this.connexion_Click);
            // 
            // inscription_button
            // 
            this.inscription_button.Location = new System.Drawing.Point(310, 278);
            this.inscription_button.Name = "inscription_button";
            this.inscription_button.Size = new System.Drawing.Size(97, 23);
            this.inscription_button.TabIndex = 14;
            this.inscription_button.Text = "Inscrivez-vous";
            this.inscription_button.UseVisualStyleBackColor = true;
            this.inscription_button.Click += new System.EventHandler(this.inscription_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(274, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Connexion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Pas de compte ?";
            // 
            // mdpConnexion
            // 
            this.mdpConnexion.Location = new System.Drawing.Point(307, 161);
            this.mdpConnexion.Name = "mdpConnexion";
            this.mdpConnexion.Size = new System.Drawing.Size(100, 20);
            this.mdpConnexion.TabIndex = 11;
            // 
            // loginConnexion
            // 
            this.loginConnexion.Location = new System.Drawing.Point(307, 113);
            this.loginConnexion.Name = "loginConnexion";
            this.loginConnexion.Size = new System.Drawing.Size(100, 20);
            this.loginConnexion.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mot de passe :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nom utilisateur :";
            // 
            // Connexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 367);
            this.Controls.Add(this.connexion_button);
            this.Controls.Add(this.inscription_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mdpConnexion);
            this.Controls.Add(this.loginConnexion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Connexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connexion";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Connexion_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connexion_button;
        private System.Windows.Forms.Button inscription_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox mdpConnexion;
        private System.Windows.Forms.TextBox loginConnexion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}