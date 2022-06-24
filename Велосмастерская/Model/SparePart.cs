using System;
using System.Collections.Generic;

namespace Велосмастерская.Model
{
    public partial class SparePart
    {
        public int Id { get; set; }
        public string Brakes { get; set; } = null!;
        public string Quantity { get; set; } = null!;
        public string Chains { get; set; } = null!;
        public string Saddles { get; set; } = null!;
        public int? BicycleId { get; set; }

        public virtual Bicycle? Bicycle { get; set; }
        public string? Description { get; set; }
    }
}
