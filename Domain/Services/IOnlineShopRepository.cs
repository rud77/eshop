using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Services
{
    public interface IOnlineShopRepository : IDisposable
    {
        #region Generics
        int Count<TModel>() where TModel : class;
        IEnumerable<TModel> SelectAll<TModel>() where TModel : class;
        IEnumerable<TModel> SelectWithCount<TModel>(int count) where TModel : class;
        TModel FirstOrDefault<TModel>() where TModel : class;
        TModel Find<TModel>(int id) where TModel : class;
        bool Add<TModel>(TModel item) where TModel : class;
        bool Remove<TModel>(TModel item) where TModel : class;
        bool Update<TModel>(TModel item) where TModel : class;
        #endregion

        IEnumerable<Product> GetFeaturedProducts(int count);
        IEnumerable<Article> GetArticles(int count, int page);
        IEnumerable<Category> GetCategories(int count, int page);
        IEnumerable<Brand> GetBrands(int count, int page);
        IEnumerable<Product> GetProducts(int count, int page);
        IEnumerable<Product> GetProducts(int count, int page, string searchString);
        IEnumerable<Product> GetProductsByBrand(int brandId, int count, int page);
        IEnumerable<Product> GetProductsByBrand(int brandId, int count, int page, string searchString);
        IEnumerable<Product> GetProductsByCategory(int categoryId, int count, int page);
        IEnumerable<Product> GetProductsByCategory(int categoryId, int count, int page, string searchString);
        Product GetProduct(int id);
        string GetLogo();
        string GetWebsiteName();
    }
}