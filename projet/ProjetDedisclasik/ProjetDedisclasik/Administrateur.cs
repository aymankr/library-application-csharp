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
    public partial class Administrateur : Form
    {
        MusiquePT2_NEntities musique;

        public Administrateur(MusiquePT2_NEntities musique)
        {
            InitializeComponent();
            this.musique = musique;
        }

        private void empruntsProlonges_Click(object sender, EventArgs e)
        {
            /*listInfos.Items.Clear();
            var emprunts = (from a in musique.EMPRUNTER
                            select a.ALBUMS).ToList();
            foreach (ALBUMS a in emprunts)
            {
                listInfos.Items.Add(a.TITRE_ALBUM);
            }*/
        }

        private void empruntsRetard_Click(object sender, EventArgs e)
        {
            listInfos.Items.Clear();
            DateTime dateNow = DateTime.Now;

            // US5 : abonnés ayant emprunts non rendu depuis plus de 10j
            var emprunteurs = musique.EMPRUNTER
                .Where(a => a.DATE_RETOUR == null).ToList()
                .Where(a => (int)(dateNow - a.DATE_RETOUR_ATTENDUE).TotalDays >= 10).Select(a => a.ABONNÉS);
            foreach (ABONNÉS a in emprunteurs)
            {
                listInfos.Items.Add(a.NOM_ABONNÉ);
            }
        }

        private void meilleursEmprunts_Click(object sender, EventArgs e)
        {

        }

        private void purger_Click(object sender, EventArgs e)
        {

        }

        private void abonneNonEmprunts_Click(object sender, EventArgs e)
        {

        }
    }
}
