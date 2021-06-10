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
    }
}
