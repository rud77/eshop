using System.Collections.Generic;
using WebUI.Models.Catalog;

namespace WebUI.Models.Shared
{
    public class LeftBarVM
    {
        public List<BrandVM> BrandsList { get; set; }
        public List<CategoryVM> CategoriesList { get; set; }
    }
}