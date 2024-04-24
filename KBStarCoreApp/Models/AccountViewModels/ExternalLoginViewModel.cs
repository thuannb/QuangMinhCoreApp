using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KBStarCoreApp.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        //[Required]
        //public string Email { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string DOB { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
