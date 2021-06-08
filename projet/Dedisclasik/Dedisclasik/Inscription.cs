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
                new Connexion().ShowDialog();
                Close();
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

        private void chargeListPays()
        {
            var pays = (from p in musique.PAYS
                        select p.NOM_PAYS.Trim()).ToArray();
            listPaysBox.Items.AddRange(pays);
        }
    }
}
