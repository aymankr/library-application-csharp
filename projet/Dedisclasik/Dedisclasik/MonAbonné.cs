using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dedisclasik
{
    public partial class ABONNÉS
    {

        public static int RechercheAbonne(string login)
        {
            var abonné = (from a in Outils.musique.ABONNÉS
                      where a.LOGIN_ABONNÉ.Equals(login.Trim())
                      select a.CODE_ABONNÉ);
            return abonné.First();
        }

        public static List<String> RechercheTitre(string titre)
        {
            var titres = (from a in Outils.musique.ALBUMS
                          where a.TITRE_ALBUM.Contains(titre)
                          select a.TITRE_ALBUM).ToList();
            List<String> albums = new List<String>();
            foreach (string t in titres)
            {
                albums.Add(t);
            }
            return albums;
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
