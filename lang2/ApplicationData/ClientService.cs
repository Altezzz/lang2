//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace lang2.ApplicationData
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClientService
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int ServiceID { get; set; }
        public System.DateTime StartTime { get; set; }
        public string Comment { get; set; }
        public Nullable<decimal> Money { get; set; }
        public string city { get; set; }
        public string sotrudnik { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Service Service { get; set; }
    }
}
