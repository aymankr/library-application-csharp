using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dedisclasik
{
    public partial class ABONNÉS
    {

        public static ABONNÉS RechercheAbonne(string login)
        {
            var abonné = (from a in Outils.musique.ABONNÉS
                      where a.LOGIN_ABONNÉ.Equals(login.Trim())
                      select a);
            return abonné.First();
        }

        public static int IdAlbum(string titre)
        {
            var id = (from a in Outils.musique.ALBUMS
                      where a.TITRE_ALBUM.Equals(titre)
                      select a.CODE_ALBUM);
            return id.First();
        }
    }
}
