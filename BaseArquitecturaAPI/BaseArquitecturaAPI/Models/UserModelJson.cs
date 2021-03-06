﻿using System.Runtime.Serialization;

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

        [DataMember(Name = "rol_id")]
        public int RolId { get; set; }

    }
}
