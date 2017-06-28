using System.Collections.Generic;
using WebUI.Models.Shared;

namespace WebUI.Models.Blog
{
    public class BlogVM
    {
        public List<ArticleVM> ArticlesList { get; set; }
        public PaginationVM PaginationOptions { get; set; }
    }
}