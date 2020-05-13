using System;
using System.Collections.Generic;

namespace SalonDel.Model
{
    public partial class Equipment
    {
        public Equipment()
        {
            CopyCars = new HashSet<CopyCars>();
        }

        public int EquipmentId { get; set; }
        public string TypeEngine { get; set; }
        public double EngineCapacity { get; set; }
        public string Drive { get; set; }

        public virtual ICollection<CopyCars> CopyCars { get; set; }
    }
}
