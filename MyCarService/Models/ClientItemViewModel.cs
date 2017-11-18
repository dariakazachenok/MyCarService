using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ClientItemViewModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Photo { get; set; }
    }
}
