using System;

namespace WebUI.Models.Blog
{
    public class ArticleVM
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}