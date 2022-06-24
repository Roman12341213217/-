using System;
using System.Collections.Generic;

namespace Велосмастерская.Model
{
    public partial class Order
    {
        public int Id { get; set; }
        public int BicycleId { get; set; }
        public DateTime Date { get; set; }
        public string Discount { get; set; } = null!;
        public int? ClientId { get; set; }

        public virtual Bicycle Bicycle { get; set; } = null!;
        public virtual Client? Client { get; set; }
    }
}
