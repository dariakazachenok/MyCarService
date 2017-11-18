using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Models
{
    public class ClientModel
    {
        public int? Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter First Name ")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter Last Name ")]
        [StringLength(50)]
        public string LastName { get; set;}

        [Display(Name = "Data Of Birth")]
       // [Required(ErrorMessage = "Please enter Data Of Birth ")]
        public DateTime? DataOfBirth { get; set; }

        [Display(Name = "Address")]
        //[Required(ErrorMessage = "Please enter Address ")]
        [StringLength(100)]
        public string Address { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Please enter Phone ")]
        public int? Phone { get; set; }

        [Display(Name = "Email")]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Photo")]
        public HttpPostedFileBase Photo { get; set; }
    }
}
