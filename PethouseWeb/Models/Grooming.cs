using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace PethouseWeb.Models
{
    public partial class Grooming
    {
        [Key]
        public int GroomId { get; set; }
        public string Groomname { get; set; } = null!;
        public DateTime? GroomDate { get; set; }
        public DateTime? GroomExpDate { get; set; }
        public string? Comments { get; set; }
        public int PetId { get; set; }

        public virtual Pet Pet { get; set; } = null!;
    }
}
