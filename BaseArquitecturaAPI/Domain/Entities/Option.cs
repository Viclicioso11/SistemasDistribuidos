using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Option
    {
        public int Id { get; set; }

        public string OptionName { get; set; }

        public string OptionDescription { get; set; }

        public IEnumerable<RolOption> RolOptions { get; set; }
    }
}
