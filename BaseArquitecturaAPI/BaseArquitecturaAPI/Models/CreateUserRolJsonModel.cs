using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BaseArquitecturaAPI.Models
{
    [DataContract]
    public class CreateUserRolJsonModel
    {
        [DataMember(Name = "user_id")]
        public int UserId { get; set; }

        [DataMember(Name = "rol_ids")]
        public List<int> RolIds { get; set; }
    }
}
