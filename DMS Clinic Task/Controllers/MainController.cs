using Core.Common;
using DTO.Doctor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Doctor;

namespace DMS_Clinic_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IMainService _mainService;

        public MainController(IMainService mainService)
        {
            _mainService = mainService;
        }
        [HttpGet]
        [Route("GetAllDoctors")]
        public async Task<AjaxResult> GetAllDoctor()
        {
            var res = await _mainService.GetAllDoctors();
            return res;
        }

        [HttpGet]
        [Route("GetClinicAllDoctors")]
        public async Task<AjaxResult> GetClinicAllDoctors(int ClinicId)
        {
            var res = await _mainService.GetClinicAllDoctors(ClinicId);
            return res;
        }

        [HttpGet]
        [Route("GetDoctorById")]
        public async Task<AjaxResult> GetDoctorById(int DoctorId)
        {
            var res = await _mainService.GetDoctor(DoctorId);
            return res;
        }
        [HttpPost]
        [Route("AddDoctor")]
        public async Task<AjaxResult> AddDoctor([FromBody] PostDoctorDto postDoctorDto)
        {
            var res = await _mainService.AddDoctor(postDoctorDto);
            return res;
        }

        [HttpGet]
        [Route("GetDoctorWorkingDays")]
        public async Task<AjaxResult> GetDoctorWorkingDays(int DoctorId)
        {
            var res = await _mainService.GetDoctorWorkingDays(DoctorId);
            return res;
        }

        [HttpGet]
        [Route("GetDoctorWorkingDaySlots")]
        public async Task<AjaxResult> GetDoctorWorkingDaySlots(int WorkingDayId)
        {
            var res = await _mainService.GetDoctorWorkingDaySlots(WorkingDayId);
            return res;
        }

        [HttpPost]
        [Route("AddAppointment")]
        public async Task<AjaxResult> AddAppointment([FromBody] AddAppointmentDto addAppointmentDto)
        {
            var res = await _mainService.AddAppointment(addAppointmentDto);
            return res;
        }


        [HttpGet]
        [Route("GetTodayDoctorAppointment")]
        public async Task<AjaxResult> GetTodayDoctorAppointment(int DoctorId)
        {
            var res = await _mainService.GetTodayDoctorAppointment(DoctorId);
            return res;
        }

        [HttpPost]
        [Route("GetDoctorAppointmentByDates")]
        public async Task<AjaxResult> GetDoctorAppointmentByDates([FromBody] GetAppointmentRangeDto getAppointmentRangeDto)
        {
            var res = await _mainService.GetDoctorAppointmentByDates(getAppointmentRangeDto);
            return res;
        } 
        [HttpPost]
        [Route("AddWorkingDay")]
        public async Task<AjaxResult> AddWorkingDay([FromBody] AddWorkingDayDto addWorkingDayDto)
        {
            var res = await _mainService.AddWorkingDay(addWorkingDayDto);
            return res;
        }

        [HttpGet]
        [Route("NumberOfPatientPerDoctor")]
        public async Task<AjaxResult> NumberOfPatientPerDoctor()
        {
            var res = await _mainService.NumberOfPatientPerDoctor();
            return res;
        }

        

    }
}
