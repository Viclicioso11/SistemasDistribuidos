using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BaseArquitecturaAPI.Models
{
    [DataContract]
    public class VoteModelJson
    {
        [DataMember(Name = "vote_id")]
        public int Id { get; set; }

        [Required]
        [DataMember(Name = "candidate_id")]
        public int CandidateId { get; set; }

        [Required]
        [DataMember(Name = "user_id")]
        public int UserId { get; set; }

        [Required]
        [DataMember(Name = "votation_id")]
        public int VotationId { get; set; }

    }
}
