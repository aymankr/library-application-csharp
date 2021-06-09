using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dedisclasik
{
    public partial class ALBUMS
    {
        /*override
        public string ToString()
        {
            /*string nonPrécisé = "Non précisée";
            string date = nonPrécisé;
            if (this.ANNÉE_ALBUM != null)
            {
                date = this.ANNÉE_ALBUM.ToString().Trim();
            }
            string editeur = nonPrécisé;
            string pays = nonPrécisé;
            if (this.EDITEURS != null)
            {
                editeur = this.EDITEURS.NOM_EDITEUR.Trim();
                if (this.EDITEURS.PAYS != null)
                {
                    pays = this.EDITEURS.PAYS.NOM_PAYS.Trim();
                }
            }
            string genre = nonPrécisé;
            if (this.GENRES != null)
            {
                genre = this.GENRES.LIBELLÉ_GENRE.Trim();
            }
            string infos = this.TITRE_ALBUM.Trim() + "   " + editeur + "   " + date + "   " + pays + "   " + genre;
            if (Outils.dejaEmprunté(this))
            {
                infos += " -> Déjà emprunté";
            }
            return infos;*/

        /*string infos = this.TITRE_ALBUM.Trim();
        if (Outils.dejaEmprunté(this))
        {
            infos += " -> Déjà emprunté";
        }
        return infos;
    }*/

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
            string infos="";
            if (Outils.dejaEmprunté(this))
            {
                infos = "X";
            }
            return infos;
        }
    }
}
