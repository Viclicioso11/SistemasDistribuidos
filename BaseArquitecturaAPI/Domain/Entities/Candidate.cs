using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Candidate
    {
        public int CandidateId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Surname { get; set; }

        public bool Status { get; set; }

        public PoliticalParty PoliticalParty { get; set; }

        public IEnumerable<VotationDetail> VotationDetails { get; set; }

        public IEnumerable<Vote> Votes { get; set; }
    }
}
