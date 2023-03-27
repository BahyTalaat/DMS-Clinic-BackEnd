using AutoMapper;
using Core.Common;
using Data.ApplicationContext;
using Data.Models;
using DTO.Doctor;
using Repository.DMSRepositories.AppointmentRepository;
using Repository.DMSRepositories.ClinicRepository;
using Repository.DMSRepositories.DaySlotRepository;
using Repository.DMSRepositories.DoctorRepository;
using Repository.DMSRepositories.WorkingDayRepository;
using Repository.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Doctor
{
    public class MainService : IMainService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IWorkingDayRepository _workingDayRepository;
        private readonly IDaySlotRepository _daySlotRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IClinicRepository _clinicRepository;
        private readonly IUnitOfWork<AppDBContext> _unitOfWork;
        private readonly IMapper _mapper;

        public MainService(IDoctorRepository doctorRepository,
            IWorkingDayRepository workingDayRepository,
            IDaySlotRepository daySlotRepository,
            IAppointmentRepository appointmentRepository,
            IClinicRepository clinicRepository,
            IUnitOfWork<AppDBContext> unitOfWork, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _workingDayRepository = workingDayRepository;
            _daySlotRepository = daySlotRepository;
            _appointmentRepository = appointmentRepository;
            _clinicRepository = clinicRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AjaxResult> AddAppointment(AddAppointmentDto addAppointmentDto)
        {
            try
            {
                var res = new AjaxResult();
                var appointment = _mapper.Map<Data.Models.Appointment>(addAppointmentDto);
                await _appointmentRepository.AddAsync(appointment);
                _unitOfWork.Save();
                // change status
                var slot = await _daySlotRepository.GetFirstAsync(x => x.Id == addAppointmentDto.DaySlotId);
                slot.Status = 1;
                _daySlotRepository.Update(slot);
                _unitOfWork.Save();

                res.AddParameter("Message", "Appointment added successfully");
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<AjaxResult> AddDoctor(PostDoctorDto postDoctorDto)
        {
            try
            {
                var res = new AjaxResult();
                var doctor = _mapper.Map<Data.Models.Doctor>(postDoctorDto);
                await _doctorRepository.AddAsync(doctor);
                _unitOfWork.Save();
                res.AddParameter("Message", "Doctor Added successfully");
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<AjaxResult> GetAllDoctors()
        {
            try
            {
                var res = new AjaxResult();
                var doctorList = await _doctorRepository.GetAllAsync();
                var doctorListDto = _mapper.Map<List<GetDoctorDto>>(doctorList);
                res.AddParameter("DoctorList", doctorListDto);
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<AjaxResult> GetClinicAllDoctors(int ClinicId)
        {
            try
            {
                var res = new AjaxResult();
                var doctorList = await _doctorRepository.GetAllAsync(d => d.ClinicID == ClinicId);
                var doctorListDto = _mapper.Map<List<GetDoctorDto>>(doctorList);
                res.AddParameter("DoctorList", doctorListDto);
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<AjaxResult> GetDoctor(int doctorId)
        {
            try
            {
                var res = new AjaxResult();
                var doctor = await _doctorRepository.GetFirstAsync(x => x.Id == doctorId);
                if (doctor == null)
                    return "Doctor not exist";

                var doctorDto = _mapper.Map<GetDoctorDto>(doctor);
                res.AddParameter("Doctor", doctorDto);
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public async Task<AjaxResult> GetDoctorWorkingDays(int DoctorId)
        {
            try
            {
                var res = new AjaxResult();
                var date = DateTime.Now;
                var workingDay = await _workingDayRepository.GetAllAsync(x => x.DoctorID == DoctorId && x.Date >= date);
                var workingDayListDto = _mapper.Map<List<GetWorkingDayDto>>(workingDay);
                res.AddParameter("WorkingDayList", workingDayListDto);
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<AjaxResult> GetDoctorWorkingDaySlots(int WorkingDayId)
        {
            try
            {
                var res = new AjaxResult();
                var workingDayslotList = await _daySlotRepository.GetAllAsync(x => x.WorkingDayID == WorkingDayId && x.Status == 0);
                var workingDaySlotListDto = _mapper.Map<List<GetSlotsDto>>(workingDayslotList);
                res.AddParameter("DaySlotsList", workingDaySlotListDto);
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<AjaxResult> GetTodayDoctorAppointment(int DoctorId)
        {
            try
            {
                var res = new AjaxResult();
                var date = DateTime.Now.Date;
                var appointmentlist = await _appointmentRepository.GetAllAsync(x => x.DoctorId == DoctorId && x.date == date);
                var appointmentlistDto = new List<GetAppointmentDto>();
                foreach (var appointment in appointmentlist)
                {
                    var slot = await _daySlotRepository.GetFirstAsync(x => x.Id == appointment.DaySlotId);
                    var appointmentDto = _mapper.Map<GetAppointmentDto>(appointment);
                    appointmentDto.time = slot.Time.TimeOfDay;
                    appointmentlistDto.Add(appointmentDto);
                }
                res.AddParameter("AppointmentList", appointmentlistDto);
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<AjaxResult> GetDoctorAppointmentByDates(GetAppointmentRangeDto getAppointmentRangeDto)
        {
            try
            {
                var res = new AjaxResult();
                var dateFrom = getAppointmentRangeDto.DateFrom.Date;
                var dateTo = getAppointmentRangeDto.DateTo.Date;
                var appointmentlist = await _appointmentRepository.GetAllAsync(x => x.DoctorId == getAppointmentRangeDto.DoctorId && x.date >= dateFrom && x.date <= dateTo);
                var appointmentlistDto = new List<GetAppointmentDto>();
                foreach (var appointment in appointmentlist)
                {
                    var slot = await _daySlotRepository.GetFirstAsync(x => x.Id == appointment.DaySlotId);
                    var appointmentDto = _mapper.Map<GetAppointmentDto>(appointment);
                    appointmentDto.time = slot.Time.TimeOfDay;
                    appointmentlistDto.Add(appointmentDto);
                }
                res.AddParameter("AppointmentList", appointmentlistDto);
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<AjaxResult> AddWorkingDay(AddWorkingDayDto addWorkingDayDto)
        {
            try
            {
                var res = new AjaxResult();
                if (addWorkingDayDto.Date < DateTime.Now)
                    return "Can't add days before today";

                var IsExistDay = _workingDayRepository.Any(x => x.DoctorID == addWorkingDayDto.DoctorID && x.Date == addWorkingDayDto.Date);
                    if (IsExistDay)
                    return "Day already exists";


                WorkingDay workingDay = _mapper.Map<WorkingDay>(addWorkingDayDto);
                workingDay.From = new TimeSpan(addWorkingDayDto.From, 0, 0);
                workingDay.To = new TimeSpan(addWorkingDayDto.To, 0, 0);
                await _workingDayRepository.AddAsync(workingDay);
                await _unitOfWork.SaveAsync();

                // Add Slots
                DateTime s = addWorkingDayDto.Date;
                //TimeSpan ts = new TimeSpan(10, 30, 0);
                TimeSpan ts = new TimeSpan(addWorkingDayDto.From, 0, 0);
                s = s.Date + ts;
                var startTime = s;
                var endTime = startTime.AddHours(Math.Abs(addWorkingDayDto.To - addWorkingDayDto.From));


                List<DaySlots> daySlotsList = new List<DaySlots>();

                while (startTime < endTime)
                {
                    var slot = new DaySlots()
                    {
                        Status = 0,
                        Time = startTime,
                        WorkingDayID = workingDay.Id

                    };
                    daySlotsList.Add(slot);
                    startTime = startTime.AddMinutes(30);
                }
                await _daySlotRepository.AddRangeAsync(daySlotsList);
                await _unitOfWork.SaveAsync();


                res.AddParameter("Message", "Day added successfully");
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<AjaxResult> NumberOfPatientPerDoctor()
        {
            try
            {
                var res = new AjaxResult();

                var _appointmentlist = _appointmentRepository.GetAll().ToList();

               
                var PatientCountPerDoctor=new List<object> ();
                foreach (var _appointment in _appointmentlist.GroupBy(x => x.DoctorId).Select(group => new {DoctorID=group.Key,count=group.Count() }))
                {
                    var doctor = _doctorRepository.GetFirst(x => x.Id == _appointment.DoctorID);
                    PatientCountPerDoctor.Add(new {DoctorID =_appointment.DoctorID , DoctorName=doctor.Name , PatientCount=_appointment.count});
                }

                res.AddParameter("PatientCountPerDoctor", PatientCountPerDoctor);

                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
