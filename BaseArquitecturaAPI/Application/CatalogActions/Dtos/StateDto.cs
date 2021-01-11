using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CatalogActions.Dtos
{
    public class StateDto
    {
        public int StateId { get; set; }

        public string StateName { get; set; }

        public string CountryName { get; set; }

        public int CountryId { get; set; }

        public IEnumerable<CityDto> Cities { get; set; }
    }
}
