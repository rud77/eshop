using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.Guest
{
    public class ContactUsVM
    {
        public ContactFormVM Form { get; set; }
        public ContactInfo Info { get; set; }
    }

    public class ContactFormVM
    {
        [Required(ErrorMessage = "This field is required.")]
        public string FromName { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string FromEmail { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Message { get; set; }
    }
}