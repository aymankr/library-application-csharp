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
            Outils.musique = new MusiquePT2_NEntities();
        }
        //feedback avec de messages box


        public List<EMPRUNTER> listEmpruntProlong()
        {
            Outils.chargerDataGrid(new string[] { "Titre", "Nom", "Prénom" }, dataGridView1);

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
            Outils.chargerDataGrid(new string[] { "Nom", "Prénom" }, dataGridView1);
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
            Outils.chargerDataGrid(new string[] { "Titre" }, dataGridView1);
            DateTime dateNow = DateTime.Now;
            var emprunteurs = Outils.musique.EMPRUNTER
                .Where(a => a.DATE_EMPRUNT.Year == dateNow.Year)
                .OrderByDescending(a => a.ALBUMS.EMPRUNTER.Count).Take(10).ToList()
                .Select(a => a.ALBUMS).Distinct().ToList();

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
            Outils.chargerDataGrid(new string[] { "Nom", "Prénom" }, dataGridView1);

            // US6 remove abonnes qui n'ont pas empruntés depuis un an
            var empruntsExpires = Outils.musique.EMPRUNTER
                .Where(a => dateNow.Year - a.DATE_EMPRUNT.Year > 0).ToList();
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
            Outils.chargerDataGrid(new string[] { "Titre" }, dataGridView1);
            DateTime dateNow = DateTime.Now;

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
            /*var confirmResult = MessageBox.Show("Etes-vous sûr ?", "Déconnexion", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes) Close();*/
            Outils.Deconnexion(this);
        }

        private void listAbo_Click(object sender, EventArgs e)
        {
            Outils.chargerDataGrid(new string[] { "Nom", "Prénom" }, dataGridView1);
            var abos = Outils.musique.ABONNÉS.ToList();

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
    }
}
