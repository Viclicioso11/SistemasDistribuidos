﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }

        public string CountryName { get; set; }

        public IEnumerable<State> States { get; set; }
    }
}
