using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetDedisclasik
{
    public partial class Prolonger : Form
    {
        MusiquePT2_NEntities musique;
        public Prolonger(MusiquePT2_NEntities musique)
        {
            InitializeComponent();
            this.musique = musique;
            List<string> liste = new List<string>();
            chargeListAlbums();


        }
        private void chargeListAlbums()
        {
            var albums = (from a in musique.EMPRUNTER
                          where a.CODE_ABONNÉ == 1
                          select a.ALBUMS).ToList();
            foreach (ALBUMS a in albums)
            {
                string noms = a.TITRE_ALBUM.Trim() + " | " + a.CODE_ALBUM;
                ListeAlbums.Items.Add(noms);
            }
        }

        private void prolong_Click(object sender, EventArgs e)
        {
            bool t = true;
            //si on a pas emprunter
            if (t)
            {
                string titre = ListeAlbums.SelectedItem.ToString();
                ALBUMS albums = (from a in musique.ALBUMS
                                 where a.TITRE_ALBUM.Equals(titre.Trim())
                                 select a).FirstOrDefault();
                selection select = new selection(titre);
                select.ShowDialog();

                if (select.ShowDialog() == DialogResult.OK)
                {
                    //auglfffffenter la date
                }
            }
            else
            {

                //sinon :
                MessageBox.Show("Il est impossible de prolonger plusieurs fois un même emprunt");
            }
        }
    }
}
