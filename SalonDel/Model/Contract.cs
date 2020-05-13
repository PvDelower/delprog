using System;
using System.Collections.Generic;

namespace SalonDel.Model
{
    public partial class Contract
    {
        public int ContractId { get; set; }
        public int ClientId { get; set; }
        public string TypeContract { get; set; }
        public int CopyId { get; set; }
        public DateTime Data { get; set; }
        public decimal Price { get; set; }
        public int ManagerId { get; set; }
        public string PaymentType { get; set; }
        public bool Dilivery { get; set; }
        public string AdditionalOptions { get; set; }

        public virtual Clients Client { get; set; }
        public virtual CopyCars Copy { get; set; }
        public virtual Managers Manager { get; set; }
    }
}
