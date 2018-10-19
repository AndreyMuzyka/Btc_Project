using System;
using System.Data.Entity;
using System.Threading.Tasks;
using BittrexApi;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DAL.Interfaces;
using DAL.Model;
using DAL.Model.Entity;
using DAL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BittexApi.Tests
{
    [TestClass]
    public class BittrexServiceTest
    {
        [TestMethod]
        public void Shoul_Save_DataBase_Data_From_Api()
        {
            var _container = new WindsorContainer();
            _container = new WindsorContainer();
            _container.AddFacility<TypedFactoryFacility>();
            _container.Register(Component.For(typeof(DbContext)).ImplementedBy(typeof(DbEntities)));
            _container.Register(Component.For<IDbContextFactory>().AsFactory());
            _container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(BaseRepository<>)));

            var service = new BittrexService(_container.Kernel.Resolve<IRepository<Bittrex>>());
            service.Worker();
        }
    }
}
