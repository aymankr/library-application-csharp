using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dedisclasik;

namespace DedisclasikTests
{
    [TestClass]
    public class InscriptionEmpruntTest
    {
        private Inscription inscription = new Inscription();
        private static MusiquePT2_NEntities m = Outils.musique = new MusiquePT2_NEntities();

        [TestMethod]
        public void testInscription()
        {
            ABONNÉS abo = Outils.getAbo();
            Assert.IsFalse(m.ABONNÉS.Contains(abo));

            inscription.inscrire("test", "unitaire", "testdu33", "123");

            abo = Outils.getAbo();
            Assert.IsTrue(m.ABONNÉS.Where(a => a.CODE_ABONNÉ == abo.CODE_ABONNÉ).Select(a => a.CODE_ABONNÉ).FirstOrDefault() == abo.CODE_ABONNÉ);

            Outils.supprimerAbonnes();
        }

        [TestMethod]
        public void testEmprunts()
        {
            inscription.inscrire("test", "unitaire", "testdu33", "123");
            ABONNÉS abo = Outils.getAbo();
            List<string> listEmprunts = EMPRUNTER.ListeAlbums(abo);

            Assert.IsTrue(listEmprunts.Count == 0);

            EMPRUNTER emp1 = Outils.creerEmprunt(abo, "2021-03-10 16:50:26.967", "2021-09-15 16:50:26.967");
            EMPRUNTER emp2 = Outils.creerEmprunt(abo, "2021-05-10 16:50:26.967", "2021-07-15 16:50:26.967");
            EMPRUNTER emp3 = Outils.creerEmprunt(abo, "2021-06-10 16:50:26.967", "2021-08-15 16:50:26.967");

            listEmprunts = EMPRUNTER.ListeAlbums(abo);
            Assert.IsTrue(listEmprunts[0].Trim().Equals(emp1.ALBUMS.TITRE_ALBUM.Trim()));
            Assert.IsTrue(listEmprunts[1].Trim().Equals(emp2.ALBUMS.TITRE_ALBUM.Trim()));
            Assert.IsTrue(listEmprunts[2].Trim().Equals(emp3.ALBUMS.TITRE_ALBUM.Trim()));

            Outils.supprimerEmprunt(emp1);
            Outils.supprimerEmprunt(emp2);
            Outils.supprimerEmprunt(emp3);
            Outils.supprimerAbonnes();
        }
    }
}
