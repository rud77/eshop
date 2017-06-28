using System.Collections.Generic;
using WebUI.Models.Shared;

namespace WebUI.Models.Catalog
{
    public class BrandsVM
    {
        public List<BrandVM> BrandsList { get; set; }
        public PaginationVM PaginationOptions { get; set; }
    }
}