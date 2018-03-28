using System.Runtime.Serialization;
using OnionNetCore.Core.Util;

namespace OnionNetCore.Core.DTOs
{
    [DataContract]
    public class UserResponse
    {

        public string Id { get; set; }


        [DataMember]
        public string PublicId =>  Encryption.Encrypt(Id);


        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }
    }
}
