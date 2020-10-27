using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BaseArquitecturaAPI.Models
{
    [DataContract]
    public class DeleteUserModelJson
    {
        [DataMember(Name = "ids")]
        public List<int> Ids { get; set; }
    }
}
