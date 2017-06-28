using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Article
    {
        public int ArticleId { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Title { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [MinLength(10)]
        public string Text { get; set; }
    }
}