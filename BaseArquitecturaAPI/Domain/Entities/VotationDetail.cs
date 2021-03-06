﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class VotationDetail
    {
        public int Id { get; set; }

        public Votation Votation { get; set; }

        public Candidate Candidate { get; set; }

        public int VotationId { get; set; }

        public int CandidateId { get; set; }
    }
}
