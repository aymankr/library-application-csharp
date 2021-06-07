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
            Administrateur administrateur = new Administrateur(musique);
            administrateur.ShowDialog();
            /* if (connexionAdminValide())
             {
                 MessageBox.Show("Connexion admin réussie.");
                 Administrateur administrateur = new Administrateur();
                 administrateur.ShowDialog();
             }
             else if (connexionAboValide()) MessageBox.Show("Connexion abonné réussie.");
             else MessageBox.Show("Connexion échouée, réessayez.");*/
        }

        private bool connexionAboValide()
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

        private bool connexionAdminValide()
        {
            string loginAdmin = "dedisk";
            //string mdpAdmin = "a3cd5e9@eelp0";
            string mdpAdmin = "admin";

            return loginConnexion.Text.Equals(loginAdmin) && mdpConnexion.Text.Equals(mdpAdmin);
        }
    }
}
