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
            fermerLaFenetre();
        }

        private void connexion_Click(object sender, EventArgs e)
        {
            String login = loginConnexion.Text;
            String mdp = mdpConnexion.Text;
            if (connexionValide(login, mdp))
            {
                id_abonné = ABONNÉS.RechercheAbonne(login);
                RechercheAlbumEtEmprunt emprunt = new RechercheAlbumEtEmprunt();
                emprunt.ShowDialog();
                fermerLaFenetre();
            }
        }

        private bool connexionValide(String login, String mdp)
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

        public void fermerLaFenetre()
        {
            this.Close();
        }
    }
}