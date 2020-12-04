using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BaseArquitecturaAPI.Models
{
    [DataContract]
    public class DeleteRolOptionJsonModel
    {
        [Required]
        [DataMember(Name = "rol_options")]
        public List<RolOptionModelJson> RolOption { get; set; }
    }

    [DataContract]
    public class RolOptionModelJson
    {
        [Required]
        [DataMember(Name = "rol_id")]
        public int RolId { get; set; }

        [Required]
        [DataMember(Name = "option_id")]
        public int OptionId { get; set; }
    }
}
