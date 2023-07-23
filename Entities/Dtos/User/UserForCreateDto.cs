using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Entities.Dtos.User
{
    public record UserForCreateDto : UserDto
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "First Name is Required.")]
        public string? FirstName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public String? Password { get; init; }
    }
}
