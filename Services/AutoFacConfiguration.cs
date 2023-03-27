using Autofac;
using Repository.DMSRepositories.AppointmentRepository;
using Repository.DMSRepositories.ClinicRepository;
using Repository.DMSRepositories.DaySlotRepository;
using Repository.DMSRepositories.DoctorRepository;
using Repository.DMSRepositories.WorkingDayRepository;
using Repository.UOW;
using Service.clinic;
using Services.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AutoFacConfiguration : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            #region UOW
            //Register Unit of work service
            builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>));
            #endregion

            #region Repositories

            #region ClinicRepository
            builder.RegisterType<ClinicRepository>().As<IClinicRepository>();
            #endregion
            #region AppointmentRepository
            builder.RegisterType<AppointmentRepository>().As<IAppointmentRepository>();
            #endregion

            #region DaySlotRepository
            builder.RegisterType<DaySlotRepository>().As<IDaySlotRepository>();
            #endregion

            #region DoctorRepository
            builder.RegisterType<DoctorRepository>().As<IDoctorRepository>();
            #endregion

            #region WorkingDayRepository
            builder.RegisterType<WorkingDayRepository>().As<IWorkingDayRepository>();
            #endregion



            #endregion

            #region Services

            #region ClinicService
            builder.RegisterType<ClinicService>().As<IClinicService>();
            #endregion

            #region DoctorService
            builder.RegisterType<MainService>().As<IMainService>();
            #endregion


            #endregion

            // builder.RegisterType<SharedAPI>().As<SharedAPI>();



        }
    }
}
