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
    public partial class Form1 : Form
    {
        MusiquePT2_NEntities musique;


        public Form1()
        {
            InitializeComponent();
            musique = new MusiquePT2_NEntities();
            chargeListAbonnes();
        }

        private void ajout_Click(object sender, EventArgs e)
        {
            ABONNÉS abonne = new ABONNÉS();

            String nomAbonne = nom.Text;
            String prenomAbonne = prenom.Text;
            String loginAbonne = loginAbo.Text;
            String mdpAbonne = mdp.Text;
            String paysAbonne = pays.Text;

            abonne.NOM_ABONNÉ = nomAbonne;
            abonne.PRÉNOM_ABONNÉ = prenomAbonne;
            abonne.LOGIN_ABONNÉ = loginAbonne;
            abonne.PASSWORD_ABONNÉ = mdpAbonne;

            musique.ABONNÉS.Add(abonne);
            musique.SaveChanges();
            chargeListAbonnes();
        }

        private void chargeListAbonnes()
        {
            var abonnes = (from a in musique.ABONNÉS
                           orderby a.NOM_ABONNÉ
                           select a).ToList();
            listAbonnes.Items.Clear();
            foreach (ABONNÉS a in abonnes)
            {
                listAbonnes.Items.Add(a.NOM_ABONNÉ);
            }
        }
    }
}
