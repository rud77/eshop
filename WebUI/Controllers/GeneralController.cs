using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebUI.Extensions;
using WebUI.Models.Shared;

namespace WebUI.Controllers
{
    public class GeneralController : Controller
    {
        protected string imagesStoragePath = @"https://eshop.blob.core.windows.net/images/";
        //protected string imagesStoragePath = @"~/App_Files/Images/";

        protected IOnlineShopRepository _repository;

        public GeneralController()
        {
            _repository = new OnlineShopRepository();
        }

        #region Common functions

        private static List<MenuItemVM> menuModel = GetMenuModel();
        private static LeftBarVM leftBarModel = GetLeftBarModel();

        private static List<MenuItemVM> GetMenuModel()
        {
            try
            {
                return new OnlineShopRepository().SelectAll<MenuItem>().ConvertToVM().ToList();
            }
            catch
            {
                return null;
            }
        }
        private static LeftBarVM GetLeftBarModel()
        {
            try
            {
                return new LeftBarVM()
                {
                    BrandsList = new OnlineShopRepository().SelectWithCount<Brand>(5).ConvertToVM().ToList(),
                    CategoriesList = new OnlineShopRepository().SelectWithCount<Category>(5).ConvertToVM().ToList()
                };
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Header + Menu

        [ChildActionOnly]
        public ActionResult Header()
        {
            try
            {
                HeaderVM model = new HeaderVM()
                {
                    LogoPath = new StringBuilder().Append(imagesStoragePath).Append(_repository.GetLogo()).ToString(),
                    Menu = menuModel
                };

                string curController = ControllerContext.ParentActionViewContext.RouteData.Values["controller"].ToString();
                string curAction = ControllerContext.ParentActionViewContext.RouteData.Values["action"].ToString();
                SetActive(model.Menu, curController, curAction);

                return PartialView("_Header", model);
            }
            catch
            {
                return null;
            }
        }

        [ChildActionOnly]
        public ActionResult MobileMenu()
        {
            try
            {
                List<MenuItemVM> model = menuModel;

                string curController = ControllerContext.ParentActionViewContext.RouteData.Values["controller"].ToString();
                string curAction = ControllerContext.ParentActionViewContext.RouteData.Values["action"].ToString();
                SetActive(model, curController, curAction);

                return PartialView("_MobileMenu", model);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Left bar

        [ChildActionOnly]
        public ActionResult LeftBar()
        {
            try
            {
                LeftBarVM model = leftBarModel;

                return PartialView("_LeftBar", model);
            }
            catch
            {
                return null;
            }
        }

        [ChildActionOnly]
        public ActionResult MobileLeftBar()
        {
            try
            {
                LeftBarVM model = leftBarModel;

                return PartialView("_MobileLeftBar", model);
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        #endregion

        #region Footer

        [ChildActionOnly]
        public ActionResult Footer()
        {
            try
            {
                FooterVM model = new FooterVM()
                {
                    Socials = _repository.SelectAll<SocialInfo>().ToList(),
                    WebsiteName = _repository.GetWebsiteName()
                };

                return PartialView("_Footer", model);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Pagination

        protected PaginationVM SetPaginationOptions(string controller, string action, int cPage, int count, int itemsInPage, int maxShowedPages)
        {
            return new PaginationVM
            {
                Action = action,
                Controller = controller,
                CurrentPage = cPage,
                ItemsCount = count,
                ItemsInPage = itemsInPage,
                MaxShowedPages = maxShowedPages
            };
        }

        [ChildActionOnly]
        public ActionResult Pagination(PaginationVM options)
        {
            try
            {
                PaginationVM model = new PaginationVM();

                options.OnFirstPage = (options.CurrentPage == 1) ? true : false;
                options.OnLastPage = (options.CurrentPage == options.PagesCount) ? true : false;

                model = options;

                if (model.PagesCount > 1)
                    return PartialView("_Pagination", model);
                else
                    throw new Exception();
            }
            catch
            {
                return null;
            }
        }

        #endregion

        private void SetActive(IEnumerable<MenuItemVM> m, string curController, string curAction)
        {
            foreach (var item in m)
            {
                item.ActiveClass = false;

                if (curController == item.ControllerName && (curAction == item.ActionName || curAction == "Page"))
                    item.ActiveClass = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (_repository != null)
            {
                _repository.Dispose();
                _repository = null;
            }
            base.Dispose(disposing);
        }
    }
}