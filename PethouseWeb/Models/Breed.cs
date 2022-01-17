using System;
using System.Collections.Generic;

namespace PethouseWeb.Models
{
    public partial class Breed
    {
        public Breed()
        {
            Pets = new HashSet<Pet>();
        }

        public int BreedId { get; set; }
        public string Breedname { get; set; } = null!;
        public int RaceId { get; set; }

        public virtual Race Race { get; set; } = null!;
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
