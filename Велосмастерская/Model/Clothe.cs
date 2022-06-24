using System;
using System.Collections.Generic;

namespace Велосмастерская.Model
{
    public partial class Clothe
    {
        public int Id { get; set; }
        public string BikeBikes { get; set; } = null!;
        public string BicycleShoes { get; set; } = null!;
        public string? Gloves { get; set; }
        public int? BicycleId { get; set; }

        public virtual Bicycle? Bicycle { get; set; }
        public string? Description { get; set; }

    }
}
