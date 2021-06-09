﻿using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Dedisclasik
{
    public partial class Administrateur : Form
    {
        private String fonction = "";

        public Administrateur()
        {
            InitializeComponent();
            Outils.musique = new MusiquePT2_NEntities();
            prec.Enabled = false;
            suiv.Enabled = false;
        }
        //feedback avec de messages box


        public List<EMPRUNTER> listEmpruntProlong()
        {
            List<EMPRUNTER> listEmprunts = new List<EMPRUNTER>();

            var id_album = (from al in Outils.musique.ALBUMS
                            select al.CODE_ALBUM).ToList();
            foreach (EMPRUNTER emp in Outils.musique.EMPRUNTER)
            {
                if (Outils.dejaProlongé(emp))
                {
                    listEmprunts.Add(emp);
                }
            }
            return listEmprunts;
        }

        public List<EMPRUNTER> listEmpruntRetard()
        {
            List<EMPRUNTER> abos = new List<EMPRUNTER>();
            DateTime dateNow = DateTime.Now;

            var emprunteurs = Outils.musique.EMPRUNTER
                .Where(a => a.DATE_RETOUR == null).ToList()
                .Where(a => (int)(dateNow - a.DATE_RETOUR_ATTENDUE).TotalDays >= 10).ToList();
            foreach (EMPRUNTER a in emprunteurs)
            {
                abos.Add(a);
            }
            return abos;
        }

        public List<ALBUMS> listMeilleurEmprunt()
        {
            List<ALBUMS> albums = new List<ALBUMS>();
            DateTime dateNow = DateTime.Now;
            var emprunteurs = Outils.musique.EMPRUNTER
                .Where(a => a.DATE_EMPRUNT.Year == dateNow.Year)
                .OrderByDescending(a => a.ALBUMS.EMPRUNTER.Count).Take(10).ToList()
                .Select(a => a.ALBUMS).Distinct();
            foreach (ALBUMS a in emprunteurs)
            {
                albums.Add(a);
            }
            return albums;
        }

        public List<ABONNÉS> listAbonnesPurge()
        {
            List<ABONNÉS> abos = new List<ABONNÉS>();
            DateTime dateNow = DateTime.Now;
            var abonnesExpires = Outils.musique.EMPRUNTER
                .Where(a => dateNow.Year - a.DATE_EMPRUNT.Year > 0)
                .Select(a => a.ABONNÉS).ToList();

            foreach (ABONNÉS a in abonnesExpires)
            {
                abos.Add(a);
            }
            return abos;
        }

        public List<ALBUMS> listAlbumNonEmprunt()
        {
            List<ALBUMS> albs = new List<ALBUMS>();
            DateTime dateNow = DateTime.Now;
            var cmd = Outils.musique.EMPRUNTER
                .Where(a => dateNow.Year - a.DATE_EMPRUNT.Year > 0)
                .Select(a => a.ALBUMS);
            activePaging(cmd.Count());
            //  US8 : liste albums non empruntés depuis + d'un an 
            var albums = Outils.musique.EMPRUNTER
                .Where(a => a.DATE_RETOUR == null)
                .Where(a => dateNow.Year - a.DATE_EMPRUNT.Year >= 1)
                .Select(a => a.ALBUMS).ToList().Distinct();

            foreach (ALBUMS a in albums)
            {
                albs.Add(a);
            }
            return albs;
        }

        private bool afficherDescription(string boutonSousTitre)
        {
            sousTitre.Text = boutonSousTitre;
            bool estVide = false;
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Liste vide.");
                estVide = true;
            }
            return estVide;
        }

        private void deconnect_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Etes-vous sûr ?", "Déconnexion", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes) Close();
        }

        private void listAbo_Click(object sender, EventArgs e)
        {

        }

        private void empruntsProlongésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelRecherche.Text = "Recherche par titre, nom ou prénom :";
            Outils.chargerDataGrid(3, new string[] { "Titre", "Nom", "Prénom" }, dataGridView1);

            // US4 : abonnés ayant prolongé leur emprunt
            var id_album = from al in Outils.musique.ALBUMS
                           select al.CODE_ALBUM;
            foreach (EMPRUNTER emp in listEmpruntProlong())
            {
                dataGridView1.Rows.Add(new string[] { emp.ALBUMS.TITRE_ALBUM, emp.ABONNÉS.NOM_ABONNÉ, emp.ABONNÉS.PRÉNOM_ABONNÉ });
            }
            afficherDescription("Emprunts qui ont été prolongés.");
        }

        private void empruntsEnRetardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelRecherche.Text = "Recherche par titre, nom ou prénom :";
            Outils.chargerDataGrid(3, new string[] { "Titre", "Nom", "Prénom" }, dataGridView1);

            foreach (EMPRUNTER emp in listEmpruntRetard())
            {
                dataGridView1.Rows.Add(new string[] { emp.ALBUMS.TITRE_ALBUM, emp.ABONNÉS.NOM_ABONNÉ, emp.ABONNÉS.PRÉNOM_ABONNÉ });
            }
            afficherDescription("Abonnés ayant des empruntés non rapportés depuis 10 jours.");
        }

        private void top10MeilleursEmpruntsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelRecherche.Text = "Recherche par titre :";
            Outils.chargerDataGrid(2, new string[] { "Titre", "Nombre emprunts" }, dataGridView1);

            // US7 : les 10 plus empruntés de l'année
            foreach (ALBUMS a in listMeilleurEmprunt())
            {
                dataGridView1.Rows.Add(new string[] { a.TITRE_ALBUM, a.EMPRUNTER.Count.ToString() });
            }
            afficherDescription("Les 10 albums les plus empruntés dans l'année.");
        }

        private void albumsNonEmpruntésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelRecherche.Text = "Recherche par titre :";
            Outils.chargerDataGrid(1, new string[] { "Titre" }, dataGridView1);

            //  US8 : liste albums non empruntés depuis + d'un an 
            foreach (ALBUMS a in listAlbumNonEmprunt()) dataGridView1.Rows.Add(new string[] { a.TITRE_ALBUM });
            afficherDescription("Albums non empruntés depuis plus d'un an.");
        }

        private void consulterLesAbonnésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelRecherche.Text = "Recherche par nom ou prénom :";
            Outils.chargerDataGrid(2, new string[] { "Nom", "Prénom" }, dataGridView1);
            var abos = cmd.ToList().Take(Outils.pgSz * Outils.pgNb).Skip(Outils.pgSz * (Outils.pgNb - 1));

            // US 12 liste des abonnés
            foreach (ABONNÉS a in abos)
            {
                string[] row = new string[] { a.NOM_ABONNÉ, a.PRÉNOM_ABONNÉ };
                dataGridView1.Rows.Add(row);
            }
            afficherDescription("Liste des abonnés.");
        }

        private void purgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Outils.chargerDataGrid(2, new string[] { "Nom", "Prénom" }, dataGridView1);
            DateTime dateNow = DateTime.Now;

            // US6 remove abonnes qui n'ont pas empruntés depuis un an
            foreach (ABONNÉS a in listAbonnesPurge())
            {
                dataGridView1.Rows.Add(new string[] { a.NOM_ABONNÉ, a.PRÉNOM_ABONNÉ });
            }

            if (!afficherDescription("Purger les abonnés n'ayant pas emprunté depuis plus d'un an."))
            {
                var confirmResult = MessageBox.Show("Êtes-vous sûr de vouloir tout supprimer ?", "Purger", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    var empruntsExpires = Outils.musique.EMPRUNTER
                        .Where(a => dateNow.Year - a.DATE_EMPRUNT.Year > 0).ToList();
                    var abonnesExpires = Outils.musique.EMPRUNTER
                        .Where(a => dateNow.Year - a.DATE_EMPRUNT.Year > 0)
                        .Select(a => a.ABONNÉS).ToList();
                    Outils.musique.EMPRUNTER.RemoveRange(empruntsExpires);
                    Outils.musique.ABONNÉS.RemoveRange(abonnesExpires);
                    Outils.musique.SaveChanges();
                }
            }
        }

        private void recherche_TextChanged(object sender, EventArgs e)
        {
            bool contientNom = dataGridView1.Columns.Contains("Nom");
            bool contientPrenom = dataGridView1.Columns.Contains("Prénom");

            //pour abonnés
            dataGridView1.Rows.OfType<DataGridViewRow>()
                .ToList().ForEach(row => row.Visible = false);

            //recherche avancée
            dataGridView1.Rows.OfType<DataGridViewRow>().Where(r => dataGridView1.Columns.Contains("Titre") && r.Cells["Titre"]
            .Value.ToString().Trim().ToLower().Contains(recherche.Text.ToString().ToLower())
            || (contientNom && r.Cells["Nom"]
            .Value.ToString().Trim().ToLower().Contains(recherche.Text.ToString().ToLower()))
            || (contientPrenom && r.Cells["Prénom"]
            .Value.ToString().Trim().ToLower().Contains(recherche.Text.ToString().ToLower())))
                .ToList().ForEach(row => row.Visible = true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fonction = "test";
            var cmd = Outils.musique.EDITEURS;
            activePaging(cmd.Count());

            Outils.chargerDataGrid(1, new string[] { "Titre" }, dataGridView1);
            var affiche = cmd.ToList().Take(Outils.pgSz * Outils.pgNb).Skip(Outils.pgSz * (Outils.pgNb - 1));
            foreach (EDITEURS a in affiche)
            {
                string[] row = new string[] { a.CODE_EDITEUR.ToString() };
                dataGridView1.Rows.Add(row);
            }
            afficherMessageVide(listAbo.Text + " : test paging");
        }
        #endregion

        #region Autres Bouttons
        private void deconnect_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Etes-vous sûr ?", "Déconnexion", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes) Close();
        }

        private void prec_Click(object sender, EventArgs e)
        {
            Outils.pgNb--;
            switchNextPrev(sender, e);
        }

        private void switchNextPrev(object sender, EventArgs e)
        {
            switch (fonction)
            {
                case "prolong":
                    empruntProlong_Click(sender, e);
                    break;
                case "retard":
                    empruntRetard_Click(sender, e);
                    break;
                case "top":
                    empruntMeilleurs_Click(sender, e);
                    break;
                case "fantome":
                    albumsNonEmprunts_Click(sender, e);
                    break;
                case "abo":
                    listAbo_Click(sender, e);
                    break;
                case "test":
                    button1_Click(sender, e);
                    break;

            }
        }
        private void suiv_Click(object sender, EventArgs e)
        {
            Outils.pgNb++;
            switchNextPrev(sender, e);
        }
        #endregion

        #region fonctions
        private bool afficherMessageVide(string boutonSousTitre)
        {
            sousTitre.Text = boutonSousTitre;
            bool estVide = false;
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Liste vide.");
                estVide = true;
            }
            return estVide;
        }
        private void activePaging(int nbMax)
        {
            prec.Enabled = true;
            suiv.Enabled = true;
            pg.Text = "Page : " + Outils.pgNb.ToString() + "/" + nbMax;
            if (Outils.pgNb <= 1)
            {
                prec.Enabled = false;
            }
            if (Outils.pgNb >= (int)(nbMax / Outils.pgSz) + 1)
            {
                suiv.Enabled = false;
            }
        }
        #endregion
    }
}
