using System;
using System.Collections.Generic;

namespace SalonDel.Model
{
    public partial class FormFactor
    {
        public FormFactor()
        {
            Cars = new HashSet<Cars>();
        }

        public int FormFactorId { get; set; }
        public string Name { get; set; }
        public int NumberOfDoors { get; set; }

        public virtual ICollection<Cars> Cars { get; set; }
    }
}
