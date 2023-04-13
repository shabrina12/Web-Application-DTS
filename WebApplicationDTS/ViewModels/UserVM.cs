using System.ComponentModel.DataAnnotations;

namespace WebApplicationDTS.ViewModels
{
    public class UserVM
    {
        // Email
        [EmailAddress]
        public string Email { get; set; }
        // Password
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
