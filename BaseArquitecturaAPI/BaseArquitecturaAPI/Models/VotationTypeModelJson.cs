using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BaseArquitecturaAPI.Models
{
    [DataContract]
    public class VotationTypeModelJson
    {
        [DataMember(Name = "votation_type_id")]
        public int Id { get; set; }

        [Required]
        [DataMember(Name = "votation_type_id")]
        public string VotationTypeName { get; set; }

        [Required]
        [DataMember(Name = "votation_type_id")]
        public string VotationTypeDescription { get; set; }
    }
}
