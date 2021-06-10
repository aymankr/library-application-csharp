﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dedisclasik
{
    public partial class MonCompte : Form
    {
        private int numColonne = 4;

        public MonCompte()
        {
            InitializeComponent();

            initDataGridView();
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.HeaderText = "Pochette";
            img.Width = dataGridEmprunt.Width / 6;
            dataGridEmprunt.Columns.Insert(numColonne, img);

            afficherEmprunts(EMPRUNTER.ListeAlbums());

            Prolonger.Enabled = false;
            vérifcationToutProlonger();

            nomUtilisateur.Text = Connexion.abonné.NOM_ABONNÉ.ToString();
            prenomUtilisateur.Text = Connexion.abonné.PRÉNOM_ABONNÉ.ToString();
            loginUtilisateur.Text = Connexion.abonné.LOGIN_ABONNÉ.ToString();
        }

        public void afficherEmprunts(List<ALBUMS> albums)
        {
            string editeur;
            string annee;
            string genre;

            dataGridEmprunt.Rows.Clear();
            if (Connexion.abonné.EMPRUNTER != null)
            {
                int i = 0;
                foreach (ALBUMS al in albums)
                {
                    dataGridEmprunt.RowTemplate.Height = 100;

                    if (al.GENRES != null) { genre = al.GENRES.LIBELLÉ_GENRE.ToString(); } else { genre = "Non rensigné"; }
                    if (al.EDITEURS != null) { editeur = al.EDITEURS.NOM_EDITEUR.ToString(); } else { editeur = "Non renseigné"; }
                    if (al.ANNÉE_ALBUM != null) { annee = al.ANNÉE_ALBUM.ToString(); } else { annee = "Non renseigné"; }
                    string[] row = { al.TITRE_ALBUM, genre, editeur, annee };

                    dataGridEmprunt.Rows.Add(row);
                    dataGridEmprunt.Rows[i].Cells[numColonne].Value = ImagePochette(al.POCHETTE);
                    i++;
                }
            }
            else
            {
                string[] row = { "Aucun emprunt en cours" };
                dataGridEmprunt.Rows.Add(row);
            }

        }

        private void voirAlbums_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Prolonger_Click(object sender, EventArgs e)
        {
            if (dataGridEmprunt[0, dataGridEmprunt.CurrentCell.RowIndex].Value != null
                       && !dataGridEmprunt[0, dataGridEmprunt.CurrentCell.RowIndex].Value.ToString().Contains("Aucun emprunt en cours"))
            {
                string titre = dataGridEmprunt[0, dataGridEmprunt.CurrentCell.RowIndex].Value.ToString().Trim();

                var id_album = from al in Outils.musique.ALBUMS
                               where al.TITRE_ALBUM == titre
                               select al.CODE_ALBUM;
                foreach (EMPRUNTER emp in Connexion.abonné.EMPRUNTER)
                {
                    if (emp.CODE_ALBUM == id_album.First())
                    {
                        if (!Outils.dejaProlongé(emp))
                        {
                            emp.DATE_RETOUR_ATTENDUE = emp.DATE_RETOUR_ATTENDUE.AddMonths(1);
                            dateRetourAttendue.Text = emp.DATE_RETOUR_ATTENDUE.ToString();
                            Prolonger.Enabled = false;
                            MessageBox.Show("Prolongement effectué pour : \n" + titre);
                            vérifcationToutProlonger();
                        }
                    }
                }
            }
            Outils.musique.SaveChanges();
        }

        private void ToutProlonger_Click(object sender, EventArgs e)
        {
            List<string> prolongés = new List<string>();
            foreach (DataGridViewRow row in dataGridEmprunt.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string titre = row.Cells[0].Value.ToString();
                    var id_album = from al in Outils.musique.ALBUMS
                                   where al.TITRE_ALBUM == titre
                                   select al.CODE_ALBUM;
                    foreach (EMPRUNTER emp in Connexion.abonné.EMPRUNTER)
                    {
                        if (emp.CODE_ALBUM == id_album.First())
                        {
                            if (!Outils.dejaProlongé(emp))
                            {
                                prolongés.Add(titre);
                                emp.DATE_RETOUR_ATTENDUE = emp.DATE_RETOUR_ATTENDUE.AddMonths(1);
                            }
                        }
                    }
                }
            }
            Outils.musique.SaveChanges();
            string resultat = String.Join("\n", prolongés.ToArray());
            MessageBox.Show("Prolongement effectué pour : \n" + resultat);
            ToutProlonger.Enabled = false;
            Prolonger.Enabled = false;
        }

        private void vérifcationToutProlonger()
        {
            ToutProlonger.Enabled = false;
            foreach (DataGridViewRow row in dataGridEmprunt.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string titre = row.Cells[0].Value.ToString();
                    var id_album = from al in Outils.musique.ALBUMS
                                   where al.TITRE_ALBUM == titre
                                   select al.CODE_ALBUM;
                    foreach (EMPRUNTER emp in Connexion.abonné.EMPRUNTER)
                    {
                        if (emp.CODE_ALBUM == id_album.First())
                        {
                            if (!Outils.dejaProlongé(emp))
                            {
                                ToutProlonger.Enabled = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void deconnexionButton_Click(object sender, EventArgs e)
        {
            /*this.Close();
            //new Connexion().ShowDialog(); //à vérifier
            MessageBox.Show("Vous avez été déconnecté");*/
            Outils.Deconnexion(this);
        }

        public void initDataGridView()
        {
            Outils.chargerDataGrid(new string[] { "Titre", "Genre", "Editeur", "Année" }, dataGridEmprunt); 
            Outils.chargerDataGrid(new string[] { "Titre", "Editeur", "Date", "Pays", "Genre", "Déjà emprunté" }, pagesAlbums);
        }

        private void dataGridEmprunt_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridEmprunt[0, dataGridEmprunt.CurrentCell.RowIndex].Value != null
                        && !dataGridEmprunt[0, dataGridEmprunt.CurrentCell.RowIndex].Value.ToString().Contains("Aucun emprunt en cours"))
            {
                string titre = dataGridEmprunt[0, dataGridEmprunt.CurrentCell.RowIndex].Value.ToString().Trim();
                var id_album = from al in Outils.musique.ALBUMS
                               where al.TITRE_ALBUM == titre
                               select al.CODE_ALBUM;
                foreach (EMPRUNTER emp in Connexion.abonné.EMPRUNTER)
                {
                    if (emp.CODE_ALBUM == id_album.First())
                    {
                        dateRetourAttendue.Text = emp.DATE_RETOUR_ATTENDUE.ToString();
                        if (Outils.dejaProlongé(emp))
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

        private Image ImagePochette(byte[] byteMap)
        {
            Image image;
            using (var ms = new MemoryStream(byteMap))
            {
                image = Image.FromStream(ms);
            }
            return (Image)(new Bitmap(image, new Size(100, 100)));
        }

        private void emprunter_Click(object sender, EventArgs e)
        {
            MusiquePT2_NEntities m = Outils.musique;
            EMPRUNTER emprunt = new EMPRUNTER();
            DateTime date = DateTime.Now;
            ALBUMS al = pagesAlbums.CurrentRow.Tag as ALBUMS;
            if (al != null && !Outils.dejaEmprunté(al))
            {
                string titre = al.TITRE_ALBUM.Trim();
                emprunt.CODE_ABONNÉ = Connexion.abonné.CODE_ABONNÉ;
                emprunt.CODE_ALBUM = ABONNÉS.IdAlbum(titre);
                emprunt.DATE_EMPRUNT = date;
                emprunt.DATE_RETOUR_ATTENDUE = date + TimeSpan.FromDays(EMPRUNTER.typeGenre(titre).GENRES.DÉLAI);
                emprunt.ABONNÉS = m.ABONNÉS.Find(Connexion.abonné.CODE_ABONNÉ);
                emprunt.ALBUMS = m.ALBUMS.Find(ABONNÉS.IdAlbum(titre));

                m.ABONNÉS.Find(Connexion.abonné.CODE_ABONNÉ).EMPRUNTER.Add(emprunt);
                m.EMPRUNTER.Add(emprunt);
            }
            m.SaveChanges(); //gestion de la mise a jour de la lsite necessaire
            AfficherAlbums();
        }

        private void rechercheTitre_TextChanged(object sender, EventArgs e)
        {
            AfficherAlbums();
        }

        private void AfficherAlbums()
        {
            pagesAlbums.Rows.Clear();
            int i = 0;
            foreach (ALBUMS al in ABONNÉS.RechercheTitre(rechercheTitre.Text))
            {
                pagesAlbums.Rows.Add(al.TITRE_ALBUM, al.getEditeur(), al.getAnnée(), al.getPays(), al.getGenre(), al.getDejaEmprunter());
                pagesAlbums.Rows[i].Tag = (ALBUMS)al;
                i++;
            }
        }

        private void rendre_Click(object sender, EventArgs e)
        {
            if (dataGridEmprunt[0, dataGridEmprunt.CurrentCell.RowIndex].Value != null
                       && !dataGridEmprunt[0, dataGridEmprunt.CurrentCell.RowIndex].Value.ToString().Contains("Aucun emprunt en cours"))
            {
                
            }
        }

        private void ongletsAbonné_SelectedIndexChanged(object sender, EventArgs e)
        {
            afficherEmprunts(EMPRUNTER.ListeAlbums());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*this.Close();
            //new Connexion().ShowDialog(); //à vérifier
            MessageBox.Show("Vous avez été déconnecté");*/
            Outils.Deconnexion(this);
        }
    }
}
