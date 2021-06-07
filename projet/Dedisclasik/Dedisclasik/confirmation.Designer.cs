
namespace Dedisclasik
{
    partial class confirmation
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
            this.confirm = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.Titre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // confirm
            // 
            this.confirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.confirm.Location = new System.Drawing.Point(64, 125);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(75, 23);
            this.confirm.TabIndex = 2;
            this.confirm.Text = "Confirmer";
            this.confirm.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(230, 125);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Annuler";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // Titre
            // 
            this.Titre.AutoSize = true;
            this.Titre.Location = new System.Drawing.Point(61, 33);
            this.Titre.Name = "Titre";
            this.Titre.Size = new System.Drawing.Size(35, 13);
            this.Titre.TabIndex = 4;
            this.Titre.Text = "label1";
            // 
            // confirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 221);
            this.Controls.Add(this.Titre);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.confirm);
            this.Name = "confirmation";
            this.Text = "confirmation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label Titre;
    }
}