using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Rol
    {
        public int RolId { get; set; }

        public string RolName { get; set; }

        public IEnumerable<UserRol> UserRols { get; set; }

        public IEnumerable<RolOption> RolOptions { get; set; }
    }
}
