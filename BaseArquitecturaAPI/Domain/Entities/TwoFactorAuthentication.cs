using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TwoFactorAuthentication
    {
        public int TwoFactorAuthenticationId { get; set; }

        public string OneTimePassword { get; set; }

        public int Attempts { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int Status { get; set; }

        public DateTime ExpirationDate { get; set; }

    }
}
