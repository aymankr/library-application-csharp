using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dedisclasik
{
    public partial class EMPRUNTER
    {
        public static List<string> ListeAlbums(ABONNÉS abo)
        {
            var emprunts = (from a in Outils.musique.EMPRUNTER
                            where a.CODE_ABONNÉ == abo.CODE_ABONNÉ && a.DATE_RETOUR == null
                            select a.ALBUMS);
            HashSet<string> albums = new HashSet<string>();
            foreach (ALBUMS al in emprunts)
            {
                albums.Add(al.TITRE_ALBUM);
            }
            return albums.ToList();
        }
        
        public static ALBUMS typeGenre(string titre)
        {
            var album = (from a in Outils.musique.ALBUMS
                            where a.TITRE_ALBUM == titre
                            select a);
            return album.First();
        }
    }
}
