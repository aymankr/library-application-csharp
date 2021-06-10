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
        private Administrateur admin = new Administrateur();
        private Inscription inscription = new Inscription();
        private MusiquePT2_NEntities m = new MusiquePT2_NEntities();

        [TestMethod]
        public void prolongement()
        {
            inscription.inscrire("test", "unitaire", "testdu33", "123");
            ABONNÉS abo = Outils.getAbo();
            EMPRUNTER emp1 = Outils.creerEmprunt(abo, "2021-03-10 16:50:26.967", "2021-03-10 17:50:26.967");

            //l'emprunt n'est pas prolongé
            Assert.IsFalse(Outils.dejaProlongé(emp1));

            //l'emprunt est prolongé
            Assert.IsTrue(emp1.DATE_RETOUR_ATTENDUE < emp1.DATE_RETOUR_ATTENDUE.AddDays(emp1.ALBUMS.GENRES.DÉLAI));

            Outils.supprimerEmprunt(emp1);
            Outils.supprimerAbonnes();
        }

        [TestMethod]
        public void testEmpruntsEnRetard()
        {
            inscription.inscrire("test", "unitaire", "testdu33", "123");
            ABONNÉS abo = Outils.getAbo();
            EMPRUNTER emp = Outils.creerEmprunt(abo, "2021-03-10 16:50:26.967", "2021-03-10 17:50:26.967");

            //l'emprunt est en retard
            DateTime dateNow = DateTime.Now;
            Assert.IsTrue((int)(dateNow - emp.DATE_RETOUR_ATTENDUE).TotalDays >= 10);

            Outils.supprimerEmprunt(emp);
            Outils.supprimerAbonnes();
        }
        

        [TestMethod]
        public void tetsMeilleursEmprunts()
        {

        }

        [TestMethod]
        public void AlbumsNonEmpruntes()
        {
            inscription.inscrire("test", "unitaire", "testdu33", "123");
            ABONNÉS abo = Outils.getAbo();
            EMPRUNTER emp = Outils.creerEmprunt(abo, "2018-03-10 16:50:26.967", "2018-03-10 17:50:26.967");

            //l'emprunt n'a pas été emprunté depuis plus d'un an
            DateTime dateNow = DateTime.Now;
            Assert.IsTrue((int)(dateNow - emp.DATE_EMPRUNT).TotalDays > 365);

            Outils.supprimerEmprunt(emp);
            Outils.supprimerAbonnes();
        }

        [TestMethod]
        public void testPurge()
        {

        }

        /*
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

        public void testPurge()
        {
            // get liste albums non empruntés depuis plus d'un an
            // purger
            // vérifier que la liste est vide

        }*/
    }
}
