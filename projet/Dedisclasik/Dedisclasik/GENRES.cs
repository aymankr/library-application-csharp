//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dedisclasik
{
    using System;
    using System.Collections.Generic;
    
    public partial class GENRES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GENRES()
        {
            this.ALBUMS = new HashSet<ALBUMS>();
        }
    
        public int CODE_GENRE { get; set; }
        public string LIBELLÉ_GENRE { get; set; }
        public int DÉLAI { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALBUMS> ALBUMS { get; set; }
    }
}
