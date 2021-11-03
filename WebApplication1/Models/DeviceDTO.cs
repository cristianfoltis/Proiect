using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Models
{
    public class DeviceDTO
    {
        public int DeviceId { get; set; }

        [Required]
        [StringLength(maximumLength: 25, ErrorMessage = "Manufacturer name is too long.")]
        public string Manufacturer { get; set; }

        [Required]
        [StringLength(maximumLength: 15, ErrorMessage = "DeviceType name is too long.")]
        public string DeviceType { get; set; }

        [Required]
        [StringLength(maximumLength: 15, ErrorMessage = "DeviceOS name is too long.")]
        public string DeviceOS { get; set; }


        [Required]
        [StringLength(maximumLength: 15, ErrorMessage = "DeviceProcessor name is too long.")]
        public string DeviceProcessor { get; set; }

        [Required]
        [StringLength(maximumLength: 10, ErrorMessage = "DeviceRAM information is too long.")]
        public string DeviceRAM { get; set; }

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "DeviceName is too long.")]
        public string DeviceName { get; set; }

        public UserDTO User { get; set; }


        [Required]
        public int UserId { get; set; }

    }

}
