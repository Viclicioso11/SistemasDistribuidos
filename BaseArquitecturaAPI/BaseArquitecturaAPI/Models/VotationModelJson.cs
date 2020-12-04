using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BaseArquitecturaAPI.Models
{
    [DataContract]
    public class VotationModelJson
    {
        
        [DataMember(Name = "votation_id")]
        public int Id { get; set; }

        [Required]
        [DataMember(Name = "votation_type_id")]
        public int VotationTypeId { get; set; }

        [Required]
        [DataMember(Name = "votation_description")]
        public string VotationDescription { get; set; }

        [Required]
        [DataMember(Name = "votation_start_date")]
        public DateTime VotationStartDate { get; set; }

        [Required]
        [DataMember(Name = "votation_end_date")]
        public DateTime VotationEndDate { get; set; }


        [DataMember(Name = "votation_status")]
        public bool VotationStatus { get; set; }

        [Required]
        [DataMember(Name = "city_id")]
        public int CityId { get; set; }

        [Required]
        [DataMember(Name = "candidates")]
        public List<int> Candidates { get; set; }

    }
}
