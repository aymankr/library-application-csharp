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
        public static String fonction = "";
        public static List<string> actions = new List<string>();
        public static int cptActions = 0;
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

        public static void activePaging(int nbMax, System.Windows.Forms.Button btPrec, System.Windows.Forms.Button btNext, System.Windows.Forms.Label lab )
        {
            btPrec.Enabled = true;
            btNext.Enabled = true;
            lab.Text = "Page : " + pgNb.ToString() + "/" + (nbMax / pgSz + 1).ToString();
            if (pgNb <= 1)
            {
                btPrec.Enabled = false;
            }
            if (pgNb >= (int)(nbMax / pgSz) + 1)
            {
                btNext.Enabled = false;
            }
        }
        public static void comparer()
        {
            actions.Add(fonction);
            cptActions++;
            if (!(actions[cptActions].Equals(actions[cptActions - 1])))
            {
                pgNb = 1;
            }
        }

        // laisser pour m'aider a adapter apres
        //Outils.fonction = "test";
        //    comparer();
        //var cmd = Outils.musique.EDITEURS;
        //Outils.activePaging(cmd.Count(), prec, suiv, pg);

        //    Outils.chargerDataGrid(1, new string[] { "Titre" }, dataGridView1);
        //    var affiche = cmd.ToList().Take(Outils.pgSz * Outils.pgNb).Skip(Outils.pgSz * (Outils.pgNb - 1));
    }
}
