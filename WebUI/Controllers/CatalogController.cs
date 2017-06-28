using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebUI.Extensions;
using WebUI.Models.Catalog;
using WebUI.Models.Shared;

namespace WebUI.Controllers
{
    [RoutePrefix("Catalog")]
    public class CatalogController : GeneralController
    {
        const int itemsInPage = 12;
        const int maxShowedPages = 3;

        //  Actions
        #region Catalog

        #region All items

        [HttpGet]
        [Route("{page:int=1}/{sortBy?}/{searchString?}")]
        [Route("Index/{page:int=1}/{sortBy?}/{searchString?}")]
        public ActionResult Index(int page, string sortBy, string searchString)
        {
            try
            {
                List<Product> productsModel = null;
                if (!string.IsNullOrEmpty(searchString))
                    productsModel = _repository.GetProducts(itemsInPage, page, searchString).ToList();
                else
                    productsModel = _repository.GetProducts(itemsInPage, page).ToList();

                List<ProductLessInfoVM> productsViewModel = null;
                if (productsModel.Count > 0 || page == 1)
                    productsViewModel = productsModel.ConvertToVMLessInfo(imagesStoragePath).ToList();
                else
                    throw new Exception();

                PaginationVM paginationModel = InitPaginationFor<Product>(page);
                List<SortingVM> sortingModel = SortDataInit();

                SetSortingParameter(ref sortBy);
                productsViewModel = SortItems(productsViewModel, sortingModel, sortBy);

                return View(new CatalogVM
                {
                    ProductsList = productsViewModel,
                    PaginationOptions = paginationModel,
                    SortingOptions = sortingModel
                });
            }
            catch
            {
                return Redirect("~/Catalog");
            }
        }

        #endregion

        #region Filtering by brand

        [HttpGet]
        [Route("Brand/{brandId}/{page:int=1}/{sortBy?}/{searchString?}")]
        public ActionResult Brand(int brandId, int page, string sortBy, string searchString)
        {
            try
            {
                List<Product> productsModel = null;
                if (!string.IsNullOrEmpty(searchString))
                    productsModel = _repository.GetProductsByBrand(brandId, itemsInPage, page, searchString).ToList();
                else
                    productsModel = _repository.GetProductsByBrand(brandId, itemsInPage, page).ToList();

                List<ProductLessInfoVM> productsViewModel = null;
                if (productsModel.Count > 0 || page == 1)
                    productsViewModel = productsModel.ConvertToVMLessInfo(imagesStoragePath).ToList();
                else
                    throw new Exception();

                PaginationVM paginationModel = InitPaginationFor<Product>(page);
                List<SortingVM> sortingModel = SortDataInit();

                SetSortingParameter(ref sortBy);
                productsViewModel = SortItems(productsViewModel, sortingModel, sortBy);

                return View("Index", new CatalogVM
                {
                    ProductsList = productsViewModel,
                    PaginationOptions = paginationModel,
                    SortingOptions = sortingModel
                });
            }
            catch
            {
                return RedirectToAction("Brands", new { page = string.Empty });
            }
        }

        #endregion

        #region Filtering by category

        [HttpGet]
        [Route("Category/{categoryId}/{page:int=1}/{sortBy?}/{searchString?}")]
        public ActionResult Category(int categoryId, int page, string sortBy, string searchString)
        {
            try
            {
                List<Product> productsModel = null;
                if (!string.IsNullOrEmpty(searchString))
                    productsModel = _repository.GetProductsByCategory(categoryId, itemsInPage, page, searchString).ToList();
                else
                    productsModel = _repository.GetProductsByCategory(categoryId, itemsInPage, page).ToList();

                List<ProductLessInfoVM> productsViewModel = null;
                if (productsModel.Count > 0 || page == 1)
                    productsViewModel = productsModel.ConvertToVMLessInfo(imagesStoragePath).ToList();
                else
                    throw new Exception();

                PaginationVM paginationModel = InitPaginationFor<Product>(page);
                List<SortingVM> sortingModel = SortDataInit();

                SetSortingParameter(ref sortBy);
                productsViewModel = SortItems(productsViewModel, sortingModel, sortBy);

                return View("Index", new CatalogVM
                {
                    ProductsList = productsViewModel,
                    PaginationOptions = paginationModel,
                    SortingOptions = sortingModel
                });
            }
            catch
            {
                return RedirectToAction("Categories", new
                {
                    page = string.Empty
                });
            }
        }

        #endregion

        #endregion

        #region Brands

