﻿using System.Runtime.Serialization;

namespace BaseArquitecturaAPI.Models
{
    [DataContract]
    public class DeleteUserRolJsonModel
    {
        [DataMember(Name = "user_id")]
        public int UserId { get; set; }

        [DataMember(Name = "rol_id")]
        public int RolId { get; set; }
    }
}
