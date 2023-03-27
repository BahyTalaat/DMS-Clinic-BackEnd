using DTO.Clinic;
using Core.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.clinic;

namespace DMS_Clinic_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicService _clinicService;

        public ClinicController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        [HttpPost]
        [Route("AddClinic")]
        public Task<AjaxResult> AddClinic(PostClinicDto postClinicDto)
        {
            var res=_clinicService.AddClinic(postClinicDto);
            return res;
        }
        [HttpGet]
        [Route("GetAll")]
        public Task<AjaxResult> GetAllClinic()
        {
            var res = _clinicService.getAll();
            return res;
        }

    }
}
