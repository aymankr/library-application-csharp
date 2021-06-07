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
    public partial class Connexion : Form
    {

        public static int id_abonné { get; set; }

        public Connexion()
        {
            InitializeComponent();
            Outils.musique = new MusiquePT2_NEntities();
        }

        private void inscription_Click(object sender, EventArgs e)
        {
            Inscription inscription = new Inscription();
            inscription.ShowDialog();
        }

        private void connexion_Click(object sender, EventArgs e)
        {
            string login = loginConnexion.Text;
            string mdp = mdpConnexion.Text;
            if (connexionAdminValide())
            {
                Administrateur administrateur = new Administrateur();
                administrateur.ShowDialog();
            }
            else if (connexionValide(login, mdp))
            {
                id_abonné = ABONNÉS.RechercheAbonne(login);

                RechercheAlbumEtEmprunt emprunt = new RechercheAlbumEtEmprunt();
                emprunt.ShowDialog();
            }
            else
            {
                MessageBox.Show("Connexion échouée.");
            }
        }

        private bool connexionValide(string login, string mdp)
        {
            bool valide = false;
            var abonnes = (from a in Outils.musique.ABONNÉS
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
            string mdpAdmin = "admin";
            bool valide = false;

            if (loginConnexion.Text.Equals(loginAdmin) && mdpConnexion.Text.Equals(mdpAdmin)) valide = true;
            return valide;
        }
    }
}