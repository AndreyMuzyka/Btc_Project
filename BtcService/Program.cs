using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DAL.Interfaces;
using DAL.Model;
using DAL.Model.Dto;
using DAL.Model.Entity;
using DAL.Repository;

namespace BtcService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            InitializeAutomapper();
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Gateway()
            };
            ServiceBase.Run(ServicesToRun);
        }

        static void InitializeAutomapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Result, Bittrex>()
                    .ForMember(d => d.Created, opt => opt.MapFrom(src => DateTime.Now));

                cfg.CreateMap<Rootobject, Bittrex>();
            });
        }
    }
}
