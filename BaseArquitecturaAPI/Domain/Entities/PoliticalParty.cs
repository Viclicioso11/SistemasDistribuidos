using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class PoliticalParty
    {
        public int Id { get; set; }

        public string PoliticalPartyName { get; set; }

        public string Abreviation { get; set; }

        public IEnumerable<Candidate> Candidates { get; set; }
    }
}
