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
    
    public partial class User
    {
        public int Id { get; set; }
        public string surnameName { get; set; }
        public string name { get; set; }
        public string patronimic { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public User() { }
        public User(string surnameName, string name, string patronimic)
        {
            this.surnameName = surnameName;
            this.name = name;
            this.patronimic = patronimic;
        }
        public User(string surnameName, string name, string patronimic, string phone, string email)
            : this(surnameName, name, patronimic)
        {
            this.phone = phone;
            this.email = email;
        }
    }
}