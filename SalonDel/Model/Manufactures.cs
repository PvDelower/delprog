using System;
using System.Collections.Generic;

namespace SalonDel.Model
{
    public partial class Manufactures
    {
        public Manufactures()
        {
            Cars = new HashSet<Cars>();
        }

        public int ManufactureId { get; set; }
        public string Country { get; set; }
        public string Mark { get; set; }

        public virtual ICollection<Cars> Cars { get; set; }
    }
}
