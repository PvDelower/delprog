using System;
using System.Collections.Generic;

namespace SalonDel.Model
{
    public partial class Managers
    {
        public Managers()
        {
            Contract = new HashSet<Contract>();
        }

        public int ManegerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public DateTime DateRegistration { get; set; }
        public string Login { get; set; }

        public virtual Users LoginNavigation { get; set; }
        public virtual ICollection<Contract> Contract { get; set; }
    }
}
