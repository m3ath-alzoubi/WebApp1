using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "UserName is requiered.")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password is requiered.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
