using System;
using System.Collections.Generic;

namespace Велосмастерская.Model
{
    public partial class Bicycle
    {
        public Bicycle()
        {
            Clothes = new HashSet<Clothe>();
            Orders = new HashSet<Order>();
            SpareParts = new HashSet<SparePart>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public decimal Model { get; set; }
        public string Color { get; set; } = null!;
        public decimal NumberOfGears { get; set; }
        public string Material { get; set; } = null!;
        public string CountryOfOrigin { get; set; } = null!;
        public decimal FactoryPrice { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Clothe> Clothes { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<SparePart> SpareParts { get; set; }

    }
}
