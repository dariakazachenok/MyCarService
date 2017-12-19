using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Models
{
    public class ClientDetailsViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set;}

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        [Display(Name = "Data Of Birth")]
        public DateTime? DataOfBirth { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Phone")]
        public int? Phone { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Photo")]
        public HttpPostedFileBase Photo { get; set; }
    }
}
