using System.ComponentModel.DataAnnotations;

namespace DevWebsCourseProjectApp.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
