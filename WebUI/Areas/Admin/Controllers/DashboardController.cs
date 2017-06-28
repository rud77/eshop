using System.Web.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    public class DashboardController : ACPanelController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}