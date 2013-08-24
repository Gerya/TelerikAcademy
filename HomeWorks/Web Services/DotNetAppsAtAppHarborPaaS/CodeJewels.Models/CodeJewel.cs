using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace CodeJewels.Models
{
    [DataContract(Namespace="CodeJewel")]
    public class CodeJewel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string Category { get; set; }

        [DataMember]
        public string AuthorEmail { get; set; }

        [DataMember]
        public int Rating { get; set; }

        [Required]
        [DataMember]
        public string SourceCode { get; set; }
    }
}
