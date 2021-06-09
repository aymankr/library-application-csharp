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

        private void empruntProlong_Click(object sender, EventArgs e)
        {
            Outils.chargerDataGrid(3, new string[] { "Titre", "Nom", "Prénom" }, dataGridView1);

            // US4 : abonnés ayant prolongé leur emprunt
            var id_album = from al in Outils.musique.ALBUMS
                           select al.CODE_ALBUM;
            foreach (EMPRUNTER emp in listEmpruntProlong())
            {
                dataGridView1.Rows.Add(new string[] { emp.ALBUMS.TITRE_ALBUM, emp.ABONNÉS.NOM_ABONNÉ, emp.ABONNÉS.PRÉNOM_ABONNÉ });
            }
            afficherDescription(empruntProlong.Text + " : emprunts qui ont été prolongés.");
        }

        public List<ABONNÉS> listEmpruntRetard()
        {
            List<ABONNÉS> abos = new List<ABONNÉS>();
            DateTime dateNow = DateTime.Now;
            Outils.musique = new MusiquePT2_NEntities(); // nécessaire pour la synchronisation pour le .SaveChanges de la base

            var emprunteurs = Outils.musique.EMPRUNTER
                .Where(a => a.DATE_RETOUR == null).ToList()
                .Where(a => (int)(dateNow - a.DATE_RETOUR_ATTENDUE).TotalDays >= 10).Select(a => a.ABONNÉS);
            foreach (ABONNÉS a in emprunteurs)
            {
                abos.Add(a);
            }
            return abos;
        }

        private void empruntRetard_Click(object sender, EventArgs e)
        {
            Outils.chargerDataGrid(2, new string[] { "Nom", "Prénom" }, dataGridView1);

            foreach (ABONNÉS a in listEmpruntRetard())
            {
                dataGridView1.Rows.Add(new string[] { a.NOM_ABONNÉ, a.PRÉNOM_ABONNÉ });
            }
            afficherDescription(empruntRetard.Text + " : abonnés ayant des empruntés non rapportés depuis 10 jours.");
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

        private void empruntMeilleurs_Click(object sender, EventArgs e)
        {
            Outils.chargerDataGrid(2, new string[] { "Titre", "Nombre emprunts" }, dataGridView1);

            // US7 : les 10 plus empruntés de l'année
            foreach (ALBUMS a in listMeilleurEmprunt())
            {
                dataGridView1.Rows.Add(new string[] { a.TITRE_ALBUM, a.EMPRUNTER.Count.ToString() });
            }
            afficherDescription(empruntMeilleurs.Text + " : les 10 albums les plus empruntés dans l'année.");
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

        private void purger_Click(object sender, EventArgs e)
        {
            Outils.chargerDataGrid(2, new string[] { "Nom", "Prénom" }, dataGridView1);
            DateTime dateNow = DateTime.Now;

            // US6 remove abonnes qui n'ont pas empruntés depuis un an
            foreach (ABONNÉS a in listAbonnesPurge())
            {
                dataGridView1.Rows.Add(new string[] { a.NOM_ABONNÉ, a.PRÉNOM_ABONNÉ });
            }

            if (!afficherDescription(purger.Text + " : purger les abonnés n'ayant pas emprunté depuis plus d'un an."))
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

        public List<ALBUMS> listAlbumNonEmprunt()
        {
            List<ALBUMS> albs = new List<ALBUMS>();
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

        private void albumsNonEmprunts_Click(object sender, EventArgs e)
        {
            Outils.chargerDataGrid(1, new string[] { "Titre" }, dataGridView1);

            //  US8 : liste albums non empruntés depuis + d'un an 
            foreach (ALBUMS a in listAlbumNonEmprunt()) dataGridView1.Rows.Add(new string[] { a.TITRE_ALBUM });
            afficherDescription(albumsNonEmprunts.Text + " : albums non empruntés depuis plus d'un an.");
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
            Outils.chargerDataGrid(2, new string[] { "Nom", "Prénom" }, dataGridView1);
            var abos = Outils.musique.ABONNÉS.ToList();

            // US 12 liste des abonnés
            foreach (ABONNÉS a in abos)
            {
                string[] row = new string[] { a.NOM_ABONNÉ, a.PRÉNOM_ABONNÉ };
                dataGridView1.Rows.Add(row);
            }
            afficherDescription(listAbo.Text + " : liste des abonnés.");
        }
    }
}
