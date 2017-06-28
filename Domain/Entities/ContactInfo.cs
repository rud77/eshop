using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table(name: "ContactInfos")]
    public class ContactInfo
    {
        [Key]
        [Column(Order = 1)]
        public string Address { get; set; }

        [Key]
        [Column(Order = 2)]
        public string Email { get; set; }

        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
    }
}