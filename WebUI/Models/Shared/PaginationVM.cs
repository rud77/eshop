using System;

namespace WebUI.Models.Shared
{
    public class PaginationVM
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public int ItemsCount { get; set; }
        public int ItemsInPage { get; set; }
        public int CurrentPage { get; set; }
        public int MaxShowedPages { get; set; }
        public bool OnFirstPage { get; set; }
        public bool OnLastPage { get; set; }
        public int PagesCount
        {
            get
            {
                return (int)Math.Ceiling((decimal)ItemsCount / ItemsInPage);
            }
        }
    }
}