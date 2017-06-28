using System.Collections.Generic;
using WebUI.Models.Catalog;

namespace WebUI.Models.Guest
{
    public class HomepageVM
    {
        public List<ProductLessInfoVM> ProductsList { get; set; }
        public List<string> SliderImages { get; set; }
    }
}