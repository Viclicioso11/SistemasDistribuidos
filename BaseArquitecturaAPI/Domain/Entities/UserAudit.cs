using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class UserAudit
    {
        public int UserAuditId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? StatusChangedAt { get; set; }

        public bool? UserStatusChangedTo { get; set; }

        public string LastPassword { get; set; }

        public string LastEmail { get; set; }

        public DateTime? LastLogin { get; set; }

        public DateTime? ChangeMadeAt { get; set; }

        public User UserChanged { get; set; }

        public int UserChangedId { get; set; }

        public User ChangesMadeByUser { get; set; }

        public int ChangesMadeByUserId { get; set; }
    }
}
