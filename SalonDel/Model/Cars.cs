using System;
using System.Collections.Generic;

namespace SalonDel.Model
{
    public partial class Cars
    {
        public Cars()
        {
            CopyCars = new HashSet<CopyCars>();
        }

        public string Title { get; set; }
        public int CatalogId { get; set; }
        public int ManufacturerId { get; set; }
        public int FormFactorId { get; set; }
        public int Place { get; set; }

        public virtual FormFactor FormFactor { get; set; }
        public virtual Manufactures Manufacturer { get; set; }
        public virtual ICollection<CopyCars> CopyCars { get; set; }
    }
}
