using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("Doctor")]

    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }

        [ForeignKey("Clinic")]
        public int ClinicID { get; set; }
        public Clinic Clinic { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }  
        //public ICollection<DoctorWorkingDays> doctorWorkingDays { get; set; }

        public virtual ICollection<WorkingDay> workingDays { get; set; }
    }
}
