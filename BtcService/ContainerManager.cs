using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DAL.Interfaces;
using DAL.Model;
using DAL.Repository;

namespace BtcService
{
    public class ContainerManager
    {
        private static readonly object SyncRoot = new object();
        private static IWindsorContainer _container = null;
        public static IWindsorContainer Container
        {
            get
            {
                if (_container == null)
                {
                    lock (SyncRoot)
                    {
                        if (_container == null)
                        {
                            _container = new WindsorContainer();
                            _container.AddFacility<TypedFactoryFacility>();
                            _container.Register(Component.For(typeof(DbContext)).ImplementedBy(typeof(DbEntities)));
                            _container.Register(Component.For<IDbContextFactory>().AsFactory());
                            _container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(BaseRepository<>)));
                        }
                    }
                }
                return _container;
            }
        }
    }
}
