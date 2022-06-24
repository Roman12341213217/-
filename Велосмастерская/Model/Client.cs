using System;
using System.Collections.Generic;

namespace Велосмастерская.Model
{
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
            Scooters = new HashSet<Scooter>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string DateOfBirth { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string City { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Scooter> Scooters { get; set; }
    }
}
