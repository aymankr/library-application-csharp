using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dedisclasik
{
    public partial class ALBUMS
    {

        public string getEditeur()
        {
            string editeur = "Non Précisé";
            if (this.EDITEURS != null)
            {
                editeur = this.EDITEURS.NOM_EDITEUR.Trim();
            }
            return editeur;
        }

        public string getAnnée()
        {
            string année = "Non Précisé";
            if (this.ANNÉE_ALBUM != null)
            {
                année = this.ANNÉE_ALBUM.ToString().Trim();
            }
            return année;
        }

        public string getPays()
        {
            string pays = "Non Précisé";
            if (this.EDITEURS.PAYS != null)
            {
                pays = this.EDITEURS.PAYS.NOM_PAYS.Trim();
            }
            return pays;
        }

        public string getGenre()
        {
            string genre = "Non Précisé";
            if (this.GENRES != null)
            {
                genre = this.GENRES.LIBELLÉ_GENRE.Trim();
            }
            return genre;
        }

        public string getDejaEmprunter()
        {
            string infos = "";
            if (Outils.dejaEmprunté(this))
            {
                infos = "X";
            }
            return infos;
        }
    }
}
