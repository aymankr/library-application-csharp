using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dedisclasik
{
    public static class Outils
    {
        public static int pgNb = 1;
        public static int pgSz = 15;
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

        
    }
}
