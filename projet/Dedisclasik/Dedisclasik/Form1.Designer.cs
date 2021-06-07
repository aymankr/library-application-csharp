
namespace Dedisclasik
{
    partial class suggest
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
            this.label1 = new System.Windows.Forms.Label();
            this.genre = new System.Windows.Forms.Button();
            this.artiste = new System.Windows.Forms.Button();
            this.emprunt = new System.Windows.Forms.Button();
            this.Suggestions = new System.Windows.Forms.ListBox();
            this.leave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Suggestions par :";
            // 
            // genre
            // 
            this.genre.Location = new System.Drawing.Point(42, 64);
            this.genre.Name = "genre";
            this.genre.Size = new System.Drawing.Size(75, 23);
            this.genre.TabIndex = 1;
            this.genre.Text = "Genre";
            this.genre.UseVisualStyleBackColor = true;
            this.genre.Click += new System.EventHandler(this.genre_Click);
            // 
            // artiste
            // 
            this.artiste.Location = new System.Drawing.Point(42, 116);
            this.artiste.Name = "artiste";
            this.artiste.Size = new System.Drawing.Size(75, 23);
            this.artiste.TabIndex = 2;
            this.artiste.Text = "Artiste";
            this.artiste.UseVisualStyleBackColor = true;
            this.artiste.Click += new System.EventHandler(this.artiste_Click);
            // 
            // emprunt
            // 
            this.emprunt.Location = new System.Drawing.Point(679, 116);
            this.emprunt.Name = "emprunt";
            this.emprunt.Size = new System.Drawing.Size(75, 23);
            this.emprunt.TabIndex = 3;
            this.emprunt.Text = "Emprunter";
            this.emprunt.UseVisualStyleBackColor = true;
            this.emprunt.Click += new System.EventHandler(this.emprunt_Click);
            // 
            // Suggestions
            // 
            this.Suggestions.FormattingEnabled = true;
            this.Suggestions.Location = new System.Drawing.Point(12, 160);
            this.Suggestions.Name = "Suggestions";
            this.Suggestions.Size = new System.Drawing.Size(776, 277);
            this.Suggestions.TabIndex = 4;
            // 
            // leave
            // 
            this.leave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.leave.Location = new System.Drawing.Point(679, 12);
            this.leave.Name = "leave";
            this.leave.Size = new System.Drawing.Size(75, 23);
            this.leave.TabIndex = 5;
            this.leave.Text = "Quitter";
            this.leave.UseVisualStyleBackColor = true;
            // 
            // suggest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.leave);
            this.Controls.Add(this.Suggestions);
            this.Controls.Add(this.emprunt);
            this.Controls.Add(this.artiste);
            this.Controls.Add(this.genre);
            this.Controls.Add(this.label1);
            this.Name = "suggest";
            this.Text = "Suggestions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button genre;
        private System.Windows.Forms.Button artiste;
        private System.Windows.Forms.Button emprunt;
        private System.Windows.Forms.ListBox Suggestions;
        private System.Windows.Forms.Button leave;
    }
}