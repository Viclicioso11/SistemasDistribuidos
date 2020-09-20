using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CandidateAudit
    {
        public int CandidateAuditId { get; set; }

        public int ChangesMadeByUserId { get; set; }

        public DateTime StatusChangedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public User ChangesMadeByUser { get; set; }

        public bool CandidateStatusChangedTo { get; set; }


    }
}
