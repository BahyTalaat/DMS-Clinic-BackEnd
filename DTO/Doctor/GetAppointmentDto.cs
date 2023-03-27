using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Doctor
{
    public class GetAppointmentDto
    {
        public int Id { get; set; }
        public string? PatientName { get; set; }
        public string? PatientAddress { get; set; }
        public string? PatientAge { get; set; }
        public DateTime PatientBirthDate { get; set; }
        public DateTime date { get; set; }
        public TimeSpan time { get; set; }
    }
}
