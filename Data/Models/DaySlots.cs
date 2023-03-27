using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("DaySlots")]
    public class DaySlots
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int Status { get; set; }

        //[ForeignKey("doctorWorkingDayID")]
        //public DoctorWorkingDays doctorWorking { get; set; }
        //public int doctorWorkingDayID { get; set; }

        //[ForeignKey("AppointmentID")]
        //public Appointment Appointment { get; set; }
        //public int AppointmentID { get; set; }

        [ForeignKey("WorkingDayID")]
        public WorkingDay WorkingDay { get; set; }
        public int WorkingDayID { get; set; }

        //[ForeignKey("Appointment")]
        //public int AppointmentID { get; set; }
        //public Appointment Appointment { get; set; }

    }
}
