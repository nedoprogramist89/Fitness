//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fitnes
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public int ID_Order { get; set; }
        public int OrderNumber { get; set; }
        public int Clients_ID { get; set; }
        public int Technique_ID { get; set; }
        public string DateOfIssue { get; set; }
        public string ReturnDate { get; set; }
        public decimal Price { get; set; }
        public int OrderStatus_ID { get; set; }
        public string RentalPeriod { get; set; }
        public int Employees_ID { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual Technique Technique { get; set; }
    }
}
