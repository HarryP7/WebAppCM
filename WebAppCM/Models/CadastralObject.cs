//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppCM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CadastralObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CadastralObject()
        {
            this.Application = new HashSet<Application>();
        }
    
        public int Id { get; set; }
        public int fk_tipeCO { get; set; }
        public string cadastralNumber { get; set; }
        public System.DateTime dateOfEntry { get; set; }
        public string legalStatus { get; set; }
        public string address { get; set; }
        public double square { get; set; }
        public decimal cost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Application> Application { get; set; }
        public virtual HandBookOfCOTypes HandBookOfCOTypes { get; set; }
    }
}