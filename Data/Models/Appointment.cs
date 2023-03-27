using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("Appointment")]
    public class Appointment
    {
        public int Id { get; set; }
        public string? PatientName { get; set; }
        public string? PatientAddress { get; set; }
        public int PatientAge { get; set; }
        public DateTime PatientBirthDate { get; set; }
        public DateTime date { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [ForeignKey("Clinic")]
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }

        //[ForeignKey("DaySlots")]
        public int DaySlotId { get; set; }
        //public DaySlots DaySlots { get; set; }


    }
}
