﻿using System;
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
            mdp.UseSystemPasswordChar = true;
            mdp2.UseSystemPasswordChar = true;
        }

        private void ajout_Click(object sender, EventArgs e)
        {
            string nomAbonne = nom.Text;
            string prenomAbonne = prenom.Text;
            string loginAbonne = login.Text;
            string mdpAbonne = mdp.Text;
            string mdpVerifier = mdp2.Text;
            int limite = 32;

            if (nomAbonne.Equals("") || prenomAbonne.Equals("") || loginAbonne.Equals(""))
            {
                MessageBox.Show("Veuillez saisir les informations dans les champs spécifiés.");
            }
            else if (!mdp.Text.Equals(mdp2.Text)) MessageBox.Show("Mot de passe non confirmé.");
            else if (loginExiste(loginAbonne))
            {
                MessageBox.Show("Le login existe déjà, réessayez.");
            }
            else if (nomAbonne.Contains(" ") || prenomAbonne.Contains(" ") || loginAbonne.Contains(" ") || mdpAbonne.Contains(" "))
            {
                MessageBox.Show("Vous ne pouvez pas mettre d'espaces dans vos coordonnées, réessayez.");
            }
            else if (nomAbonne.Length >= limite || prenomAbonne.Length >= limite || loginAbonne.Length >= limite || mdpAbonne.Length >= limite || mdpVerifier.Length >= limite)
            {
                MessageBox.Show("Vous ne pouvez pas saisir plus de " + limite + " caractères par champs"); 
            }
            else
            {
                MessageBox.Show("Inscription réussie !");
                inscrire(nomAbonne, prenomAbonne, loginAbonne, mdpAbonne);
                new Connexion().ShowDialog();
                Close();
            }
        }

        public void inscrire(string nomAbonne, string prenomAbonne, string loginAbonne, string mdpAbonne)
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

        private void oeilMdp_Click(object sender, EventArgs e)
        {
            if (mdp.UseSystemPasswordChar)
            {
                mdp.UseSystemPasswordChar = false;
            }
            else
            {
                mdp.UseSystemPasswordChar = true;
            }
        }

        private void mdpVerif_Click(object sender, EventArgs e)
        {
            if (mdp2.UseSystemPasswordChar)
            {
                mdp2.UseSystemPasswordChar = false;
            }
            else
            {
                mdp2.UseSystemPasswordChar = true;
            }
        }
    }
}
