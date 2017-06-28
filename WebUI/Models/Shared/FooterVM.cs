using Domain.Entities;
using System.Collections.Generic;

namespace WebUI.Models.Shared
{
    public class FooterVM
    {
        public List<SocialInfo> Socials { get; set; }
        public string WebsiteName { get; set; }
    }
}