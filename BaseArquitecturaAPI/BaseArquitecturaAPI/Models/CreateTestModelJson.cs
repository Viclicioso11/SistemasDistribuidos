using System.Runtime.Serialization;


namespace BaseArquitecturaAPI.Models
{
    [DataContract]
    public class CreateTestModelJson
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

    }
}
