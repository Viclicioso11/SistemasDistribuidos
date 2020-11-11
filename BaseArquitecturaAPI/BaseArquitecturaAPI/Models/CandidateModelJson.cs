using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BaseArquitecturaAPI.Models
{
    [DataContract]
    public class CandidateModelJson
    {
        [DataMember(Name = "candidate_id")]
        public int Id { get; set; }

        [Required]
        [DataMember(Name = "political_party_id")]
        public int PoliticalPartyId { get; set; }

        [Required]
        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }

        [DataMember(Name = "middlename")]
        public string MiddleName { get; set; }

        [Required]
        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        [DataMember(Name = "surnname")]
        public string Surname { get; set; }

    }
}
