using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BaseArquitecturaAPI.Models
{
    [DataContract]
    public class DeleteModelJson
    {
        [DataMember(Name = "ids")]
        public List<int> Ids { get; set; }
    }
}
