using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name ="Register Name")]
        public string CustName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }


        [DataType(DataType.Password)]
        [MinLength(5)]
        [Required]
        public string PassWord { get; set; }
    }
}

