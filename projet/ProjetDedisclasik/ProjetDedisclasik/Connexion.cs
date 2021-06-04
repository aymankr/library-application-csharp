using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetDedisclasik
{
    public partial class Connexion : Form
    {
        MusiquePT2_NEntities musique;
        public Connexion()
        {
            InitializeComponent();
            musique = new MusiquePT2_NEntities();
        }

        private void inscription_Click(object sender, EventArgs e)
        {
            Inscription inscription = new Inscription(musique);
            inscription.ShowDialog();
        }

        private void connexion_Click(object sender, EventArgs e)
        {
            if (connexionValide()) MessageBox.Show("Connexion réussie.");
        }

        private bool connexionValide()
        {
            bool valide = false;
            String login = loginConnexion.Text;
            String mdp = mdpConnexion.Text;
            var abonnes = (from a in musique.ABONNÉS
                           select a).ToList();
            foreach (ABONNÉS a in abonnes)
            {
                if (login.Equals(a.LOGIN_ABONNÉ.Trim()) && mdp.Equals(a.PASSWORD_ABONNÉ.Trim())) valide = true;
            }

            return valide;
        }
    }
}
