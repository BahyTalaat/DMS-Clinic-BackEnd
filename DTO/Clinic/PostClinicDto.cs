using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Clinic
{
    public class PostClinicDto
    {
        [Required(ErrorMessage ="Clinic name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Clinic address is required")]
        public string Address { get; set; }
    }
}
