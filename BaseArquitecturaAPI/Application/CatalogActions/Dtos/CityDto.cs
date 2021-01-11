using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CatalogActions.Dtos
{
    public class CityDto
    {
        public int CityId { get; set; }

        public string CityCode { get; set; }

        public string CityName { get; set; }

        public string StateName { get; set; }

        public int StateId { get; set; }
    }
}
