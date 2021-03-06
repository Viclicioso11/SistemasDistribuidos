﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class VoteAudit
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Votation Votation { get; set; }

        public int UserId { get; set; }

        public int VotationId { get; set; }
    }
}
