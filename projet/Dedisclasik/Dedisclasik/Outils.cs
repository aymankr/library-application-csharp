using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dedisclasik
{
    public static class Outils
    {
        #region attributs pagination
        public static int pgNb = 1;
        public static int pgSz = 15;
        public static String fonction = "";
        public static List<string> actions = new List<string>();
        public static int cptActions = 0;
        public static bool multipleVerif = true;
        #endregion
        public static MusiquePT2_NEntities musique { get; set; }

        public static bool dejaProlongé(EMPRUNTER emprunt)
        {
            bool dejaProlongé = true;
            TimeSpan temps = emprunt.DATE_RETOUR_ATTENDUE - emprunt.DATE_EMPRUNT;
            if (int.Parse(temps.Days.ToString()) <= emprunt.ALBUMS.GENRES.DÉLAI)
            {
                dejaProlongé = false;
            }
            return dejaProlongé;
        }

        public static bool dejaEmprunté(ALBUMS album)
        {
            foreach (EMPRUNTER emprunt in musique.EMPRUNTER)
            {
                if (album.Equals(emprunt.ALBUMS))
                {
                    return true;
                }
            }
            return false;
        }

        public static void chargerDataGrid(string[] attributs, System.Windows.Forms.DataGridView dg)
        {
            dg.Rows.Clear();
            dg.Columns.Clear();
            int longueur = attributs.Length;
            dg.ColumnCount = longueur;

            int i = 0;
            foreach (string s in attributs)
            {
                dg.Columns[i].Name = s;
                dg.Columns[i].Width = dg.Width / longueur;
                i++;
            }
            dg.ReadOnly = true;
            dg.MultiSelect = false;
        }


        public static bool ActiverPagination(int tailleListe)
        {
            return (tailleListe <= 20);
        }

        #region gestion elements
        public static EMPRUNTER creerEmprunt(ABONNÉS abo, string dateEmprunt, string dateRetourAttendue)
        {
            EMPRUNTER emp = new EMPRUNTER();
            emp.CODE_ABONNÉ = abo.CODE_ABONNÉ;

            var listAlbumsEmprunts = (from a in musique.ALBUMS join j in musique.EMPRUNTER on a.CODE_ALBUM equals j.CODE_ALBUM select a).ToList();
            var listAlbumsNonEmpruntes = musique.ALBUMS.ToList().Except(listAlbumsEmprunts);
            ALBUMS alb = listAlbumsNonEmpruntes.First();
            emp.CODE_ALBUM = alb.CODE_ALBUM;
            emp.DATE_EMPRUNT = DateTime.Parse(dateEmprunt);
            emp.DATE_RETOUR_ATTENDUE = DateTime.Parse(dateRetourAttendue);
            musique.EMPRUNTER.Add(emp);
            musique.SaveChanges();

            return emp;
        }

        public static void supprimerEmprunt(EMPRUNTER emp)
        {
            musique.EMPRUNTER.Remove(emp);
            musique.SaveChanges();
        }

        public static void supprimerAbonnes()
        {
            ABONNÉS abo = getAbo();
            musique.ABONNÉS.Remove(abo);
            musique.SaveChanges();
        }
        #endregion

        #region get
        public static ABONNÉS getAbo()
        {
            return musique.ABONNÉS.Where(a => a.NOM_ABONNÉ.Trim().Equals("test") && a.PRÉNOM_ABONNÉ.Trim().Equals("unitaire")
                    && a.LOGIN_ABONNÉ.Trim().Equals("testdu33") && a.PASSWORD_ABONNÉ.Trim().Equals("123")).FirstOrDefault();
        }

        public static ALBUMS getAlbum()
        {
            return musique.ALBUMS.Where(a => a.TITRE_ALBUM.Trim().Equals("Bach: Rampal")
                && a.ALLÉE_ALBUM.Equals("C") && a.CASIER_ALBUM == 7).FirstOrDefault();
        }

        public static EMPRUNTER getEmprunt()
        {
            musique = new MusiquePT2_NEntities();
            ALBUMS emp = getAlbum();
            ABONNÉS abo = getAbo();
            return musique.EMPRUNTER.Where(e => e.CODE_ABONNÉ == abo.CODE_ABONNÉ
                && e.CODE_ALBUM == emp.CODE_ALBUM).FirstOrDefault();
        }

        public static void activePaging(int nbMax, System.Windows.Forms.Button btPrec, System.Windows.Forms.Button btNext, System.Windows.Forms.Label lab)
        {
            btPrec.Enabled = true;
            btNext.Enabled = true;
            float nbPP = (float)nbMax / (float)pgSz;
            int nb;
            int nn = (int)nbPP;
            if ((float)nn == nbPP) nb = nbMax / pgSz; else nb = nbMax / pgSz + 1;
            lab.Text = "Page : " + pgNb.ToString() + "/" + ((int)nb).ToString();
            if (pgNb <= 1)
            {
                btPrec.Enabled = false;
            }
            if (pgNb >= (int)nb)
            {
                btNext.Enabled = false;
            }


        }
        public static void comparer()
        {
            actions.Add(fonction);
            cptActions++;
            if (!(actions[cptActions].Equals(actions[cptActions - 1]))) //ss disconnect
            {
                pgNb = 1;
                multipleVerif = true;
            }
        }
        #endregion

        public static void Deconnexion(Form fenetre)
        {
            var confirmResult = MessageBox.Show("Etes-vous sûr ?", "Déconnexion", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes) fenetre.Close();
        }

    }
}
