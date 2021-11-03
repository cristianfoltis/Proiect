using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data
{
    public class User
    {
        [Key]
        public int UserId { get; set; }


        [Required]
        public string UserName { get; set; }



        [Required]
        public string UserRole { get; set; }


        [Required]
        public string UserLocation { get; set; }
        public virtual IList<Device> Devices { get; set; }
    }
}
