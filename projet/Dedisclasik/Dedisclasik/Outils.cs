using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dedisclasik
{
    public static class Outils
    {
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

        public static void chargerDataGrid(int nbColonnes, string[] attributs, System.Windows.Forms.DataGridView dg)
        {
            dg.Rows.Clear();
            dg.Columns.Clear();
            dg.ColumnCount = nbColonnes;

            int i = 0;
            foreach(string s in attributs)
            {
                dg.Columns[i].Name = s;
                dg.Columns[i].Width = dg.Width / nbColonnes;
                i++;
            }
        }

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

        public static ABONNÉS getAbo()
        {
            musique = new MusiquePT2_NEntities(); // nécessaire pour la synchronisation avec les tests
            return musique.ABONNÉS.Where(a => a.NOM_ABONNÉ.Trim().Equals("test") && a.PRÉNOM_ABONNÉ.Trim().Equals("unitaire")
                    && a.LOGIN_ABONNÉ.Trim().Equals("testdu33") && a.PASSWORD_ABONNÉ.Trim().Equals("123")).FirstOrDefault();
        }

        public static ALBUMS getAlbum()
        {
            musique = new MusiquePT2_NEntities();
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
    }
}
