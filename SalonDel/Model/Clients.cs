using System;
using System.Collections.Generic;

namespace SalonDel.Model
{
    public partial class Clients
    {
        public Clients()
        {
            Contract = new HashSet<Contract>();
        }

        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public int Passport { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int Number { get; set; }

        public virtual ICollection<Contract> Contract { get; set; }
    }
}
