using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserDTO
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(maximumLength: 25, ErrorMessage = "UserRole is too long.")]
        public string UserRole { get; set; }

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "UserLocation is too long.")]
        public string UserLocation { get; set; }

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Username is too long.")]
        public string UserName { get; set; }

    }

}
