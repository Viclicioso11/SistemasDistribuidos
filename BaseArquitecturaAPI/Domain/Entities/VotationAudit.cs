﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class VotationAudit
    {
        public int VotationAuditId { get; set; }

        public DateTime StatusChangedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public User ChangesMadeByUser { get; set; }

        public bool VotationStatusChangedTo { get; set; }

        public Votation Votation { get; set; }
    }
}
