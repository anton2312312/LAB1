//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBLogmenu
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        public int id { get; set; }
        public string login { get; set; }
        public byte[] passwordHash { get; set; }
    }
}
