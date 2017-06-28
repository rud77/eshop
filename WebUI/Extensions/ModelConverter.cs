using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebUI.Models.Blog;
using WebUI.Models.Catalog;
using WebUI.Models.Shared;

namespace WebUI.Extensions
{
    public static class ModelConverter
    {
        #region Menu
        public static MenuItemVM ConvertToVM(this MenuItem m)
        {
            return new MenuItemVM { Name = m.Name, ControllerName = m.ControllerName, ActionName = m.ActionName };
        }
        public static IEnumerable<MenuItemVM> ConvertToVM(this IEnumerable<MenuItem> m)
        {
            foreach (var item in m)
                yield return item.ConvertToVM();
        }
        #endregion

        #region Brand
        public static BrandVM ConvertToVM(this Brand m)
        {
            return new BrandVM { BrandId = m.BrandId, BrandName = m.BrandName };
        }
        public static IEnumerable<BrandVM> ConvertToVM(this IEnumerable<Brand> m)
        {
            foreach (var item in m)
                yield return item.ConvertToVM();
        }

        public static BrandVM ConvertToVM(this Brand m, string imagesStoragePath)
        {
            string imagePath = (m.BrandImageFullName != null) ? (imagesStoragePath + "Brands/" + m.BrandImageFullName) : (null);
            return new BrandVM { BrandId = m.BrandId, BrandName = m.BrandName, BrandImagePath = imagePath };
        }
        public static IEnumerable<BrandVM> ConvertToVM(this IEnumerable<Brand> m, string imagesStoragePath)
        {
            foreach (var item in m)
                yield return item.ConvertToVM(imagesStoragePath);
        }
        #endregion

        #region Category
        public static CategoryVM ConvertToVM(this Category m)
        {
            return new CategoryVM { CategoryId = m.CategoryId, CategoryName = m.CategoryName };
        }
        public static IEnumerable<CategoryVM> ConvertToVM(this IEnumerable<Category> m)
        {
            foreach (var item in m)
                yield return item.ConvertToVM();
        }
        #endregion

        #region Product
        public static ProductLessInfoVM ConvertToVMLessInfo(this Product m, string imagesStoragePath, string imgName)
        {
            string imagePath = null;
            if (imgName != null)
            {
                imagePath = new StringBuilder()
                    .Append(imagesStoragePath)
                    .Append("Products/")
                    .Append(m.ProductId)
                    .Append("/")
                    .Append(imgName)
                    .ToString();
            }

            return new ProductLessInfoVM { ProductId = m.ProductId, ProductName = m.ProductName, Price = m.Price, FavoriteImagePath = imagePath, AddingDate = m.AddingDate };
        }
        public static IEnumerable<ProductLessInfoVM> ConvertToVMLessInfo(this IEnumerable<Product> m, string imagesStoragePath)
        {
            foreach (var item in m)
            {
                if (item.FavoriteImageId.HasValue)
                {
                    foreach (var img in item.Images)
                        if (item.FavoriteImageId == img.ImageId)
                            yield return item.ConvertToVMLessInfo(imagesStoragePath, img.ImageFullName);
                }
                else
                {
                    yield return item.ConvertToVMLessInfo(imagesStoragePath, null);
                }
            }

        }

        public static ProductVM ConvertToVM(this Product m, string imagesStoragePath)
        {
            char separator = ',';

            return new ProductVM
            {
                ProductId = m.ProductId,
                ProductName = m.ProductName,
                Price = m.Price,
                Description = m.Description,
                Sizes = m.Sizes.Split(separator),
                Colors = m.Colors.Split(separator),
                Images = m.Images.Select(i => imagesStoragePath + "Products/" + m.ProductId + "/" + i.ImageFullName).ToArray()
            };
        }
        #endregion

        #region Slider images
        public static string ConvertToVM(this SliderImage m, string imagesStoragePath)
        {
            return new StringBuilder(imagesStoragePath)
                .Append("Slider/")
                .Append(m.ImageFullName)
                .ToString();
        }
        public static IEnumerable<string> ConvertToVM(this IEnumerable<SliderImage> m, string imagesStoragePath)
        {
            foreach (var item in m)
                yield return item.ConvertToVM(imagesStoragePath);
        }
        #endregion

        #region Article
        public static ArticleVM ConvertToVM(this Article m, bool shortText)
        {
            string textResult;
            if (shortText && m.Text.Length > 200)
            {
                string shortString = m.Text.Substring(0, 200);
                int indexOfLastSpace = shortString.LastIndexOf(' ') > 0 ? shortString.LastIndexOf(' ') : shortString.Length;
                textResult = shortString.Substring(0, indexOfLastSpace) + "...";
            }
            else
            {
                textResult = m.Text;
            }

            return new ArticleVM
            {
                ArticleId = m.ArticleId,
                Date = m.Date,
                Title = m.Title,
                Text = textResult
            };
        }
        public static IEnumerable<ArticleVM> ConvertToVM(this IEnumerable<Article> m, bool shortText)
        {
            foreach (var item in m)
                yield return item.ConvertToVM(shortText);
        }
        #endregion
    }
}