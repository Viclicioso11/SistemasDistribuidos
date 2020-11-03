using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class VotationType
    {
        public int Id { get; set; }

        public string VotationTypeName { get; set; }

        public string VotationTypeDescription { get; set; }

        public IEnumerable<Votation> Votations { get; set; }
    }
}
