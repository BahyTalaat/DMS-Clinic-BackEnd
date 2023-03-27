using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Doctor
{
    public class PostDoctorDto
    {
        public string Name { get; set; }
        public string Speciality { get; set; }
        public int ClinicID { get; set; }
    }
}
