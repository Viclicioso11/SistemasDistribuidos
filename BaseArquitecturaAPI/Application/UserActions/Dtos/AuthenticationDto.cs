using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserActions.Dtos
{
    public class AuthenticationDto
    {
        public int AuthenticationId { get; set; }

        public string OneTimePassword { get; set; }
    }
}
