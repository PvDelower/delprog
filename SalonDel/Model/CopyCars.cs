using System;
using System.Collections.Generic;

namespace SalonDel.Model
{
    public partial class CopyCars
    {
        public CopyCars()
        {
            Contract = new HashSet<Contract>();
        }

        public int CopyId { get; set; }
        public int CatalogId { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public string Vin { get; set; }
        public int EquipmentId { get; set; }
        public string Availability { get; set; }

        public virtual Cars Catalog { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual ICollection<Contract> Contract { get; set; }
    }
}
