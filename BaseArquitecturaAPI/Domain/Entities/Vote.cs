using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Vote
    {
        public int VoteId { get; set; }

        public User User { get; set; }

        public Candidate Candidate { get; set; }

        public int UserId { get; set; }

        public int CandidateId { get; set; }
    }
}
