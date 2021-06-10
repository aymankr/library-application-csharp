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
    public partial class RechercheAlbumEtEmprunt : Form
    {
        public RechercheAlbumEtEmprunt()
        {
            InitializeComponent();
            Outils.chargerDataGrid(new string[] { "Titre", "Editeur", "Date", "Pays", "Genre", "Déjà emprunté" }, pagesAlbums);
        }

        private void recherche_TextChanged(object sender, EventArgs e)
        {
            pagesAlbums.Rows.Clear();
            int i = 0;
            foreach (ALBUMS al in ABONNÉS.RechercheAlbum(recherche.Text, "", ""))
            {
                //album.Items.Add(al);
                pagesAlbums.Rows.Add(al.TITRE_ALBUM, al.getEditeur(), al.getAnnée(), al.getPays(), al.getGenre(), al.getDejaEmprunter());
                pagesAlbums.Rows[i].Tag = (ALBUMS)al;
                i++;
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
            recherche_TextChanged(sender, e);
        }

        private void MonCompte_Click(object sender, EventArgs e)
        {
            MonCompte interfaceT = new MonCompte();
            interfaceT.ShowDialog();
        }
    }
}
