using Fleet_Managment_DAL.Entities;
using Fleet_Managment_DAL.Repositories;
using FleetManagment.Shared;
using FleetManagment.Shared.TransfertObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FleetManagment.DAL.Test.TechnicalControl_Repository
{
    [TestClass]
    public class RemoveTechnicalControl
    {
        [TestMethod]
        public void DeleteTechnicalControl_With_TechnicalControlTO_Parameter()
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

            var addedTechnicalControl = technicalControlRepository.Insert(technicalControl);
            var addedTechnicalControl2 = technicalControlRepository.Insert(technicalControl2);
            context.SaveChanges();

            //List<TechnicalControlTO> technicalControls = new List<TechnicalControlTO>();
            var technicalControls = technicalControlRepository.GetAll().ToList();

            //ACT
            technicalControlRepository.Remove(addedTechnicalControl);
            context.SaveChanges();
            technicalControls = technicalControlRepository.GetAll().ToList();

            //ASSERT
            Assert.IsNotNull(addedTechnicalControl);
            Assert.IsNotNull(addedTechnicalControl2);
            Assert.AreNotEqual(0, addedTechnicalControl.Id);
            Assert.AreNotEqual(0, addedTechnicalControl2.Id);
            Assert.AreEqual("nothing", addedTechnicalControl.Comment);
            Assert.AreEqual("change tyre", addedTechnicalControl2.Comment);
            Assert.AreEqual(1, technicalControls.Count);
        }

        [TestMethod]
        public void DeleteTechnicalControl_With_TechnicalControl_ID_As_Parameter()
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
            var addedTechnicalControl = technicalControlRepository.Insert(technicalControl);
            var addedTechnicalControl2 = technicalControlRepository.Insert(technicalControl2);
            context.SaveChanges();

            //ACT
            technicalControlRepository.RemoveById(1);
            context.SaveChanges();
            var technicalControls = technicalControlRepository.GetAll().ToList();

            //ASSERT
            Assert.IsNotNull(addedTechnicalControl);
            Assert.IsNotNull(addedTechnicalControl2);
            Assert.AreNotEqual(0, addedTechnicalControl.Id);
            Assert.AreNotEqual(0, addedTechnicalControl2.Id);
            Assert.AreEqual("nothing", addedTechnicalControl.Comment);
            Assert.AreEqual("change tyre", addedTechnicalControl2.Comment);
            Assert.AreEqual(1, technicalControls.Count);
        }
    }
}