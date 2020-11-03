using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BaseArquitecturaAPI.Models
{
    [DataContract]
    public class UserModelJson
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "identification")]
        public string Identification { get; set; }

        [DataMember(Name = "names")]
        public string Names { get; set; }

        [DataMember(Name = "last_names")]
        public string LastNames { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }

    }
}
