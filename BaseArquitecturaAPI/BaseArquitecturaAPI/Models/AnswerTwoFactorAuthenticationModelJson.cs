using System.Runtime.Serialization;

namespace BaseArquitecturaAPI.Models
{
    [DataContract]
    public class AnswerTwoFactorAuthenticationModelJson
    {
        [DataMember(Name = "authentication_id")]
        public int Id { get; set; }

        [DataMember(Name = "one_time_password")]
        public string OneTimePassword { get; set; }

        [DataMember(Name = "user_id")]
        public int UserId { get; set; }
    }
}
