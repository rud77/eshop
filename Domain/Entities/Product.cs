using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Product
    {
        public Product()
        {
            Images = new List<ProductImage>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Sizes { get; set; }
        public string Colors { get; set; }
        public int? BrandId { get; set; }
        public int? FavoriteImageId { get; set; }
        public DateTime AddingDate { get; set; }
        public bool FeaturedProduct { get; set; }

        public virtual ICollection<ProductImage> Images { get; set; }
    }
}