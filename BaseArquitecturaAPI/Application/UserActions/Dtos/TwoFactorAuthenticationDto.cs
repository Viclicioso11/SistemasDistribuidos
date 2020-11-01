using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserActions.Dtos
{
    public class TwoFactorAuthenticationDto
    {
        public int Attempts { get; set; }

        public string Message { get; set; }

        public int TwoFactorAuthenticationId { get; set; }

        public int UserId { get; set; }

        public bool Validated { get; set; } 
    }
}
