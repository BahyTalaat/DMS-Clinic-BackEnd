
using DTO.Clinic;
using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.clinic
{
    public interface IClinicService
    {
        Task<AjaxResult> AddClinic(PostClinicDto postClinicDto);
        Task<AjaxResult> UpdateClinic(PostClinicDto postClinicDto);
        Task<AjaxResult> getAll();
        Task<AjaxResult> getClinic(int ID);
        Task<AjaxResult> Delete(int ID);
    }
}
