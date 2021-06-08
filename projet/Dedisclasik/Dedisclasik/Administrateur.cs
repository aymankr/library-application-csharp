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
    public partial class Administrateur : Form
    {
        public Administrateur()
        {
            InitializeComponent();
        }
        //feedback avec de messages box

        private void empruntProlong_Click(object sender, EventArgs e)
        {
            chargerDataGrid(3);

            // US4 : abonnés ayant prolongé leur emprunt
            var id_album = from al in Outils.musique.ALBUMS
                           select al.CODE_ALBUM;
            foreach (EMPRUNTER emp in Outils.musique.EMPRUNTER)
            {
                if (Outils.dejaProlongé(emp))
                {
                    string[] row = new string[] { emp.ALBUMS.TITRE_ALBUM, emp.ABONNÉS.NOM_ABONNÉ, emp.ABONNÉS.PRÉNOM_ABONNÉ };
                    dataGridView1.Rows.Add(row);
                }
            }
            afficherMessageVide();
        }

        private void empruntRetard_Click(object sender, EventArgs e)
        {
            chargerDataGrid(2);
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
            afficherMessageVide();
        }

        private void empruntMeilleurs_Click(object sender, EventArgs e)
        {
            chargerDataGrid(1);
            DateTime dateNow = DateTime.Now;

            // US7 : les 10 plus empruntés de l'année
            var emprunteurs = Outils.musique.EMPRUNTER
                .Where(a => a.DATE_EMPRUNT.Year == dateNow.Year)
                .OrderByDescending(a => a.ALBUMS.EMPRUNTER.Count).Take(10).ToList()
                .Select(a => a.ALBUMS);
            foreach (ALBUMS a in emprunteurs) dataGridView1.Rows.Add(a.TITRE_ALBUM);
            afficherMessageVide();
        }

        private void purger_Click(object sender, EventArgs e)
        {
            DateTime dateNow = DateTime.Now;
            chargerDataGrid(2);

            // US6 remove abonnes qui n'ont pas empruntés depuis un an
            var empruntsExpires = Outils.musique.EMPRUNTER
                .Where(a => dateNow.Year - a.DATE_EMPRUNT.Year > 0).ToList();
            var abonnesExpires = Outils.musique.EMPRUNTER
                .Where(a => dateNow.Year - a.DATE_EMPRUNT.Year > 0)
                .Select(a => a.ABONNÉS).ToList();
            foreach(ABONNÉS a in abonnesExpires)
            {
                string[] row = new string[] { a.NOM_ABONNÉ, a.PRÉNOM_ABONNÉ };
                dataGridView1.Rows.Add(row);
            }

            if (!afficherMessageVide())
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
            chargerDataGrid(1);
            DateTime dateNow = DateTime.Now;

            //  US8 : liste albums non empruntés depuis + d'un an 
            //DateTime dernierEmprunt = musique.EMPRUNTER.OrderByDescending(a => a.DATE_EMPRUNT).Select(a => a.DATE_EMPRUNT).FirstOrDefault();

            var emprunteurs = Outils.musique.EMPRUNTER
                .Where(a => dateNow.Year - a.DATE_EMPRUNT.Year > 0)
                .Select(a => a.ALBUMS).ToList();
            foreach (ALBUMS a in emprunteurs) dataGridView1.Rows.Add(a.TITRE_ALBUM);
            afficherMessageVide();
        }

        private void chargerDataGrid(int nbColonnes)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = nbColonnes;
            if (nbColonnes == 1)
            {
                dataGridView1.Columns[0].Name = "Titre";
                dataGridView1.Columns[0].Width = dataGridView1.Width;
            }
            else if (nbColonnes == 2)
            {
                dataGridView1.Columns[0].Name = "Nom";
                dataGridView1.Columns[0].Width = dataGridView1.Width / 2;
                dataGridView1.Columns[1].Name = "Prénom";
                dataGridView1.Columns[1].Width = dataGridView1.Width / 2;
            }
            else
            {
                dataGridView1.Columns[0].Name = "Titre";
                dataGridView1.Columns[0].Width = dataGridView1.Width / 2;
                dataGridView1.Columns[1].Name = "Nom";
                dataGridView1.Columns[1].Width = dataGridView1.Width / 5;
                dataGridView1.Columns[2].Name = "Prénom";
                dataGridView1.Columns[2].Width = dataGridView1.Width / 5;
            }
        }

        private bool afficherMessageVide()
        {
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
    }
}
