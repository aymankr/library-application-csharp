using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dedisclasik
{
    public partial class EMPRUNTER
    {
        public static List<ALBUMS> ListeAlbums()
        {
            var emprunts = (from a in Outils.musique.EMPRUNTER
                            where a.CODE_ABONNÉ == Connexion.abonné.CODE_ABONNÉ && a.DATE_RETOUR == null
                            select a.ALBUMS).ToList();
            return emprunts;
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
