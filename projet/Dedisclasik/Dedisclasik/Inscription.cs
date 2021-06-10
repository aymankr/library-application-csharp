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
    public partial class Inscription : Form
    {
        MusiquePT2_NEntities musique = Outils.musique;

        public Inscription()
        {
            InitializeComponent();
            chargeListPays();
        }

        private void ajout_Click(object sender, EventArgs e)
        {
            string nomAbonne = nom.Text;
            string prenomAbonne = prenom.Text;
            string loginAbonne = login.Text;
            string mdpAbonne = mdp.Text;

            if (nomAbonne.Equals("") || prenomAbonne.Equals("") || loginAbonne.Equals(""))
            {
                MessageBox.Show("Veuillez saisir les informations dans les champs spécifiés.");
            }
            else if (!mdp.Text.Equals(mdp2.Text)) MessageBox.Show("Mot de passe non confirmé.");
            else if (loginExiste(loginAbonne))
            {
                MessageBox.Show("Le login existe déjà, réessayez.");
            }
            else
            {
                inscrire(nomAbonne, prenomAbonne, loginAbonne, mdpAbonne);
                new Connexion().ShowDialog();
                Close();
            }
        }

        public void inscrire(string nomAbonne, string prenomAbonne,string loginAbonne, string mdpAbonne)
        {
            musique = new MusiquePT2_NEntities();
            ABONNÉS abonne = new ABONNÉS();
            abonne.NOM_ABONNÉ = nomAbonne;
            abonne.PRÉNOM_ABONNÉ = prenomAbonne;
            abonne.LOGIN_ABONNÉ = loginAbonne;
            abonne.PASSWORD_ABONNÉ = mdpAbonne;
            if (listPaysBox.SelectedItem != null)
            {
                string paysAbonne = listPaysBox.SelectedItem.ToString().Trim();
                var pays = (from p in musique.PAYS
                            where paysAbonne.Equals(p.NOM_PAYS.Trim())
                            select p.CODE_PAYS);
                abonne.CODE_PAYS = pays.First();
            }
            musique.ABONNÉS.Add(abonne);
            musique.SaveChanges();
        }

        private bool loginExiste(string chaine)
        {
            bool existe = false;
            var abonnes = (from a in musique.ABONNÉS
                           select a).ToList();

            foreach (ABONNÉS a in abonnes)
            {
                if (a.LOGIN_ABONNÉ.Trim().Equals(chaine) || chaine.Equals("testdu33")) existe = true;
            }

            return existe;
        }

        private void chargeListPays()
        {
            musique = new MusiquePT2_NEntities();
            var pays = (from p in musique.PAYS
                        select p.NOM_PAYS.Trim()).ToArray();
            listPaysBox.Items.AddRange(pays);
        }
    }
}
