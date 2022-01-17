using System;
using System.Collections.Generic;

namespace PethouseWeb.Models
{
    public partial class Pet
    {
        public int PetId { get; set; }
        public string Petname { get; set; } = null!;
        public DateTime? Birthdate { get; set; }
        public string? Photo { get; set; }
        public int UserId { get; set; }
        public int? RaceId { get; set; }
        public int? BreedId { get; set; }

        public virtual Breed? Breed { get; set; }
        public virtual Race? Race { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
