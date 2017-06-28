using Domain.Entities;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Extensions;
using WebUI.Models.Guest;

namespace WebUI.Controllers
{
    public class GuestController : GeneralController
    {
        #region Homepage

        public ActionResult Index()
        {
            try
            {
                return View(new HomepageVM
                {
                    ProductsList = _repository.GetFeaturedProducts(12).ConvertToVMLessInfo(imagesStoragePath).ToList(),
                    SliderImages = _repository.SelectAll<SliderImage>().ConvertToVM(imagesStoragePath).ToList()
                });
            }
            catch
            {
                return new HttpNotFoundResult();
            }
        }

        #endregion

        #region About us

        public ActionResult AboutUs()
        {
            try
            {
                return View();
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        #endregion

        private string mailTo = "r.khachikyan95@gmail.com";
        #region Contact us

        private ContactUsVM GetContactUsVM()
        {
            try
            {
                return new ContactUsVM
                {
                    Form = new ContactFormVM(),
                    Info = _repository.FirstOrDefault<ContactInfo>()
                };
            }
            catch
            {
                return null;
            }
        }

        public ActionResult ContactUs()
        {
            try
            {
                return View(GetContactUsVM());
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ContactUs(ContactFormVM Form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var body = "<h1>Email From: {0} ({1})</h1><h1>Message:</h1><p>{2}</p>";
                    var message = new MailMessage();
                    message.To.Add(new MailAddress(mailTo));
                    message.From = new MailAddress(Form.FromEmail);
                    message.Subject = "Email from ContactUs";
                    message.Body = string.Format(body, Form.FromName, Form.FromEmail, Form.Message);
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient())
                    {
                        await smtp.SendMailAsync(message);
                        return View("SendingSuccess");
                    }
                }
                else
                {
                    return View(GetContactUsVM());
                }
            }
            catch
            {
                return RedirectToAction("ContactUs");
            }
        }

        #endregion
    }
}