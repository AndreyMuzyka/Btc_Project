using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using BittrexApi;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DAL.Interfaces;
using DAL.Model;
using DAL.Model.Entity;
using DAL.Repository;
using NLog;
using NLog.Internal;
using ConfigurationManager = System.Configuration.ConfigurationManager;
using Timer = System.Timers.Timer;

namespace BtcService
{
    partial class Gateway : ServiceBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private Timer _timer = null;

        public Gateway()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            logger.Info("OnStart");
            _timer = new Timer();
            _timer.Interval = Convert.ToDouble(ConfigurationManager.AppSettings["timerInterval"]);    
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            _timer.Start();
        }

        protected override void OnStop()
        {
            logger.Info("OnStop");
        }

        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            logger.Info("OnTimer Start...");

            Thread myThread = new Thread(BittrexWorker);
            myThread.Start();

            logger.Info("OnTimer End...");
        }

        public async void BittrexWorker()
        {
            logger.Info("Bittrex Start...");
            try
            {
                BittrexService service = new BittrexService(ContainerManager.Container.Resolve<IRepository<Bittrex>>());
                await service.Worker();
            }
            catch (Exception e)
            {
                logger.Error(e.Message + "\n" + e.InnerException?.Message);
            }
            logger.Info("Bittrex End...");
        }
    }
}
