using Domain.Services;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Authorize(Roles = "admin")]
    public class ACPanelController : Controller
    {
        protected IOnlineShopRepository _repository;

        public ACPanelController()
        {
            _repository = new OnlineShopRepository();
        }

        public ActionResult Verification()
        {
            try
            {
                string key = GenerateRandomNo().ToString();
                var res = SendSms(key);

                TempData["Key"] = key;
                return View();
            }
            catch
            {
                return RedirectToAction("Index", "Guest");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Verification(Verification model)
        {
            try
            {
                if (TempData["Key"].ToString() == model.Key)
                    return RedirectToAction("Index", "Dashboard");

                return RedirectToAction("SignOut", "User");
            }
            catch
            {
                return RedirectToAction("Verification");
            }
        }

        #region Helper methods
        private async Task<MessageResource> SendSms(string key)
        {
            string AccountSid = "ACe85e1c2d6f8cef9498547f0a1259a1f4";
            string AuthToken = "c305917167e84d50bebb6576dc6ac155";

            TwilioClient.Init(AccountSid, AuthToken);
            MessageResource message = await MessageResource.CreateAsync(to: new PhoneNumber("+37477722041"), from: new PhoneNumber("+15594219525"), body: key);
            return message;
        }

        private int GenerateRandomNo()
        {
            Random _rdm = new Random();
            return _rdm.Next(1000, 9999);
        }
        #endregion

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