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
    public partial class InterfaceTemp : Form
    {
        public InterfaceTemp()
        {
            InitializeComponent();
            afficherEmprunts(EMPRUNTER.ListeAlbums(Connexion.id_abonné));
            Prolonger.Enabled = false;
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

        private void Prolonger_Click(object sender, EventArgs e)
        {
            if (albumEmprunt.SelectedItem != null)
            {
                string titre = albumEmprunt.SelectedItem.ToString();
                var id_album = from al in Outils.musique.ALBUMS
                               where al.TITRE_ALBUM == titre
                               select al.CODE_ALBUM;
                foreach (EMPRUNTER emp in Outils.musique.EMPRUNTER)
                {
                    if (emp.CODE_ALBUM == id_album.First())
                    {
                        if (!dejaProlongé(emp))
                        {
                            emp.DATE_RETOUR_ATTENDUE = emp.DATE_RETOUR_ATTENDUE.AddMonths(1);
                            MessageBox.Show("Prolongement effectué");
                        }
                        else
                        {
                            Prolonger.Enabled = false;
                            MessageBox.Show("Album déjà prolongé");
                        }
                    }
                }
            }
            Outils.musique.SaveChanges();
        }

        public bool dejaProlongé(EMPRUNTER emprunt)
        {
            bool dejaProlongé = true;
            TimeSpan temps = emprunt.DATE_RETOUR_ATTENDUE - emprunt.DATE_EMPRUNT;
            if (int.Parse(temps.Days.ToString()) <= emprunt.ALBUMS.GENRES.DÉLAI)
            {
                dejaProlongé = false;
            }
            return dejaProlongé;
        }

        private void albumEmprunt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string titre = albumEmprunt.SelectedItem.ToString();
            var id_album = from al in Outils.musique.ALBUMS
                           where al.TITRE_ALBUM == titre
                           select al.CODE_ALBUM;
            foreach (EMPRUNTER emp in Outils.musique.EMPRUNTER)
            {
                if (emp.CODE_ALBUM == id_album.First())
                {
                    dateRetourAttendue.Text = emp.DATE_RETOUR_ATTENDUE.ToString();
                    if (dejaProlongé(emp))
                    {
                        Prolonger.Enabled = false;
                    }
                    else
                    {
                        Prolonger.Enabled = true;
                    }
                }
            }
        }
    }
}