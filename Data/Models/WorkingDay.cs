using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("WorkingDay")]
    public class WorkingDay
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public DateTime Date { get; set; }  
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; } 
       public virtual ICollection<DaySlots> daySlots { get; set; }
        
        //public ICollection<DoctorWorkingDays> doctorWorkingDays { get; set; }


    }
}
