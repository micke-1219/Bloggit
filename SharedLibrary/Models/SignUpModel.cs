using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(2, ErrorMessage = "Username must contain at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "Username can not contain more than 50 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid email adress.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Your password must contain at least 8 characters.")]
        [MaxLength(50, ErrorMessage = "Your password can not contain more than 50 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password confirmation does not match.")]
        public string PasswordConfirm { get; set; }
    }
}
