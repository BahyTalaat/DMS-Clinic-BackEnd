using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Doctor
{
    public class AddWorkingDayDto
    {
        [Required(ErrorMessage ="Day is required")]
        public string Day { get; set; }
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "From time is required")]
        public int From { get; set; }
        [Required(ErrorMessage = "To time is required")]
        public int To { get; set; }
        [Required(ErrorMessage = "Doctor is required")]

        public int DoctorID { get; set; }

    }
}