        [HttpGet]
        [Route("Brands/{page:int=1}")]
        public ActionResult Brands(int page)
        {
            try
            {
                List<BrandVM> brandsViewModel = null;

                PaginationVM paginationModel = InitPaginationFor<Brand>(page);

                List<Brand> brandsModel = _repository.GetBrands(paginationModel.ItemsInPage, page).ToList();

                if (brandsModel.Count > 0 || page == 1)
                    brandsViewModel = brandsModel.ConvertToVM(imagesStoragePath).ToList();
                else
                    throw new Exception();

                return View(new BrandsVM { BrandsList = brandsViewModel, PaginationOptions = paginationModel });
            }
            catch
            {
                return RedirectToAction("Index", new { page = string.Empty });
            }
        }

        #endregion

        #region Categories

        [HttpGet]
        [Route("Categories/{page:int=1}")]
        public ActionResult Categories(int page)
        {
            try
            {
                List<CategoryVM> categoriesViewModel = null;

                PaginationVM paginationModel = InitPaginationFor<Category>(page);

                List<Category> categoriesModel = _repository.GetCategories(paginationModel.ItemsInPage, page).ToList();

                if (categoriesModel.Count > 0 || page == 1)
                    categoriesViewModel = categoriesModel.ConvertToVM().ToList();
                else
                    throw new Exception();

                return View(new CategoriesVM { CategoriesList = categoriesViewModel, PaginationOptions = paginationModel });
            }
            catch
            {
                return RedirectToAction("Index", new { page = string.Empty });
            }
        }

        #endregion

        #region Product

        [HttpGet]
        [Route("Product/{productId}")]
        public ActionResult Product(int productId)
        {
            try
            {
                return View(_repository.GetProduct(productId).ConvertToVM(imagesStoragePath));
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        #endregion

        //  Functions
        #region Sort data init

        private List<SortingVM> SortDataInit()
        {
            List<SortingVM> sorting = new List<SortingVM>();

            sorting.Add(new SortingVM { Text = "Alphabetically, A-Z", Value = "name", IsActive = false });
            sorting.Add(new SortingVM { Text = "Alphabetically, Z-A", Value = "name_d", IsActive = false });
            sorting.Add(new SortingVM { Text = "Price, low to high", Value = "price", IsActive = false });
            sorting.Add(new SortingVM { Text = "Price, high to low", Value = "price_d", IsActive = false });
            sorting.Add(new SortingVM { Text = "Date, new to old", Value = "date", IsActive = false });
            sorting.Add(new SortingVM { Text = "Date, old to new", Value = "date_d", IsActive = false });

            return sorting;
        }

        #endregion

        #region Set sorting parameter in cookies

        private void SetSortingParameter(ref string sortBy)
        {
            if (sortBy == null)
            {
                if (Request.Cookies["sortingState"] != null)
                {
                    sortBy = Request.Cookies["sortingState"].Value;
                }
                else
                {
                    sortBy = "name";
                    Response.Cookies["sortingState"].Value = sortBy;
                }
            }
            else
            {
                Response.Cookies["sortingState"].Value = sortBy;
            }
        }

        #endregion

        #region Sort Products

        private List<ProductLessInfoVM> SortItems(List<ProductLessInfoVM> items, List<SortingVM> sortingModel, string sortBy)
        {
            switch (sortBy)
            {
                case "name":
                    items = items.OrderBy(o => o.ProductName).ToList();
                    sortingModel.Where(s => s.Value == "name").FirstOrDefault().IsActive = true;
                    break;
                case "name_d":
                    items = items.OrderByDescending(o => o.ProductName).ToList();
                    sortingModel.Where(s => s.Value == "name_d").FirstOrDefault().IsActive = true;
                    break;
                case "price":
                    items = items.OrderBy(o => o.Price).ToList();
                    sortingModel.Where(s => s.Value == "price").FirstOrDefault().IsActive = true;
                    break;
                case "price_d":
                    items = items.OrderByDescending(o => o.Price).ToList();
                    sortingModel.Where(s => s.Value == "price_d").FirstOrDefault().IsActive = true;
                    break;
                case "date":
                    items = items.OrderBy(o => o.AddingDate).ToList();
                    sortingModel.Where(s => s.Value == "date").FirstOrDefault().IsActive = true;
                    break;
                case "date_d":
                    items = items.OrderByDescending(o => o.AddingDate).ToList();
                    sortingModel.Where(s => s.Value == "date_d").FirstOrDefault().IsActive = true;
                    break;
                default:
                    items = items.OrderBy(o => o.ProductName).ToList();
                    sortingModel.Where(s => s.Value == "name").FirstOrDefault().IsActive = true;
                    break;
            }
            return items;
        }

        #endregion

        #region Init pagination

        private PaginationVM InitPaginationFor<T>(int page)
            where T : class
        {
            return SetPaginationOptions(
                    ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString(),
                    page,
                    _repository.Count<T>(),
                    itemsInPage,
                    maxShowedPages);
        }

        #endregion
    }
}