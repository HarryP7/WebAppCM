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

    public partial class Application
    {
        [Key, Display(Name = "№:")]
        public int Id { get; set; }
        [ForeignKey(nameof(User)), Display(Name = "Заказчик:")]
        public string fk_User { get; set; }
        [Display(Name = "Дата:")]
        public System.DateTime date { get; set; }
        [ForeignKey(nameof(HandBookOfCOType)),Display(Name = "Кадастровый объект:")]
        public int? fk_typeCO { get; set; }
        [ForeignKey(nameof(TypeCW)), Display(Name = "Тип КР:")]
        public int? fk_typeCW { get; set; }
        [Display(Name = "Описание:")]
        public string description { get; set; }
        [ForeignKey(nameof(Status)), Display(Name = "Статус:")]
        public int fk_status { get; set; }
        [Display(Name = "Стоимость:")]
        public decimal cost { get; set; }

        [InverseProperty(nameof(CadastralWork.app))]
        public virtual ICollection<CadastralWork> CadastralWorks { get; set; } = new HashSet<CadastralWork>();
        public virtual HandBookOfCOType HandBookOfCOType { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Status Status { get; set; }
        public virtual TypeCW TypeCW { get; set; }
        public virtual PayModel PayModel { get; set; }
    }
}
