using System;
using System.Collections.Generic;

namespace SalonDel.Model
{
    public partial class Users
    {
        public Users()
        {
            Managers = new HashSet<Managers>();
        }

        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Managers> Managers { get; set; }
    }
}
