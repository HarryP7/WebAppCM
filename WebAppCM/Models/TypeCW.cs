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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TypeCW
    {
        [Key]
        public int Id { get; set; }
        public string tCWname { get; set; }
    
        [InverseProperty(nameof(Application.TypeCW))]        
        public virtual ICollection<Application> Applications { get; set; } = new HashSet<Application>();
        public IEnumerable<Application> app;
    }
}
