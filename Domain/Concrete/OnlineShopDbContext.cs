using Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Domain.Concrete
{
    public class OnlineShopDbContext : IdentityDbContext<IdentityUser> //DbContext
    {
        public OnlineShopDbContext()
            : base("OnlineShopDbContext")
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategoryRelationship> ProductCategoryRelationships { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<SliderImage> SliderImages { get; set; }
        public DbSet<SocialInfo> SocialInfos { get; set; }
        public DbSet<WebsiteInfo> WebsiteInfos { get; set; }
    }
}