using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class Device
    {
        [ForeignKey(nameof(Device))]
        public int DeviceId { get; set; }


        [Required]
        
        public string DeviceName { get; set; }


        [Required]
   
        public string Manufacturer { get; set; }

        [Required]
       
        public string DeviceType { get; set; }

        [Required]
        public string DeviceOS { get; set; }


        [Required]
        public string DeviceProcessor { get; set; }

        [Required]
        public string DeviceRAM { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
        
    }
}
