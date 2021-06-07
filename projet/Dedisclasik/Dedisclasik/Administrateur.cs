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
    public partial class Administrateur : Form
    {
        public Administrateur()
        {
            InitializeComponent();
        }

        private void empruntProlong_Click(object sender, EventArgs e)
        {
            /*listInfos.Items.Clear();
            var emprunts = (from a in musique.EMPRUNTER
                            select a.ALBUMS).ToList();
            foreach (ALBUMS a in emprunts)
            {
                listInfos.Items.Add(a.TITRE_ALBUM);
            }*/
        }

        private void empruntRetard_Click(object sender, EventArgs e)
        {
            listInfos.Items.Clear();
            DateTime dateNow = DateTime.Now;

            // US5 : abonnés ayant emprunts non rendu depuis plus de 10j
            var emprunteurs = Outils.musique.EMPRUNTER
                .Where(a => a.DATE_RETOUR == null).ToList()
                .Where(a => (int)(dateNow - a.DATE_RETOUR_ATTENDUE).TotalDays >= 10).Select(a => a.ABONNÉS);
            foreach (ABONNÉS a in emprunteurs)
            {
                listInfos.Items.Add(a.NOM_ABONNÉ);
            }
        }

        private void empruntMeilleurs_Click(object sender, EventArgs e)
        {

        }

        private void purger_Click(object sender, EventArgs e)
        {

        }
    }
}
