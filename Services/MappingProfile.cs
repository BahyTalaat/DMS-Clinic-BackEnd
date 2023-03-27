using AutoMapper;
using Data.Models;
using DTO.Clinic;
using DTO.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Clinic, PostClinicDto>().ReverseMap();
            CreateMap<Clinic, GetClinicDto>().ReverseMap();
            CreateMap<Doctor, PostDoctorDto>().ReverseMap();
            CreateMap<Doctor, GetDoctorDto>().ReverseMap();
            CreateMap<WorkingDay, GetWorkingDayDto>().ReverseMap();
            CreateMap<DaySlots, GetSlotsDto>().ReverseMap();
            CreateMap<Appointment, AddAppointmentDto>().ReverseMap();
            CreateMap<Appointment, GetAppointmentDto>().ReverseMap();
            CreateMap<WorkingDay, AddWorkingDayDto>().ReverseMap();

            
        }
    }           
}
