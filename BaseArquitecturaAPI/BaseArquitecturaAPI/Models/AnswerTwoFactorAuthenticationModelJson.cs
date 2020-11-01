using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BaseArquitecturaAPI.Models
{
    [DataContract]
    public class AnswerTwoFactorAuthenticationModelJson
    {
        [DataMember(Name = "authentication_id")]
        public int AuthenticationId { get; set; }

        [DataMember(Name = "one_time_password")]
        public string OneTimePassword { get; set; }

        [DataMember(Name = "user_id")]
        public int UserId { get; set; }
    }
}
