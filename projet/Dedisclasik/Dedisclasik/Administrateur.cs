using PagedList;
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
            prec.Enabled = false;
            suiv.Enabled = false;
        }
        //feedback avec de messages box
        
        #region bouttons requetes
        private void empruntProlong_Click(object sender, EventArgs e)
        {
            fonction = "prolong";
            Outils.chargerDataGrid(3, new string[] { "Titre", "Nom", "Prénom" }, dataGridView1);
            var cmd = Outils.musique.EMPRUNTER;
            int nbT = 0;
            foreach (EMPRUNTER empr in cmd)
            {
                if (Outils.dejaProlongé(empr))
                {
                    nbT++;
                }
            }
            activePaging(nbT);
            // US4 : abonnés ayant prolongé leur emprunt 
            var prolong = cmd.ToList().Take(Outils.pgSz * Outils.pgNb).Skip(Outils.pgSz * (Outils.pgNb - 1));
            foreach (EMPRUNTER emp in prolong)
            {
                if (Outils.dejaProlongé(emp))
                {
                    string[] row = new string[] { emp.ALBUMS.TITRE_ALBUM, emp.ABONNÉS.NOM_ABONNÉ, emp.ABONNÉS.PRÉNOM_ABONNÉ };
                    dataGridView1.Rows.Add(row);
                }
            }
            afficherMessageVide(empruntProlong.Text + " : emprunts qui ont été prolongés.");
        }

        private void empruntRetard_Click(object sender, EventArgs e)
        {
            fonction = "retard";
            Outils.chargerDataGrid(2, new string[] { "Nom", "Prénom" }, dataGridView1);
            DateTime dateNow = DateTime.Now;

            // US5 : abonnés ayant emprunts non rendu depuis plus de 10j
            var emprunteurs = Outils.musique.EMPRUNTER
                .Where(a => a.DATE_RETOUR == null).ToList()
                .Where(a => (int)(dateNow - a.DATE_RETOUR_ATTENDUE).TotalDays >= 10).Select(a => a.ABONNÉS);

            foreach (ABONNÉS a in emprunteurs)
            {
                string[] row = new string[] { a.NOM_ABONNÉ, a.PRÉNOM_ABONNÉ };
                dataGridView1.Rows.Add(row);
            }
            afficherMessageVide(empruntRetard.Text + " : abonnés ayant des empruntés non rapportés depuis 10 jours.");
        }

        private void empruntMeilleurs_Click(object sender, EventArgs e)
        {
            fonction = "top";
            Outils.chargerDataGrid(2, new string[] { "Titre", "Nombre d'emprunts" }, dataGridView1);
            DateTime dateNow = DateTime.Now;

            var cmd = Outils.musique.EMPRUNTER
                .Where(a => a.DATE_EMPRUNT.Year == dateNow.Year)
                .OrderByDescending(a => a.ALBUMS.EMPRUNTER.Count).Take(10).ToList()
                .Select(a => a.ALBUMS);
            activePaging(cmd.Count());
            // US7 : les 10 plus empruntés de l'année
            var emprunteurs = cmd.ToList().Take(Outils.pgSz * Outils.pgNb).Skip(Outils.pgSz * (Outils.pgNb - 1));
            foreach (ALBUMS a in emprunteurs)
            {
                string[] row = new string[] { a.TITRE_ALBUM, a.EMPRUNTER.Count.ToString() };
                dataGridView1.Rows.Add(row);
            }
            afficherMessageVide(empruntMeilleurs.Text + " : les 10 albums les plus empruntés dans l'année.");
        }

        private void purger_Click(object sender, EventArgs e)
        {
            DateTime dateNow = DateTime.Now;
            Outils.chargerDataGrid(2, new string[] { "Nom", "Prénom" }, dataGridView1);
            // US6 remove abonnes qui n'ont pas empruntés depuis un an
            var empruntsExpires = Outils.musique.EMPRUNTER
                .Where(a => dateNow.Year - a.DATE_EMPRUNT.Year > 0).ToList();
            var abonnesExpires = Outils.musique.EMPRUNTER
                .Where(a => dateNow.Year - a.DATE_EMPRUNT.Year > 0)
                .Select(a => a.ABONNÉS).ToList();
            foreach (ABONNÉS a in abonnesExpires)
            {
                string[] row = new string[] { a.NOM_ABONNÉ, a.PRÉNOM_ABONNÉ };
                dataGridView1.Rows.Add(row);
            }

            if (!afficherMessageVide(purger.Text + " : purger les abonnés n'ayant pas emprunté depuis plus d'un an."))
            {
                var confirmResult = MessageBox.Show("Êtes-vous sûr de vouloir tout supprimer ?", "Purger", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    Outils.musique.EMPRUNTER.RemoveRange(empruntsExpires);
                    Outils.musique.ABONNÉS.RemoveRange(abonnesExpires);
                    Outils.musique.SaveChanges();
                }
            }
        }

        private void albumsNonEmprunts_Click(object sender, EventArgs e)
        {
            fonction = "fantome";
            Outils.chargerDataGrid(1, new string[] { "Titre" }, dataGridView1);
            DateTime dateNow = DateTime.Now;
            var cmd = Outils.musique.EMPRUNTER
                .Where(a => dateNow.Year - a.DATE_EMPRUNT.Year > 0)
                .Select(a => a.ALBUMS);
            activePaging(cmd.Count());
            //  US8 : liste albums non empruntés depuis + d'un an 
            //DateTime dernierEmprunt = musique.EMPRUNTER.OrderByDescending(a => a.DATE_EMPRUNT).Select(a => a.DATE_EMPRUNT).FirstOrDefault();

            var emprunteurs = cmd.ToList().Take(Outils.pgSz * Outils.pgNb).Skip(Outils.pgSz * (Outils.pgNb - 1));
            foreach (ALBUMS a in emprunteurs) dataGridView1.Rows.Add(a.TITRE_ALBUM);
            afficherMessageVide(albumsNonEmprunts.Text);
        }

        private void listAbo_Click(object sender, EventArgs e)
        {
            fonction = "abo";
            var cmd = Outils.musique.ABONNÉS;
            activePaging(cmd.Count());
            Outils.chargerDataGrid(2, new string[] { "Nom", "Prénom" }, dataGridView1);
            var abos = cmd.ToList().Take(Outils.pgSz * Outils.pgNb).Skip(Outils.pgSz * (Outils.pgNb - 1));

            // US 12 liste des abonnés
            foreach (ABONNÉS a in abos)
            {
                string[] row = new string[] { a.NOM_ABONNÉ, a.PRÉNOM_ABONNÉ };
                dataGridView1.Rows.Add(row);
            }
            afficherMessageVide(listAbo.Text + " : liste des abonnés.");
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
