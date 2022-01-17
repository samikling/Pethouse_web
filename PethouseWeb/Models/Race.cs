using System;
using System.Collections.Generic;

namespace PethouseWeb.Models
{
    public partial class Race
    {
        public Race()
        {
            Breeds = new HashSet<Breed>();
            Pets = new HashSet<Pet>();
        }

        public int RaceId { get; set; }
        public string Racename { get; set; } = null!;

        public virtual ICollection<Breed> Breeds { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
