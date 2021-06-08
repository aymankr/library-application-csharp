﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dedisclasik
{
    public static class Outils
    {
        public static MusiquePT2_NEntities musique { get; set; }

        public static bool dejaProlongé(EMPRUNTER emprunt)
        {
            bool dejaProlongé = true;
            TimeSpan temps = emprunt.DATE_RETOUR_ATTENDUE - emprunt.DATE_EMPRUNT;
            if (int.Parse(temps.Days.ToString()) <= emprunt.ALBUMS.GENRES.DÉLAI)
            {
                dejaProlongé = false;
            }
            return dejaProlongé;
        }

        public static bool dejaEmprunté(ALBUMS album)
        {
            foreach (EMPRUNTER emprunt in musique.EMPRUNTER)
            {
                if (album.Equals(emprunt.ALBUMS))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ActiverPagination(int tailleListe)
        {
            return (tailleListe <= 20);
        }
    }
}
