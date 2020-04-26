using Fleet_Managment_DAL.Entities;
using Fleet_Managment_DAL.Interfaces;
using Fleet_Managment_DAL.Repositories;
using FleetManagment.Shared;
using FleetManagment.Shared.TransfertObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FleetManagment.DAL.Test.TechnicalControl_Repository
{
    [TestClass]
    public class GetTechnicalControl
    {
        [TestMethod]
        public void GetTechnicalControl_ById()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FleetManagmentContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FleetManagmentContext(options);

            ITechnicalControlRepository technicalControlRepository = new TechnicalControlRepository(context);
            TechnicalControlTO technicalControl = new TechnicalControlTO
            {
                Comment = "nothing",
            };

            TechnicalControlTO technicalControl2 = new TechnicalControlTO
            {
                Comment = "change tyre",
            };

            //ACT
            var addedTechnicalControl = technicalControlRepository.Insert(technicalControl);
            var addedTechnicalControl2 = technicalControlRepository.Insert(technicalControl2);
            context.SaveChanges();

            //ASSERT
            Assert.IsNotNull(addedTechnicalControl);
            Assert.AreNotEqual(0, addedTechnicalControl.Id);
            Assert.AreEqual("nothing", addedTechnicalControl.Comment);
            Assert.AreEqual(1, technicalControlRepository.GetByID(1).Id);
        }

        [TestMethod]
        public void Get_All_TechnicalControl()
        {
            var options = new DbContextOptionsBuilder<FleetManagmentContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FleetManagmentContext(options);

            ITechnicalControlRepository technicalControlRepository = new TechnicalControlRepository(context);

            TechnicalControlTO technicalControl = new TechnicalControlTO
            {
                Comment = "nothing",
            };

            TechnicalControlTO technicalControl2 = new TechnicalControlTO
            {
                Comment = "change tyre",
            };

            List<TechnicalControlTO> technicalControls = new List<TechnicalControlTO>();

            //ACT
            var addedTechnicalControl = technicalControlRepository.Insert(technicalControl);
            var addedTechnicalControl2 = technicalControlRepository.Insert(technicalControl2);
            context.SaveChanges();

            technicalControls = technicalControlRepository.GetAll().ToList();

            //ASSERT
            Assert.IsNotNull(addedTechnicalControl);
            Assert.AreNotEqual(0, addedTechnicalControl.Id);
            Assert.AreEqual("nothing", addedTechnicalControl.Comment);
            Assert.AreEqual(2, technicalControls.Count);
        }
    }
}