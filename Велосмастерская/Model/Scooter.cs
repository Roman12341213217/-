using System;
using System.Collections.Generic;

namespace Велосмастерская.Model
{
    public partial class Scooter
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public int? ClientId { get; set; }

        public virtual Client? Client { get; set; }
        public string? Description { get; set; }

    }
}
