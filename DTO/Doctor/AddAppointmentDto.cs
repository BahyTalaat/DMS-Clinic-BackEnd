using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Doctor
{
    public class AddAppointmentDto
    {
        public string? PatientName { get; set; }
        public string? PatientAddress { get; set; }
        public int PatientAge { get; set; }
        public DateTime PatientBirthDate { get; set; }
        public DateTime date { get; set; }
        public int DoctorId { get; set; }
        public int ClinicId { get; set; }
        public int DaySlotId { get; set; }
    }
}
