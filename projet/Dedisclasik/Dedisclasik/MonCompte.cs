using System;
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
        private int numColonneEmprunt = 5; //nombre de colonne nécessaire pour l'affichage des pochettes dans mon compte
        private int numColonneAlbums = 6; //nombre de colonne nécessaire pour l'affichage des pochettes dans la Discothèque
        private List<ALBUMS> ToutLesAlbums;

        public MonCompte()
        {
            InitializeComponent();

            ToutLesAlbums = Outils.musique.ALBUMS.ToList();

            initDataGridView();
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.HeaderText = "Pochette";
            img.Width = dataGridEmprunt.Width / 6;
            dataGridEmprunt.Columns.Insert(numColonneEmprunt, img);

            DataGridViewImageColumn img2 = new DataGridViewImageColumn();
            img2.HeaderText = "Pochette";
            img2.Width = pagesAlbums.Width / 7;
            pagesAlbums.Columns.Insert(numColonneAlbums, img2);

            InitialiserAlbums();

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
            string dejaProlonge = "";

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

                    string[] row = { al.TITRE_ALBUM, genre, editeur, annee, dejaProlonge };

                    dataGridEmprunt.Rows.Add(row);
                    dataGridEmprunt.Rows[i].Cells[numColonneEmprunt].Value = ImagePochette(al.POCHETTE);
                    i++;
                }
            }
            else
            {
                string[] row = { "Aucun emprunt en cours" };
                dataGridEmprunt.Rows.Add(row);
            }

        }

        private void Prolonger_Click(object sender, EventArgs e)
        {
            if (dataGridEmprunt.RowCount > 0)
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
            int i = 0;
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
                                Console.Write("pas prolongé");
                                break;
                            }
                        }
                    }
                }
                i++;
            }
        }

        private bool vérificationProlonger()
        {
            if (dataGridEmprunt.CurrentCell != null)
            {
                Prolonger.Enabled = true;
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
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }


        private void deconnexionButton_Click(object sender, EventArgs e)
        {
            Outils.Deconnexion(this);
        }

        public void initDataGridView()
        {
            Outils.chargerDataGrid(new string[] { "Titre", "Genre", "Editeur", "Année", "Déjà prolongé" }, dataGridEmprunt);
            Outils.chargerDataGrid(new string[] { "Titre", "Editeur", "Date", "Pays", "Genre", "Déjà emprunté" }, pagesAlbums);
        }

        private void dataGridEmprunt_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridEmprunt.CurrentCell != null)
            {
                Prolonger.Enabled = vérificationProlonger();
                vérifcationToutProlonger();
            }
        }

        public static Image ImagePochette(byte[] byteMap)
        {
            Image img = null;
            if (byteMap != null)
            {
                Image image;
                using (var ms = new MemoryStream(byteMap))
                {
                    image = Image.FromStream(ms);
                }
                img = (Image)(new Bitmap(image, new Size(100, 100)));
            }

            return img;
        }

        private void emprunter_Click(object sender, EventArgs e)
        {
            MusiquePT2_NEntities m = Outils.musique;
            EMPRUNTER emprunt = new EMPRUNTER();
            DateTime date = DateTime.Now;
            ALBUMS al = pagesAlbums.CurrentRow.Tag as ALBUMS;
            if (al != null)
            {
                string titre = al.TITRE_ALBUM.Trim();
                if (!Outils.dejaEmprunté(al))
                {
                    bool existe = false;
                    var confirmResult = MessageBox.Show("Êtes-vous sûr de vouloir emprunter " + al.TITRE_ALBUM.Trim() + " ?", "Emprunter", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        foreach (EMPRUNTER emp in m.ABONNÉS.Find(Connexion.abonné.CODE_ABONNÉ).EMPRUNTER)
                        {
                            if (Connexion.abonné.Equals(emp.ABONNÉS) && al.Equals(emp.ALBUMS))
                            {
                                emp.DATE_EMPRUNT = DateTime.Now;
                                emp.DATE_RETOUR_ATTENDUE = date + TimeSpan.FromDays(al.GENRES.DÉLAI);
                                emp.DATE_RETOUR = null;
                                existe = true;
                            }
                        }
                        if (!existe)
                        {
                            emprunt.CODE_ABONNÉ = Connexion.abonné.CODE_ABONNÉ;
                            emprunt.CODE_ALBUM = ABONNÉS.IdAlbum(titre);
                            emprunt.DATE_EMPRUNT = date;
                            emprunt.DATE_RETOUR_ATTENDUE = date + TimeSpan.FromDays(EMPRUNTER.typeGenre(titre).GENRES.DÉLAI);
                            emprunt.ABONNÉS = m.ABONNÉS.Find(Connexion.abonné.CODE_ABONNÉ);
                            emprunt.ALBUMS = m.ALBUMS.Find(ABONNÉS.IdAlbum(titre));

                            m.ABONNÉS.Find(Connexion.abonné.CODE_ABONNÉ).EMPRUNTER.Add(emprunt);
                            m.EMPRUNTER.Add(emprunt);
                        }
                        pagesAlbums.Rows[pagesAlbums.CurrentCell.RowIndex].Cells[5].Value = "X";
                        MessageBox.Show(titre + " emprunté");
                    }
                    else
                    {
                        MessageBox.Show("Emprunt annulé");
                    }
                    m.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Cette album est déjà emprunter");
                }
            }
            else
            {
                MessageBox.Show("Choisissez un album à emprunter");
            }
        }

        private void InitialiserAlbums()
        {
            int i = 0;
            foreach (ALBUMS al in ToutLesAlbums)
            {
                pagesAlbums.RowTemplate.Height = 100;
                pagesAlbums.Rows.Add(al.TITRE_ALBUM, al.getEditeur(), al.getAnnée(), al.getPays(), al.getGenre(), al.getDejaEmprunter());
                pagesAlbums.Rows[i].Cells[numColonneAlbums].Value = ImagePochette(al.POCHETTE);
                pagesAlbums.Rows[i].Tag = (ALBUMS)al;
                i++;
            }
        }

        private void rendre_Click(object sender, EventArgs e)
        {
            if (dataGridEmprunt.RowCount > 0)
            {
                if (dataGridEmprunt[0, dataGridEmprunt.CurrentCell.RowIndex].Value != null)
                {
                    MusiquePT2_NEntities m = Outils.musique;
                    string titre = (string)dataGridEmprunt[0, dataGridEmprunt.CurrentCell.RowIndex].Value;

                    EMPRUNTER emprunt = null;
                    foreach (EMPRUNTER emp in m.EMPRUNTER)
                    {
                        if (emp.ALBUMS.TITRE_ALBUM.Trim().Equals(titre.Trim()))
                        {
                            emprunt = emp;
                        }
                    }
                    dataGridEmprunt.Rows.RemoveAt(dataGridEmprunt.CurrentCell.RowIndex);
                    emprunt.DATE_RETOUR = DateTime.Now;
                    m.SaveChanges();
                    pagesAlbums.Rows.Clear();
                    InitialiserAlbums();
                    MessageBox.Show("Vous avez rendu " + titre);
                }
                else
                {
                    MessageBox.Show("Chosissez un albums à rendre");
                }
            }
            else
            {
                MessageBox.Show("Vous n'avez aucun emprunt");
            }
        }

        private void ongletsAbonné_SelectedIndexChanged(object sender, EventArgs e)
        {
            afficherEmprunts(EMPRUNTER.ListeAlbums());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Outils.Deconnexion(this);
        }

        private void rechercheTitre_TextChanged(object sender, EventArgs e)
        {
            /*//recherche de base 
            pagesAlbums.Rows.OfType<DataGridViewRow>()
                .ToList().FindAll(row => row.Tag != null).ForEach(row => row.Visible = false);

            //recherche avancée
            pagesAlbums.Rows.OfType<DataGridViewRow>().Where(r => r.Tag != null && pagesAlbums.Columns.Contains("Titre") && r.Cells["Titre"]
            .Value.ToString().Trim().ToLower().Contains(rechercheTitre.Text.ToString().ToLower()))
                .ToList().ForEach(row => row.Visible = true);*/
            rechercheTripleFacteur();
        }

        private void rechercheGenre_TextChanged(object sender, EventArgs e)
        {
            /* //recherche de base 
             pagesAlbums.Rows.OfType<DataGridViewRow>()
                 .ToList().FindAll(row => row.Tag != null).ForEach(row => row.Visible = false);

             //recherche avancée
             pagesAlbums.Rows.OfType<DataGridViewRow>().Where(r => r.Tag != null && pagesAlbums.Columns.Contains("Genre") && r.Cells["Genre"]
             .Value.ToString().Trim().ToLower().Contains(rechercheGenre.Text.ToString().ToLower()))
                 .ToList().ForEach(row => row.Visible = true);*/
            rechercheTripleFacteur();
        }

        private void rechercheEditeur_TextChanged(object sender, EventArgs e)
        {
            /* //recherche de base 
             pagesAlbums.Rows.OfType<DataGridViewRow>()
                 .ToList().FindAll(row => row.Tag != null).ForEach(row => row.Visible = false);

             //recherche avancée
             pagesAlbums.Rows.OfType<DataGridViewRow>().Where(r => r.Tag != null && pagesAlbums.Columns.Contains("Editeur") && r.Cells["Editeur"]
             .Value.ToString().Trim().ToLower().Contains(rechercheEditeur.Text.ToString().ToLower()))
                 .ToList().ForEach(row => row.Visible = true);*/
            rechercheTripleFacteur();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                var suggestions = Outils.musique.Database.SqlQuery<string>(

                  "SELECT TOP 20 ALBUMS.TITRE_ALBUM " +
                  "FROM ALBUMS " +
                  "WHERE ALBUMS.CODE_GENRE = ( SELECT MEILLEURS.CODE_GENRE " +
                  "        FROM(  " +
                  "            SELECT TOP 1 COUNT(ALBUMS.CODE_GENRE) AS nb, ALBUMS.CODE_GENRE  " +
                  "            FROM EMPRUNTER " +
                  "            INNER JOIN ABONNÉS ON ABONNÉS.CODE_ABONNÉ = EMPRUNTER.CODE_ABONNÉ  " +
                  "            INNER JOIN ALBUMS ON ALBUMS.CODE_ALBUM = EMPRUNTER.CODE_ALBUM  " +
                  "            WHERE ABONNÉS.CODE_ABONNÉ = 35 " +
                  "            GROUP BY ALBUMS.CODE_GENRE  " +
                  "            ORDER BY nb DESC) as MEILLEURS )  " +
                  "ORDER BY NEWID() ").ToList();

                Outils.chargerDataGrid(new string[] { "Titre", "Editeur", "Date", "Pays", "Genre", "Déjà emprunté" }, pagesAlbums);
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.HeaderText = "Pochette";
                img.Width = pagesAlbums.Width / 7;
                pagesAlbums.Columns.Insert(numColonneAlbums, img);

                int i = 0;
                foreach (string s in suggestions)
                {
                    ALBUMS al = Outils.musique.ALBUMS.Where(a => a.TITRE_ALBUM.Trim().Equals(s.Trim())).FirstOrDefault();
                    pagesAlbums.RowTemplate.Height = 100;
                    pagesAlbums.Rows.Add(new string[] { al.TITRE_ALBUM, al.getEditeur(), al.getAnnée(), al.getPays(), al.getGenre(), al.getDejaEmprunter() });
                    pagesAlbums.Rows[i].Cells[numColonneAlbums].Value = ImagePochette(al.POCHETTE);
                    pagesAlbums.Rows[i].Tag = (ALBUMS)al;
                    i++;
                }
            }
            else
            {
                pagesAlbums.Rows.Clear();
                InitialiserAlbums();
            }
        }

        private void recherche(string col1, string col2, string col3, TextBox box1, TextBox box2, TextBox box3)
        {
            pagesAlbums.Rows.OfType<DataGridViewRow>().Where(r => r.Tag != null && pagesAlbums.Columns.Contains(col1) && r.Cells[col1]
            .Value.ToString().Trim().ToLower().Contains(box1.Text.ToString().ToLower())
            && pagesAlbums.Columns.Contains(col2) && r.Cells[col2]
            .Value.ToString().Trim().ToLower().Contains(box2.Text.ToString().ToLower())
            && pagesAlbums.Columns.Contains(col3) && r.Cells[col3]
            .Value.ToString().Trim().ToLower().Contains(box3.Text.ToString().ToLower()))
                .ToList().ForEach(row => row.Visible = true);
        }

        private void rechercheTripleFacteur()
        {
            //initialisation recherche
            pagesAlbums.Rows.OfType<DataGridViewRow>()
                .ToList().FindAll(row => row.Tag != null).ForEach(row => row.Visible = false);

            //recherche pour chaques champs
            recherche("Titre", "Genre", "Editeur", rechercheTitre, rechercheGenre, rechercheEditeur);
        }

    }
}
