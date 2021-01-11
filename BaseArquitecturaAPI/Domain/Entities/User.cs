using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Identification { get; set; }

        public string Names { get; set; }

        public string LastNames { get; set; }


        public string Email { get; set; }

        public string Password { get; set; }

        public bool Status { get; set; }

        public IEnumerable<UserRol> UserRols { get; set; }

        public IEnumerable<Vote> Votes { get; set; }

        public IEnumerable<UserAudit> UserChangedAudits { get; set; }

        public IEnumerable<UserAudit> UserThatChangeAudits { get; set; }

        public IEnumerable<CandidateAudit> CandidateAudits { get; set; }

        public IEnumerable<VotationAudit> VotationAudits { get; set; }

        public IEnumerable<VoteAudit> VoteAudits { get; set; }

        public IEnumerable<TwoFactorAuthentication> TwoFactorAuthentications { get; set; }

    }
}

