using System.ComponentModel.DataAnnotations;

namespace DevWebsCourseProjectApp.ViewModels
{
    // using this for facebook external login
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
