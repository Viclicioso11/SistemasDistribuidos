using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class RolOption
    {
        public int RolOptionId { get; set; }

        public int OptionId { get; set; }

        public int RolId { get; set; }

        public Rol Rol { get; set; }

        public Option Option { get; set; }
    }
}
