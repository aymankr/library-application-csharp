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
        private static MusiquePT2_NEntities m = Outils.musique = new MusiquePT2_NEntities();

        
        [TestMethod]
        public void testEmpruntsEnRetard()
        {
            inscription.inscrire("test", "unitaire", "testdu33", "123");
            ABONNÉS abo = Outils.getAbo();
            EMPRUNTER emp = Outils.creerEmprunt(abo, "2021-06-10 16:50:26.967", "2021-06-11 17:50:26.967",null);

            List <EMPRUNTER> listEmpruntsRetard = admin.listEmpruntRetard();
            Assert.IsFalse(listEmpruntsRetard.Contains(emp));

            emp.DATE_EMPRUNT = DateTime.Parse("2021-05-02 16:50:26.967");
            emp.DATE_RETOUR_ATTENDUE = DateTime.Parse("2021-05-09 16:50:26.967");
            m.SaveChanges();

            listEmpruntsRetard = admin.listEmpruntRetard();
            Assert.IsTrue(listEmpruntsRetard.Contains(emp));

            Outils.supprimerEmprunt(emp);
            Outils.supprimerAbonnes();
        }

        [TestMethod]
        public void testAlbumsNonEmpruntes()
        {
            inscription.inscrire("test", "unitaire", "testdu33", "123");
            ABONNÉS abo = Outils.getAbo();
            EMPRUNTER emp = Outils.creerEmprunt(abo, "2018-03-10 16:50:26.967", "2018-03-10 17:50:26.967", null);

            List<ALBUMS> listNonEmprunts = admin.listAlbumNonEmprunt();
            Assert.IsTrue(listNonEmprunts.Contains(emp.ALBUMS));

            Outils.supprimerEmprunt(emp);
            emp = Outils.creerEmprunt(abo, "2021-03-10 16:50:26.967", "2021-04-10 17:50:26.967", null);

            listNonEmprunts = admin.listAlbumNonEmprunt();
            Assert.IsFalse(listNonEmprunts.Contains(emp.ALBUMS));

            Outils.supprimerEmprunt(emp);
            Outils.supprimerAbonnes();
        }

        
        [TestMethod]
        public void testMeilleursEmprunts()
        {
            List<ALBUMS> listMeilleurs = admin.listMeilleurEmprunt();
            int nbMaxEmprunt = listMeilleurs[0].EMPRUNTER.Count();

            foreach(ALBUMS alb in listMeilleurs)
            {
                if (alb.EMPRUNTER.Count > nbMaxEmprunt) nbMaxEmprunt = alb.EMPRUNTER.Count;
            }

            if (m.ABONNÉS.Count() > nbMaxEmprunt + 1)
            {
                var listAbos = m.ABONNÉS.Take(nbMaxEmprunt + 1).ToList();

                for (int i = 0; i < nbMaxEmprunt + 1; i++)
                {
                    ABONNÉS aboTmp = listAbos[i];
                    Outils.creerEmprunt(aboTmp, "2021-06-10 16:50:26.967", "2021-07-10 17:50:26.967", Outils.getAlbum());
                }

                listMeilleurs = admin.listMeilleurEmprunt(); 
                int nbMaxEmprunt2 = listMeilleurs[0].EMPRUNTER.Count();

                foreach (ALBUMS alb in listMeilleurs)
                {
                    if (alb.EMPRUNTER.Count > nbMaxEmprunt2) nbMaxEmprunt2 = alb.EMPRUNTER.Count;
                }
                Assert.IsTrue(nbMaxEmprunt < nbMaxEmprunt2);

                Outils.musique.Database.ExecuteSqlCommand("delete EMPRUNTER where EMPRUNTER.CODE_ALBUM in (select CODE_ALBUM from ALBUMS where TITRE_ALBUM like 'Bach: Rampal')");
                m.SaveChanges();
            }
        }
    }
}
