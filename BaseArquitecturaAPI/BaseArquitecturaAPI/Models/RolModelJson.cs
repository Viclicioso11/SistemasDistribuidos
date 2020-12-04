using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BaseArquitecturaAPI.Models
{
    [DataContract]
    public class RolModelJson
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [Required]
        [DataMember(Name = "rol_name")]
        public string RolName { get; set; }
    }
}
