using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dedisclasik
{
    public partial class InterfaceTemp : Form
    {
        public InterfaceTemp()
        {
            InitializeComponent();
            afficherEmprunts(EMPRUNTER.ListeAlbums(Connexion.id_abonné));
        }

        public void afficherEmprunts(List<string> albums)
        {
            albumEmprunt.Items.Clear();
            if (albums.Count() <= 0)
            {
                albumEmprunt.Items.Add("erreur");
            }
            foreach (string alb in albums)
            {
                albumEmprunt.Items.Add(alb);
            }
        }

        private void voirAlbums_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
