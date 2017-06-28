using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table(name: "WebsiteInfos")]
    public class WebsiteInfo
    {
        public int Id { get; set; }
        public string WebsiteName { get; set; }
        public string WebsiteLogo { get; set; }
    }
}