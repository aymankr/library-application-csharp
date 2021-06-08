using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dedisclasik
{
    [TestClass]
    public class AdministrateurTest
    {
        [TestMethod]
        public void testProlongementEmprunt()
        {
            ABONNÉS unAbonne = new ABONNÉS();

            unAbonne.NOM_ABONNÉ = "unNom";
            unAbonne.PRÉNOM_ABONNÉ = "unPrénom";
            unAbonne.LOGIN_ABONNÉ = "abonneDu33";
            unAbonne.PASSWORD_ABONNÉ = "azerty123";
        }
    }
}
