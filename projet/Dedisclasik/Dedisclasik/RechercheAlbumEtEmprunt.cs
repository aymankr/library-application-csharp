using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagedList;

namespace Dedisclasik
{
    public partial class RechercheAlbumEtEmprunt : Form
    {
        public RechercheAlbumEtEmprunt()
        {
            InitializeComponent();
            pagesAlbums.Rows.Clear();
            pagesAlbums.Columns.Clear();
            pagesAlbums.ColumnCount = 6;
            pagesAlbums.Columns[0].Name = "Titre";
            pagesAlbums.Columns[0].Width = pagesAlbums.Width;
            pagesAlbums.Columns[1].Name = "Artiste(s)";
            pagesAlbums.Columns[1].Width = pagesAlbums.Width;
            pagesAlbums.Columns[2].Name = "Date";
            pagesAlbums.Columns[2].Width = pagesAlbums.Width;
            pagesAlbums.Columns[3].Name = "Pays";
            pagesAlbums.Columns[3].Width = pagesAlbums.Width;
            pagesAlbums.Columns[4].Name = "Genre";
            pagesAlbums.Columns[4].Width = pagesAlbums.Width;
            pagesAlbums.Columns[5].Name = "Déjà emprunté";
            pagesAlbums.Columns[5].Width = pagesAlbums.Width;
        }

        private void recherche_TextChanged(object sender, EventArgs e)
        {
            album.Items.Clear();
            foreach (ALBUMS al in ABONNÉS.RechercheTitre(recherche.Text))
            {
                album.Items.Add(al);
                // pagesAlbums.Rows.Add(al.ToString());
            }

            /*album.Items.Clear();
            List<string> emprunter = new List<string>();
            foreach (EMPRUNTER emp in Outils.musique.EMPRUNTER)
            {
                emprunter.Add(emp.ALBUMS.TITRE_ALBUM);
            }
            List<String> titres = ABONNÉS.RechercheTitre(recherche.Text);
            foreach (String t in titres)
            {
                if (emprunter.Contains(t))
                {
                    album.Items.Add(t.Trim() + " -> Déjà emprunté");
                }
                else
                {
                    album.Items.Add(t);
                }
            }*/
        }

        private void emprunter_Click(object sender, EventArgs e)
        {
            MusiquePT2_NEntities m = Outils.musique;
            EMPRUNTER emprunt = new EMPRUNTER();
            DateTime date = DateTime.Now;

            if (album.SelectedItem != null && !album.SelectedItem.ToString().Contains("Déjà emprunté"))
            {
                string titre = album.SelectedItem.ToString().Trim();
                emprunt.CODE_ABONNÉ = Connexion.abonne.CODE_ABONNÉ;
                emprunt.CODE_ALBUM = ABONNÉS.IdAlbum(titre);
                emprunt.DATE_EMPRUNT = date;
                emprunt.DATE_RETOUR_ATTENDUE = date + TimeSpan.FromDays(EMPRUNTER.typeGenre(titre).GENRES.DÉLAI); 
                emprunt.ABONNÉS = m.ABONNÉS.Find(Connexion.abonne.CODE_ABONNÉ);
                emprunt.ALBUMS = m.ALBUMS.Find(ABONNÉS.IdAlbum(titre));

                m.ABONNÉS.Find(Connexion.abonne.CODE_ABONNÉ).EMPRUNTER.Add(emprunt);
                m.EMPRUNTER.Add(emprunt);
            }
            m.SaveChanges(); //gestion de la mise a jour de la lsite necessaire
            recherche_TextChanged(sender, e);
        }

        private void MonCompte_Click(object sender, EventArgs e)
        {
            MonCompte interfaceT = new MonCompte();
            interfaceT.ShowDialog();
        }
    }
}
