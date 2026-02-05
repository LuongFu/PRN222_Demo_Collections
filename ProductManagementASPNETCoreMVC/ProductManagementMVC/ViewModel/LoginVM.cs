using System.ComponentModel.DataAnnotations;

namespace ProductManagementMVC.ViewModel
{
    public class LoginVM
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string MemberPassword { get; set; }
    }

}
