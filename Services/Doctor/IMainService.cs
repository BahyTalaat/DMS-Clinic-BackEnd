using Core.Common;
using DTO.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Doctor
{
    public interface IMainService
    {
        Task<AjaxResult> GetAllDoctors();
        Task<AjaxResult> GetDoctor(int doctorId);
        Task<AjaxResult> AddDoctor(PostDoctorDto postDoctorDto);
        Task<AjaxResult> GetClinicAllDoctors(int ClinicId);
        Task<AjaxResult> GetDoctorWorkingDays(int DoctorId);
        Task<AjaxResult> GetDoctorWorkingDaySlots(int WorkingDayId);
        Task<AjaxResult> AddAppointment(AddAppointmentDto addAppointmentDto);
        Task<AjaxResult> GetTodayDoctorAppointment(int DoctorId);
        Task<AjaxResult> GetDoctorAppointmentByDates(GetAppointmentRangeDto getAppointmentRangeDto);
        Task<AjaxResult> AddWorkingDay(AddWorkingDayDto addWorkingDayDto);
        Task<AjaxResult> NumberOfPatientPerDoctor();

    }
}
