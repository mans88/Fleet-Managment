using Fleet_Managment_DAL.Entities;
using Fleet_Managment_DAL.Interfaces;
using Fleet_Managment_DAL.Repositories;
using FleetManagment.Shared;
using FleetManagment.Shared.TransfertObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FleetManagment.DAL.Test.TechnicalControl_Repository
{
    [TestClass]
    public class AddTechnicalControl
    {
        [TestMethod]
        public void AddTechnicalControl_With_Correct_Parameter()
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
                Comment = "perfect",
            };

            //ACT
            var addedTechnicalControl = technicalControlRepository.Insert(technicalControl);
            var addedTechnicalControl2 = technicalControlRepository.Insert(technicalControl2);
            context.SaveChanges();
            //ASSERT
            Assert.IsNotNull(addedTechnicalControl);
            Assert.AreNotEqual(0, addedTechnicalControl.Id);
            Assert.AreEqual("nothing", addedTechnicalControl.Comment);
        }

        [TestMethod]
        public void AddTechnicalControl_ThrowsException_WhenNullIsProvided()
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

            //ACT
            var addedTechnicalControl = technicalControlRepository.Insert(technicalControl);
            context.SaveChanges();
            //ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => technicalControlRepository.Insert(null));
        }
    }
}