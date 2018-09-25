using GTR.CrossCutting.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GTR.Model
{
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; }

        [Required]
        public Role Role { get; set; }

        public List<SelectListItem> Roles { get; } = Enum.GetValues(typeof(Role))
            .Cast<Role>()
            .Select(rol => new SelectListItem
            {
                Text = rol.ToString(),
                Value = rol.ToString()
            }).ToList();
    }
}