using Domain.Concrete;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using System.Data.Entity;

namespace Domain.Services
{
    public class OnlineShopRepository : IOnlineShopRepository
    {
        private OnlineShopDbContext context;

        public OnlineShopRepository()
        {
            context = new OnlineShopDbContext();
        }

        #region Generics
        public int Count<TModel>()
            where TModel : class
        {
            return context.Set<TModel>().Count();
        }

        public IEnumerable<TModel> SelectAll<TModel>()
            where TModel : class
        {
            return context.Set<TModel>().AsEnumerable();
        }

        public IEnumerable<TModel> SelectWithCount<TModel>(int count)
            where TModel : class
        {
            return context.Set<TModel>().Take(count).AsEnumerable();
        }

        public TModel FirstOrDefault<TModel>()
            where TModel : class
        {
            return context.Set<TModel>().FirstOrDefault();
        }

        public TModel Find<TModel>(int id)
            where TModel : class
        {
            return context.Set<TModel>().Find(id);
        }

        public bool Add<TModel>(TModel item)
            where TModel : class
        {
            try
            {
                context.Entry(item).State = EntityState.Added;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove<TModel>(TModel item)
            where TModel : class
        {
            try
            {
                context.Entry(item).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update<TModel>(TModel item)
            where TModel : class
        {
            try
            {
                context.Set<TModel>().Attach(item);
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        public IEnumerable<Product> GetFeaturedProducts(int count)
        {
            return context.Products
                .Include(p => p.Images)
                .Where(p => p.FeaturedProduct)
                .OrderByDescending(p => p.AddingDate)
                .Take(count)
                .AsEnumerable();
        }

        public IEnumerable<Article> GetArticles(int count, int page)
        {
            return context.Articles
                .OrderByDescending(a => a.Date)
                .Skip((page - 1) * count)
                .Take(count)
                .AsEnumerable();
        }

        public IEnumerable<Category> GetCategories(int count, int page)
        {
            return context.Categories
                .OrderBy(c => c.CategoryName)
                .Skip((page - 1) * count)
                .Take(count)
                .AsEnumerable();
        }

        public IEnumerable<Brand> GetBrands(int count, int page)
        {
            return context.Brands
                .OrderBy(b => b.BrandName)
                .Skip((page - 1) * count)
                .Take(count)
                .AsEnumerable();
        }

        public IEnumerable<Product> GetProducts(int count, int page)
        {
            return context.Products
                .Include(p => p.Images)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * count)
                .Take(count)
                .AsEnumerable();
        }

        public IEnumerable<Product> GetProducts(int count, int page, string searchString)
        {
            return context.Products
                .Include(p => p.Images)
                .Where(p => p.ProductName.Contains(searchString))
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * count)
                .Take(count)
                .AsEnumerable();
        }

        public IEnumerable<Product> GetProductsByBrand(int brandId, int count, int page)
        {
            return context.Products
                .Include(p => p.Images)
                .Where(p => p.BrandId == brandId)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * count)
                .Take(count)
                .AsEnumerable();
        }

        public IEnumerable<Product> GetProductsByBrand(int brandId, int count, int page, string searchString)
        {
            return context.Products
                .Include(p => p.Images)
                .Where(p => p.BrandId == brandId && p.ProductName.Contains(searchString))
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * count)
                .Take(count)
                .AsEnumerable();
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId, int count, int page)
        {
            return context.Products
                .Include(p => p.Images)
                .Join(context.ProductCategoryRelationships, p => p.ProductId, pc => pc.ProductId, (p, pc) => new { p, pc })
                .Where(r => r.pc.CategoryId == categoryId)
                .Select(r => r.p)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * count)
                .Take(count)
                .AsEnumerable();
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId, int count, int page, string searchString)
        {
            return context.Products
                .Include(p => p.Images)
                .Join(context.ProductCategoryRelationships, p => p.ProductId, pc => pc.ProductId, (p, pc) => new { p, pc })
                .Where(r => r.pc.CategoryId == categoryId && r.p.ProductName.Contains(searchString))
                .Select(r => r.p)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * count)
                .Take(count)
                .AsEnumerable();
        }

        public Product GetProduct(int id)
        {
            return context.Products
                .Where(p => p.ProductId == id)
                .Include(p => p.Images)
                .FirstOrDefault();
        }

        public string GetLogo()
        {
            return context.WebsiteInfos.Select(l => l.WebsiteLogo).FirstOrDefault();
        }

        public string GetWebsiteName()
        {
            return context.WebsiteInfos.Select(n => n.WebsiteName).FirstOrDefault();
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
                context = null;
            }
        }
    }
}