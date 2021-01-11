using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BaseArquitecturaAPI.Models
{
    [DataContract]
    public class CreateRolOptionJsonModel
    {
        [Required]
        [DataMember(Name = "rol_id")]
        public int RolId { get; set; }

        [Required]
        [DataMember(Name = "option_ids")]
        public List<int> OptionIds { get; set; }
    }
}
