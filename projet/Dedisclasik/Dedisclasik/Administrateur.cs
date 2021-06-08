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
            Outils.chargerDataGrid(3, new string[] { "Titre", "Nom", "Prénom"}, dataGridView1);

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
            afficherMessageVide(empruntProlong.Text + " : emprunts qui ont été prolongés.");
        }

        private void empruntRetard_Click(object sender, EventArgs e)
        {
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
            Outils.chargerDataGrid(1, new string[] { "Titre" }, dataGridView1);
            DateTime dateNow = DateTime.Now;

            // US7 : les 10 plus empruntés de l'année
            var emprunteurs = Outils.musique.EMPRUNTER
                .Where(a => a.DATE_EMPRUNT.Year == dateNow.Year)
                .OrderByDescending(a => a.ALBUMS.EMPRUNTER.Count).Take(10).ToList()
                .Select(a => a.ALBUMS);
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
            foreach(ABONNÉS a in abonnesExpires)
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
            Outils.chargerDataGrid(1, new string[] { "Titre" }, dataGridView1);
            DateTime dateNow = DateTime.Now;

            //  US8 : liste albums non empruntés depuis + d'un an 
            //DateTime dernierEmprunt = musique.EMPRUNTER.OrderByDescending(a => a.DATE_EMPRUNT).Select(a => a.DATE_EMPRUNT).FirstOrDefault();

            var emprunteurs = Outils.musique.EMPRUNTER
                .Where(a => dateNow.Year - a.DATE_EMPRUNT.Year > 0)
                .Select(a => a.ALBUMS).ToList();
            foreach (ALBUMS a in emprunteurs) dataGridView1.Rows.Add(a.TITRE_ALBUM);
            afficherMessageVide(albumsNonEmprunts.Text);
        }

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

        private void deconnect_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Etes-vous sûr ?", "Déconnexion", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes) Close();
        }

        private void listAbo_Click(object sender, EventArgs e)
        {
           
        }
    }
}
