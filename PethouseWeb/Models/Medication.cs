using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace PethouseWeb.Models
{
    public partial class Medication
    {
        [Key]
        public int MedId { get; set; }
        public string Medname { get; set; } = null!;
        public DateTime? MedDate { get; set; }
        public DateTime? MedExpDate { get; set; }
        public int PetId { get; set; }

        public virtual Pet Pet { get; set; } = null!;
    }
}
