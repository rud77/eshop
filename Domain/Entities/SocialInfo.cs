using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table(name: "SocialInfos")]
    public class SocialInfo
    {
        [Key]
        [Column(Order = 1)]
        public string Link { get; set; }

        [Key]
        [Column(Order = 2)]
        public string Icon { get; set; }
    }
}