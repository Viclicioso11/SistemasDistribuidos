using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Votation
    {
        public int Id { get; set; }

        public int VotationTypeId { get; set; }

        public string VotationDescription { get; set; }

        public DateTime VotationStartDate { get; set; }

        public DateTime VotationEndDate { get; set; }

        public bool VotationStatus { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public VotationType VotationType { get; set; }

        public IEnumerable<VotationDetail> VotationDetails { get; set; }

        public IEnumerable<VoteAudit> VoteAudits { get; set; }

        public IEnumerable<VotationAudit> VotationAudits { get; set; }
    }
}
