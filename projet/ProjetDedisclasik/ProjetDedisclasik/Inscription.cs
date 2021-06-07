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
    public partial class Inscription : Form
    {
        MusiquePT2_NEntities musique;

        public Inscription(MusiquePT2_NEntities musique)
        {
            InitializeComponent();
            this.musique = musique;
            chargerListPays();
            chargerListAbonnes();
        }

        private void ajout_Click(object sender, EventArgs e)
        {
            ABONNÉS abonne = new ABONNÉS();

            string nomAbonne = nom.Text;
            string prenomAbonne = prenom.Text;
            string loginAbonne = login.Text;
            string mdpAbonne = mdp.Text;
            
            abonne.NOM_ABONNÉ = nomAbonne;
            abonne.PRÉNOM_ABONNÉ = prenomAbonne;
            abonne.LOGIN_ABONNÉ = loginAbonne;
            abonne.PASSWORD_ABONNÉ = mdpAbonne;

            if (nomAbonne.Equals("") || prenomAbonne.Equals("") || loginAbonne.Equals("") || listPaysBox.SelectedItem == null)
            {
                MessageBox.Show("Veuillez saisir les informations dans les champs spécifiés.");
            }
            else if (loginExiste(loginAbonne))
            {
                MessageBox.Show("Le login existe déjà, réessayez.");
            }
            else
            {
                string paysAbonne = listPaysBox.SelectedItem.ToString();
                var pays = (from p in musique.PAYS
                            where paysAbonne.Trim() == p.NOM_PAYS
                            select p.CODE_PAYS);
                abonne.CODE_PAYS = pays.First();
                musique.ABONNÉS.Add(abonne);
                musique.SaveChanges();
                chargerListAbonnes();
                Close();
            }
        }

        private void chargerListAbonnes()
        {
            var abonnes = (from a in musique.ABONNÉS
                           orderby a.NOM_ABONNÉ
                           select a).ToList();
            listAbonnes.Items.Clear();
            foreach (ABONNÉS a in abonnes)
            {
                string noms = a.PRÉNOM_ABONNÉ.Trim() + " " +  a.NOM_ABONNÉ;
                listAbonnes.Items.Add(noms);
            }
        }

        private bool loginExiste(string chaine)
        {
            bool existe = false;
            var abonnes = (from a in musique.ABONNÉS
                           select a).ToList();
           
            foreach (ABONNÉS a in abonnes)
            {
                if (a.LOGIN_ABONNÉ.Trim().Equals(chaine)) existe = true;
            }

            return existe;
        }

        private void chargerListPays()
        {
            var pays = (from p in musique.PAYS
                        select p.NOM_PAYS.Trim()).ToArray();
            listPaysBox.Items.AddRange(pays);
        }
    }
}
