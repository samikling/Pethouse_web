using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PethouseWeb.Models
{
    public partial class Vaccine
    {
        [Key]
        public int VacId { get; set; }
        public string Vacname { get; set; } = null!;
        public DateTime? VacDate { get; set; }
        public DateTime? VacExpDate { get; set; }
        public int PetId { get; set; }

        public virtual Pet Pet { get; set; } = null!;
    }
}
