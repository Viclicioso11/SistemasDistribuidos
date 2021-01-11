using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace BaseArquitecturaAPI.Models
{
    [DataContract]
    public class OptionModelJson
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [Required]
        [DataMember(Name = "option_name")]
        public string OptionName { get; set; }

        [Required]
        [DataMember(Name = "option_description")]
        public string OptionDescription { get; set; }
    }
}
