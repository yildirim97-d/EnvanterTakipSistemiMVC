//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sirket.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class cihaz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cihaz()
        {
            this.zimmet = new HashSet<zimmet>();
        }
    
        public int cihaz_id { get; set; }
        public string cihaz_ad { get; set; }
        public string cihaz_tür { get; set; }
        public string cihaz_konum { get; set; }
        public string cihaz_durum { get; set; }
        public System.DateTime cihaz_zimmet_tarih { get; set; }
        public Nullable<int> marka_id { get; set; }
    
        public virtual marka_kategori marka_kategori { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<zimmet> zimmet { get; set; }
    }
}
