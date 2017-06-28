using System.Web.Mvc;
using Domain.Entities;
using System.Linq;
using System;

namespace WebUI.Areas.Admin.Controllers
{
    public class BlogMngController : ACPanelController
    {
        public ActionResult Index()
        {
            return View(_repository.SelectAll<Article>().ToList());
        }

        [HttpGet]
        [Route("BlogMng/EditArticle/{id}")]
        public ActionResult EditArticle(int id)
        {
            return View(_repository.Find<Article>(id));
        }

        [HttpPost]
        [Route("BlogMng/EditArticle/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditArticle(Article article)
        {
            if (ModelState.IsValid)
            {
                article.Date = DateTime.Now;
                if (_repository.Update(article))
                    return View("Success");

                return View(article);
            }
            else
            {
                return View(article);
            }
        }

        [HttpGet]
        [Route("BlogMng/RemoveArticle/{id}")]
        public ActionResult RemoveArticle(int id)
        {
            return View(_repository.Find<Article>(id));
        }

        [HttpPost]
        [Route("BlogMng/RemoveArticle/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveArticle(Article article)
        {
            if (_repository.Remove(article))
                return View("Success");

            return RedirectToAction("RemoveArticle");
        }

        [HttpGet]
        public ActionResult AddArticle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddArticle(Article article)
        {
            if (ModelState.IsValid)
            {
                article.Date = DateTime.Now;
                if (_repository.Add(article))
                    return View("Success");

                return View(article);
            }
            else
            {
                return View(article);
            }
        }
    }
}