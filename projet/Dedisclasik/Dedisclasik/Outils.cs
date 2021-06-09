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

        public static void chargerElements()
        {
            ABONNÉS abo = new ABONNÉS();
            abo.NOM_ABONNÉ = "test";
            abo.PRÉNOM_ABONNÉ = "unitaire";
            abo.LOGIN_ABONNÉ = "testdu33";
            abo.PASSWORD_ABONNÉ = "123";
            musique.ABONNÉS.Add(abo);
            musique.SaveChanges();

            EMPRUNTER emp = new EMPRUNTER();
            emp.CODE_ABONNÉ = abo.CODE_ABONNÉ;
            emp.CODE_ALBUM = getAlbum().CODE_ALBUM;
            emp.DATE_EMPRUNT = DateTime.Parse("2021-06-05 16:50:26.967");
            emp.DATE_RETOUR_ATTENDUE = DateTime.Parse("2021-07-10 16:50:26.967");
            musique.EMPRUNTER.Add(emp);
            musique.SaveChanges();
        }
        public static void supprimerElements()
        {
            musique.ABONNÉS.Remove(getAbo());
            musique.EMPRUNTER.Remove(getEmprunt());
            musique.SaveChanges();
        }

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
            EMPRUNTER emp = getEmprunt();
            ABONNÉS abo = getAbo();
            return musique.EMPRUNTER.Where(e => e.CODE_ABONNÉ == abo.CODE_ABONNÉ
                && e.CODE_ALBUM == emp.CODE_ALBUM).FirstOrDefault();
        }
    }
}
