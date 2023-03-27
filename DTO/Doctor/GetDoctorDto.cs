using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Doctor
{
    public class GetDoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
    }
}
