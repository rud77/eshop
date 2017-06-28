using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebUI.Extensions;
using WebUI.Models.Blog;
using WebUI.Models.Shared;

namespace WebUI.Controllers
{
    [RoutePrefix("Blog")]
    public class BlogController : GeneralController
    {
        const int articlesInPage = 3;
        const int articleMaxShowedPages = 3;

        #region Blog

        [HttpGet]
        [Route("{page:int=1}")]
        [Route("Index/{page:int=1}")]
        public ActionResult Index(int page)
        {
            try
            {
                List<ArticleVM> articleViewModel = null;

                PaginationVM paginationModel = SetPaginationOptions(
                    ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString(),
                    page,
                    _repository.Count<Article>(),
                    articlesInPage,
                    articleMaxShowedPages);

                List<Article> articleModel = _repository.GetArticles(paginationModel.ItemsInPage, page).ToList();

                if (articleModel.Count > 0 || page == 1)
                    articleViewModel = articleModel.ConvertToVM(true).ToList();
                else
                    throw new Exception();

                return View(new BlogVM { ArticlesList = articleViewModel, PaginationOptions = paginationModel });
            }
            catch
            {
                return Redirect("~/Blog");
            }
        }

        #endregion

        #region Article

        [HttpGet]
        [Route("Article/{articleId}")]
        public ActionResult Article(int articleId)
        {
            try
            {
                return View(_repository.Find<Article>(articleId).ConvertToVM(false));
            }
            catch
            {
                return RedirectToAction("Index", new { page = string.Empty });
            }
        }

        #endregion
    }
}