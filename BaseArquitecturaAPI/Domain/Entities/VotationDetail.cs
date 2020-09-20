using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class VotationDetail
    {
        public int VotationDetailId { get; set; }

        public Votation Votation { get; set; }

        public Candidate Candidate { get; set; }
    }
}
