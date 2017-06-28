using System.Collections.Generic;
using WebUI.Models.Shared;

namespace WebUI.Models.Catalog
{
    public class CategoriesVM
    {
        public List<CategoryVM> CategoriesList { get; set; }
        public PaginationVM PaginationOptions { get; set; }
    }
}