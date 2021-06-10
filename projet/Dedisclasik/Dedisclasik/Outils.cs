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
            dg.ReadOnly=true;
            dg.MultiSelect = false;
        }

        public static void Deconnexion(Form fenetre)
        {
            var confirmResult = MessageBox.Show("Etes-vous sûr ?", "Déconnexion", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes) fenetre.Close();
        }
    }
}
