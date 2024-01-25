using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.User
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "User Name is required")]
        public String? FirstName { get; init; }

        [Required(ErrorMessage = "Last Name is required")]
        public String? LastName { get; init; }

        [Required(ErrorMessage = "Email is required")]
        public List<string> Skills { get; set; }
        public String? Email { get; init; }
        public String? Address1 { get; set; }
        public String? Address2 { get; set; }
        public String? City { get; set; }
        public String? Country { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public String? Password { get; init; }
        public Company Company { get; set; }
    }


}
