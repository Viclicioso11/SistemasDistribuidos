using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class UserRol
    {
        public int Id { get; set; }

        public Rol Rol { get; set; }

        public User User { get; set; }

        public int RolId { get; set; }

        public int UserId { get; set; }

    }
}
