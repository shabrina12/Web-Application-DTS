using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApplicationDTS.Models;

namespace WebApplicationDTS.ViewModels
{
    public class LoginVM
    {
        // Email
        [EmailAddress]
        public string Email { get; set; }

        // Password
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
