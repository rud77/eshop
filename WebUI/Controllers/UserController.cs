using System.Web.Mvc;
using WebMatrix.WebData;
using WebUI.Models.User;

namespace WebUI.Controllers
{
    public class UserController : GeneralController
    {
        public ActionResult SignIn()
        {
            try
            {
                if (Request.IsAuthenticated)
                    SignOut();

                return View();
            }
            catch
            {
                return RedirectToAction("Index", "Guest");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInVM model)
        {
            try
            {
                if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
                    return RedirectToAction(actionName: "Index", controllerName: "Guest");

                return View(model);
            }
            catch
            {
                return RedirectToAction("SignIn");
            }
        }

        public ActionResult SignUp()
        {
            try
            {
                if (Request.IsAuthenticated)
                    SignOut();

                return View();
            }
            catch
            {
                return RedirectToAction("Index", "Guest");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(SignUpVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
                    WebSecurity.Login(model.UserName, model.Password);
                    return RedirectToAction("Index", "Guest");
                }

                return View(model);
            }
            catch
            {
                return RedirectToAction("SignUp");
            }
        }

        [Authorize]
        public ActionResult SignOut()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Guest");
        }
    }
}