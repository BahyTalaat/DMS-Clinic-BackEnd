using AutoMapper;
using Data.ApplicationContext;
using Data.Models;
using DTO.Clinic;
using Core.Common;
using Microsoft.EntityFrameworkCore;
using Repository.DMSRepositories.ClinicRepository;
using Repository.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.clinic
{
    public class ClinicService: IClinicService
    {
        private readonly IClinicRepository _clinicRepository;
        private readonly IUnitOfWork<AppDBContext> _unitOfWork;
        private readonly IMapper _mapper;

        public ClinicService(IClinicRepository clinicRepository,
              IUnitOfWork<AppDBContext> unitOfWork,
              IMapper mapper)
        {
            _clinicRepository = clinicRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AjaxResult> AddClinic(PostClinicDto postClinicDto)
        {
            try
            {
                var res = new AjaxResult();
                var clinic = _mapper.Map<Clinic>(postClinicDto);
                await _clinicRepository.AddAsync(clinic);
                await _unitOfWork.SaveAsync();
                res.AddParameter("Message", "Clinic was added successfully");
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<AjaxResult> Delete(int ID)
        {
            try
            {
                var res = new AjaxResult();
                var clinic=_clinicRepository.GetFirst(c=>c.Id == ID);
                if (clinic == null)
                    return "Clinic not exist";
                _clinicRepository.Remove(clinic);
                await _unitOfWork.SaveAsync();
                res.AddParameter("Message", "Clinic deleted successfully");
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<AjaxResult> getAll()
        {
            try
            {
                var res = new AjaxResult();
                var clinicLst = _clinicRepository.GetAll();
                var ClinicLstDto = _mapper.Map<List<GetClinicDto>>(clinicLst);
                res.AddParameter("ClinicList", ClinicLstDto);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<AjaxResult> getClinic(int ID)
        {
            try
            {
                var res = new AjaxResult();
                var clinic = _clinicRepository.GetFirst(c => c.Id == ID);
                if (clinic == null)
                    return "Clinic not exist";

                var ClinicDto = _mapper.Map<GetClinicDto>(clinic);
               
                res.AddParameter("Clinic", ClinicDto);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<AjaxResult> UpdateClinic(PostClinicDto postClinicDto)
        {
            throw new NotImplementedException();
        }
    }
}
