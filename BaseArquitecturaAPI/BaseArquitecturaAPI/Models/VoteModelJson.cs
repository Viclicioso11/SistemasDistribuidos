using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

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

        [DataMember(Name = "user")]
        public UserModelJson User { get; set; }

        [DataMember(Name = "candidate")]
        public CandidateModelJson Candidate { get; set; }
    }
}
