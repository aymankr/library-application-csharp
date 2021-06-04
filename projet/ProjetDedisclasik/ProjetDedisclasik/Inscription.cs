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
            chargeListAbonnes();
        }

        private void ajout_Click(object sender, EventArgs e)
        {
            ABONNÉS abonne = new ABONNÉS();

            String nomAbonne = nom.Text;
            String prenomAbonne = prenom.Text;
            String loginAbonne = login.Text;
            String mdpAbonne = mdp.Text;

            abonne.NOM_ABONNÉ = nomAbonne;
            abonne.PRÉNOM_ABONNÉ = prenomAbonne;
            abonne.LOGIN_ABONNÉ = loginAbonne;
            abonne.PASSWORD_ABONNÉ = mdpAbonne;
            Console.WriteLine(abonne.LOGIN_ABONNÉ);

            if (nomAbonne.Equals("") || prenomAbonne.Equals("") || loginAbonne.Equals(""))
            {
                MessageBox.Show("Veuillez saisir les informations dans les champs spécifiés.");
            }
            else if (loginExiste(loginAbonne))
            {
                MessageBox.Show("Le login existe déjà, réessayez.");
            }
            else
            {
                musique.ABONNÉS.Add(abonne);
                musique.SaveChanges();
                chargeListAbonnes();
                Close();
            }
        }

        private void chargeListAbonnes()
        {
            var abonnes = (from a in musique.ABONNÉS
                           orderby a.NOM_ABONNÉ
                           select a).ToList();
            listAbonnes.Items.Clear();
            foreach (ABONNÉS a in abonnes)
            {
                String noms = a.PRÉNOM_ABONNÉ.Trim() + " " +  a.NOM_ABONNÉ;
                listAbonnes.Items.Add(noms);
            }
        }

        private bool loginExiste(String chaine)
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


    }
}
