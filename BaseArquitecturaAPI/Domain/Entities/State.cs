using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class State
    {
        public int Id { get; set; }

        public string StateName { get; set; }

        public Country Country { get; set; }

        public int CountryId { get; set; }

        public IEnumerable<City> Cities { get; set; }
    }
}
