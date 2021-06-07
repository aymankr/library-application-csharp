﻿using System;
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
            listInfos.Items.Clear();
            DateTime dateNow = DateTime.Now;
            //DateTime dernierEmprunt = musique.EMPRUNTER.OrderByDescending(a => a.DATE_EMPRUNT).Select(a => a.DATE_EMPRUNT).FirstOrDefault();

            // US6 remove abonnes qui n'ont pas empruntés depuis un an
            var empruntsExpires = Outils.musique.EMPRUNTER
                .Where(a => dateNow.Year - a.DATE_EMPRUNT.Year > 0).ToList();
            var abonnesExpires = Outils.musique.EMPRUNTER
                .Where(a => dateNow.Year - a.DATE_EMPRUNT.Year > 0)
                .Select(a => a.ABONNÉS).ToList();
            Outils.musique.EMPRUNTER.RemoveRange(empruntsExpires);
            Outils.musique.ABONNÉS.RemoveRange(abonnesExpires);
            Outils.musique.SaveChanges();
        }
    }
}
