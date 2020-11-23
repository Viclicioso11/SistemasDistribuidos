using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

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
