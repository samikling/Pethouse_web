using System;
using System.Collections.Generic;

namespace PethouseWeb.Models
{
    public partial class User
    {
        public User()
        {
            Pets = new HashSet<Pet>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
