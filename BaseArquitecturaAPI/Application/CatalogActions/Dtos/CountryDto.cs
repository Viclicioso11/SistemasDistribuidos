using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CatalogActions.Dtos
{
    public class CountryDto
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public IEnumerable<StateDto> States { get; set; }
    }
}
