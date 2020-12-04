using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


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

        [Required]
        [DataMember(Name = "image_url")]
        public string ImageUrl { get; set; }


        [DataMember(Name = "candidates")]
        public IEnumerable<CandidateModelJson> Candidates { get; set; }
    }
}
