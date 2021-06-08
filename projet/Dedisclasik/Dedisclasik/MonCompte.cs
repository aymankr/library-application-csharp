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
    public partial class MonCompte : Form
    {
        public MonCompte() 
        {
            InitializeComponent();
            afficherEmprunts(EMPRUNTER.ListeAlbums(Connexion.abonne));
            Prolonger.Enabled = false;
            vérifcationToutProlonger();
            nomUtilisateur.Text = "nom";//Connexion.abonné.NOM_ABONNÉS;
            prenomUtilisateur.Text = "prénom";//Connexion.abonné.PRÉNOM_ABONNÉS;
            loginUtilisateur.Text = "login";//Connexion.abonné.LOGIN_ABONNÉS;
        }

        public void afficherEmprunts(List<string> albums)
        {
            albumEmprunt.Items.Clear();
            if (albums.Count() <= 0)
            {
                albumEmprunt.Items.Add("aucun emprunt en cours"); 
            }
            foreach (string alb in albums)
            {
                albumEmprunt.Items.Add(alb);
            }

            //modification vers grid
            if (Connexion.abonné.EMPRUNTER.ALBUMS != null)
            {
                foreach (ALBUMS al in Connexion.abonné.EMPRUNTER.ALBUMS)
                {
                    dataGridEmprunt[0].Value = al.TITRE_ALBUM;
                    dataGridEmprunt[1].Value = al.GENRES;
                    if () { dataGridEmprunt[2].Value = al.EDITEURS; } else { dataGridEmprunt[2].Value = "Non renseigné"; }
                    dataGridEmprunt[3].Value = al.ANNÉE_ALBUM;
                }
            }
            else
            {
                //affichage du messga e de liste vide
            }

        }

        private void voirAlbums_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Prolonger_Click(object sender, EventArgs e)
        {
            if (albumEmprunt.SelectedItem != null && !albumEmprunt.SelectedItem.ToString().Contains("aucun emprunt en cours"))
            {
                string titre = albumEmprunt.SelectedItem.ToString();
                var id_album = from al in Outils.musique.ALBUMS
                               where al.TITRE_ALBUM == titre
                               select al.CODE_ALBUM;
                foreach (EMPRUNTER emp in Outils.musique.EMPRUNTER)
                {
                    if (emp.CODE_ALBUM == id_album.First())
                    {
                        if (!Outils.dejaProlongé(emp))
                        {
                            emp.DATE_RETOUR_ATTENDUE = emp.DATE_RETOUR_ATTENDUE.AddMonths(1);
                            Prolonger.Enabled = false;
                            MessageBox.Show("Prolongement effectué pour : \n" + titre);
                        }
                    }
                }
            }
            Outils.musique.SaveChanges();
        }
        
        

        private void albumEmprunt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (albumEmprunt.SelectedItem != null && !albumEmprunt.SelectedItem.ToString().Contains("aucun emprunt en cours"))
            {
                string titre = albumEmprunt.SelectedItem.ToString();
                var id_album = from al in Outils.musique.ALBUMS
                               where al.TITRE_ALBUM == titre
                               select al.CODE_ALBUM;
                foreach (EMPRUNTER emp in Outils.musique.EMPRUNTER)
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

        private void ToutProlonger_Click(object sender, EventArgs e)
        {
            List<string> prolongés = new List<string>();
            foreach (object objet in albumEmprunt.Items)
            {
                string titre = objet.ToString();
                var id_album = from al in Outils.musique.ALBUMS
                               where al.TITRE_ALBUM == titre
                               select al.CODE_ALBUM;
                foreach (EMPRUNTER emp in Outils.musique.EMPRUNTER)
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
            Outils.musique.SaveChanges();
            string resultat = String.Join("\n", prolongés.ToArray());
            MessageBox.Show("Prolongement effectué pour : \n" + resultat);
            ToutProlonger.Enabled = false;
            Prolonger.Enabled = false;
        }

        private void vérifcationToutProlonger()
        {
            ToutProlonger.Enabled = false;
            foreach (object objet in albumEmprunt.Items)
            {
                string titre = objet.ToString();
                var id_album = from al in Outils.musique.ALBUMS
                               where al.TITRE_ALBUM == titre
                               select al.CODE_ALBUM;
                foreach (EMPRUNTER emp in Outils.musique.EMPRUNTER)
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
            Outils.chargerDataGrid(4 ,new string[] { "Titre", "Genre", "Editeur", "Année"},dataGridEmprunt);
        }
    }
}
