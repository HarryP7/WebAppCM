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

    public partial class HandBookOfCOType
    {
        [Key]
        public int Id { get; set; }
        public string tHCOname { get; set; }
    
        [InverseProperty(nameof(CadastralObject.HandBookOfCOType))]
        public virtual ICollection<CadastralObject> CadastralObjects { get; set; } = new HashSet<CadastralObject>();
        public IEnumerable<CadastralObject> co;      
    }
}
