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
        public MonCompte()
        {
            InitializeComponent();

            initDataGridView();
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

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            dataGridEmprunt.Columns.Add(img);
            img.Image = null;
            img.HeaderText = "Pochette";
            img.Name = null;

            dataGridEmprunt.Rows.Clear();
            if (Connexion.abonné.EMPRUNTER != null)
            {
                foreach (ALBUMS al in albums)
                {
                    dataGridEmprunt.RowTemplate.Height = 100;

                    if (al.GENRES != null) { genre = al.GENRES.LIBELLÉ_GENRE.ToString(); } else { genre = "Non rensigné"; }
                    if (al.EDITEURS != null) { editeur = al.EDITEURS.NOM_EDITEUR.ToString(); } else { editeur = "Non renseigné"; }
                    if (al.ANNÉE_ALBUM != null) { annee = al.ANNÉE_ALBUM.ToString(); } else { annee = "Non renseigné"; }
                    string[] row = { al.TITRE_ALBUM, genre, editeur, annee };

                    img.Image = ImagePochette(al.POCHETTE);
                    img.Name = al.TITRE_ALBUM;

                    dataGridEmprunt.Rows.Add(row);
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

        private void retourButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deconnexionButton_Click(object sender, EventArgs e)
        {
            this.Close();
            //new Connexion().ShowDialog(); //à vérifier
            MessageBox.Show("Vous avez été déconnecté");
        }

        public void initDataGridView()
        {
            Outils.chargerDataGrid(new string[] { "Titre", "Genre", "Editeur", "Année" }, dataGridEmprunt); //voir pour rajouter une colonne peut etre
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
    }
}
