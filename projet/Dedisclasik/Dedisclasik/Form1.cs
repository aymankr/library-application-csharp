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
    public partial class suggest : Form
    {
        String separator = "------------------------------------";
        String art = "Suggestions par Artistes";
        String genr = "Suggestions par Genre";
        int id = Connexion.id_abonné;
        Boolean pris = false;
        public suggest()
        {
            InitializeComponent();
        }

        private void artiste_Click(object sender, EventArgs e)
        {

            Suggestions.Items.Add(art);
            Suggestions.Items.Add(separator);
            var titres = (from a in Outils.musique.ALBUMS
                          where a.TITRE_ALBUM.Contains("bach")
                          select a.TITRE_ALBUM).ToList();
            List<String> albums = new List<String>();
            foreach (string t in titres)
            {
                Suggestions.Items.Add(t);
            }
            Suggestions.Items.Add(separator);
        }


        private void genre_Click(object sender, EventArgs e)
        {
            Suggestions.Items.Add(genr);
            Suggestions.Items.Add(separator);
            var gen = Outils.musique.EMPRUNTER
                                .OrderByDescending(a => a.ALBUMS.GENRES).Take(1).ToString();
            var titres = (from a in Outils.musique.ALBUMS
                          where a.GENRES.Equals(gen)
                          select a.TITRE_ALBUM).ToList();
            List<String> albums = new List<String>();
            foreach (string t in titres)
            {
                Suggestions.Items.Add(t);
            }
            Suggestions.Items.Add(separator);
        }
        private String sugGen()
        {
            var gen = Outils.musique.EMPRUNTER
                 .OrderByDescending(a => a.ALBUMS.GENRES).Take(1).ToString();
            return gen;
        }

        private void emprunt_Click(object sender, EventArgs e)
        {
            if (!pris)
            {
                MusiquePT2_NEntities m = Outils.musique;
                EMPRUNTER emprunt = new EMPRUNTER();
                if (Suggestions.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez séléctionner une Oeuvre");
                }
                else
                {
                    string titre = Suggestions.SelectedItem.ToString().Trim();
                    emprunt.CODE_ABONNÉ = Connexion.id_abonné;
                    emprunt.CODE_ALBUM = ABONNÉS.IdAlbum(titre);
                    emprunt.DATE_EMPRUNT = DateTime.Now;
                    emprunt.DATE_RETOUR_ATTENDUE = new DateTime(2022, 3, 15); //pas le souci
                    emprunt.ABONNÉS = m.ABONNÉS.Find(Connexion.id_abonné);
                    emprunt.ALBUMS = m.ALBUMS.Find(ABONNÉS.IdAlbum(titre));

                    m.ABONNÉS.Find(Connexion.id_abonné).EMPRUNTER.Add(emprunt);
                    m.EMPRUNTER.Add(emprunt);
                }
                m.SaveChanges();
            } else
            {
                MessageBox.Show("Déjà pris");
            }
        }

    }
}
