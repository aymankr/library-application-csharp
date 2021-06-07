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
        }

        private void recherche_TextChanged(object sender, EventArgs e)
        {
            album.Items.Clear();
            List<String> titres = ABONNÉS.RechercheTitre(recherche.Text);
            foreach (String t in titres)
            {
                album.Items.Add(t);
            }
        }

        private void emprunter_Click(object sender, EventArgs e)
        {
            MusiquePT2_NEntities m = Outils.musique;
            string titre = album.SelectedItem.ToString().Trim();
            EMPRUNTER emprunt = new EMPRUNTER();

            emprunt.CODE_ABONNÉ = Connexion.id_abonné;
            emprunt.CODE_ALBUM = ABONNÉS.IdAlbum(titre);
            emprunt.DATE_EMPRUNT = DateTime.Now;
            emprunt.DATE_RETOUR_ATTENDUE = new DateTime(2022, 3, 15); //pas le souci
            emprunt.ABONNÉS = m.ABONNÉS.Find(Connexion.id_abonné);
            emprunt.ALBUMS = m.ALBUMS.Find(ABONNÉS.IdAlbum(titre));

            m.ABONNÉS.Find(Connexion.id_abonné).EMPRUNTER.Add(emprunt);
            m.EMPRUNTER.Add(emprunt);
            m.SaveChanges();

            Console.WriteLine("enregistré");
        }

        private void MonCompte_Click(object sender, EventArgs e)
        {
            InterfaceTemp interfaceT = new InterfaceTemp();
            interfaceT.ShowDialog();
        }
    }
}
