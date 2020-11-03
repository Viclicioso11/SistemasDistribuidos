using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BaseArquitecturaAPI.Models
{
    [DataContract]
    public class PoliticalPartyModelJson
    {
        [DataMember(Name = "political_party_id")]
        public int Id { get; set; }

        [Required]
        [DataMember(Name = "political_party_name")]
        public string PoliticalPartyName { get; set; }

        [Required]
        [DataMember(Name = "political_party_abreviation")]
        public string Abreviation { get; set; }


        [DataMember(Name = "candidates")]
        public IEnumerable<CandidateModelJson> Candidates { get; set; }
    }
}
