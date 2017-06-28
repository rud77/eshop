using System.Collections.Generic;
using WebUI.Models.Shared;

namespace WebUI.Models.Catalog
{
    public class CatalogVM
    {
        public List<ProductLessInfoVM> ProductsList { get; set; }
        public PaginationVM PaginationOptions { get; set; }
        public List<SortingVM> SortingOptions { get; set; }
    }
}