using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dedisclasik;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DedisclasikTests
{
    [TestClass]
    public class AdministrateurTest
    {
        private MusiquePT2_NEntities m = new MusiquePT2_NEntities();
        private Administrateur admin = new Administrateur();

        [TestMethod]
        public void TestEmpruntsProlonges()
        {
            /*Outils.chargerElements();
            //supprimerElements();
            EMPRUNTER emp = Outils.getEmprunt();

            Assert.IsFalse(Outils.dejaProlongé(emp));

            emp.DATE_RETOUR_ATTENDUE.AddMonths(1);
            m.SaveChanges();

            Assert.IsTrue(Outils.dejaProlongé(emp));

            Outils.supprimerEmprunt();
            Outils.supprimerAbonnes();*/
        }

        /*
        [TestMethod]
        public void testEmpruntsRetard()
        {
            // get liste emprunts retards de 10j
            // vérifier qu'un emprunt n'est pas en retard de 10j (qu'il n'est pas présent dans la liste)
            // modif sa date d'emprunt et la reculer
            // vérifier que cet emprunt est présent dans la liste

            // un emprunt en retard : 
            EMPRUNTER album1 = m.EMPRUNTER.Where(a => a.CODE_ALBUM == 321).Where(a => a.CODE_ABONNÉ == 35).First();
            album1.DATE_EMPRUNT = DateTime.Parse("2021-06-06 16:50:26.967");
            album1.DATE_RETOUR_ATTENDUE = DateTime.Parse("2021-07-25 16:50:26.967");
            m.SaveChanges();

            List<ABONNÉS> listEmpruntsRetard = new List<ABONNÉS>();
            listEmpruntsRetard.AddRange(admin.listEmpruntRetard());

            int codeAbo = album1.CODE_ABONNÉ;

            List<int> codeAbos = new List<int>();
            foreach (ABONNÉS e in listEmpruntsRetard)
            {
                codeAbos.Add(e.CODE_ABONNÉ);
            }
            Assert.IsFalse(codeAbos.Contains(codeAbo));

            album1.DATE_EMPRUNT = DateTime.Parse("2021-03-21 16:50:26.967");
            album1.DATE_RETOUR_ATTENDUE = DateTime.Parse("2021-05-15 16:50:26.967");
            m.SaveChanges();

            // vérification en retard
            listEmpruntsRetard.Clear();
            listEmpruntsRetard.AddRange(admin.listEmpruntRetard());
            codeAbos.Clear();

            foreach (ABONNÉS e in listEmpruntsRetard)
            {
                codeAbos.Add(e.CODE_ABONNÉ);
            }
            Assert.IsTrue(codeAbos.Contains(codeAbo));

            album1.DATE_EMPRUNT = DateTime.Parse("2021-06-06 16:50:26.967");
            album1.DATE_RETOUR_ATTENDUE = DateTime.Parse("2021-07-25 16:50:26.967");
            m.SaveChanges();
        }
         public void testMeilleursEmprunts()
         {
             // get liste meilleurs emprunts
             // vérifier qu'un emprunt n'est pas présent dans la liste des meilleurs
             // le faire emprunter plusieurs fois
             // vérifier que cet emprunt est présent dans la liste

             List<ALBUMS> listMeilleursEmprunts = new List<ALBUMS>();
             listMeilleursEmprunts.AddRange(admin.listMeilleurEmprunt());

             // emprunt qui n'a pas été prolongé : Mozart: Bastien und Bastienne
             EMPRUNTER album1 = m.EMPRUNTER.Where(a => a.CODE_ALBUM == 283).First();
             int codeAlbum1 = album1.CODE_ALBUM;

             List<int> codeAlbums = new List<int>();
             foreach (EMPRUNTER e in listEmpruntsProlong)
             {
                 codeAlbums.Add(e.ALBUMS.CODE_ALBUM);
             }
             Assert.IsFalse(codeAlbums.Contains(codeAlbum1));

             // qui a été prolongé : mozart complete
             EMPRUNTER album2 = m.EMPRUNTER.Where(a => a.CODE_ALBUM == 321).First();
             int codeAlbum2 = album2.CODE_ALBUM;

             List<int> codeAlbums2 = new List<int>();
             foreach (EMPRUNTER e in listEmpruntsProlong)
             {
                 codeAlbums2.Add(e.ALBUMS.CODE_ALBUM);
             }
             Assert.IsTrue(codeAlbums2.Contains(codeAlbum2));
         }

        [TestMethod]
        public void testAlbumNonEmprunt()
        {
            // get liste albums non empruntés depuis plus d'un an
            // vérifier qu'un album ayant déjà été emprunté recemment n'est pas présent dans cette liste
            // modifier (reculer de 1 an) sa date du dernier emprunt
            // vérifier qu'il est présent dans la liste

            EMPRUNTER album1 = m.EMPRUNTER.Where(a => a.CODE_ALBUM == 648).First();

            List<ALBUMS> listEmpruntsRetard = new List<ALBUMS>();
            listEmpruntsRetard.AddRange(admin.listAlbumNonEmprunt());

            int codeAlbum = album1.CODE_ALBUM;

            List<int> codeAlbums = new List<int>();
            foreach (ALBUMS e in listEmpruntsRetard)
            {
                codeAlbums.Add(e.CODE_ALBUM);
            }
            Assert.IsFalse(codeAlbums.Contains(codeAlbum));

            album1.DATE_EMPRUNT = DateTime.Parse("2020-03-21 16:50:26.967");
            m.SaveChanges();

            // vérification en retard
            listEmpruntsRetard.Clear();
            listEmpruntsRetard.AddRange(admin.listAlbumNonEmprunt());
            codeAlbums.Clear();

            foreach (ALBUMS e in listEmpruntsRetard)
            {
                codeAlbums.Add(e.CODE_ALBUM);
            }
            Assert.IsTrue(codeAlbums.Contains(codeAlbum));

            album1.DATE_EMPRUNT = DateTime.Parse("2021-06-04 16:25:59.707");
            m.SaveChanges();
        }

        public void testPurge()
        {
            // get liste albums non empruntés depuis plus d'un an
            // purger
            // vérifier que la liste est vide

        }
        public void testInscription()
        {
            // get liste abos
            // inscrire nouvel abo
            // vérifier qu'il existe dans la liste

            // ne pas faire US admin
        }
        public void testListeAbos()
        {
            // get liste abos par la fonction admin
            // get liste abos par requete de la base
            // vérifier que les listes ont les mêmes contenus

            // ne pas faire US admin
        }*/
    }
}
