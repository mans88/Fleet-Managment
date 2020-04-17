using Fleet_Managment_DAL.Entities;
using Fleet_Managment_DAL.Repositories;
using FleetManagment.Shared;
using FleetManagment.Shared.TransfertObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FleetManagment.DAL.Test.TechnicalControl_Repository
{
    [TestClass]
    public class UpdateTechnicalControl
    {
        [TestMethod]
        public void UpdapteTechnicalControl_With_Correct_Parameter()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FleetManagmentContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FleetManagmentContext(options);

            ITechnicalControlRepository technicalControlRepository = new TechnicalControlRepository(context);

            TechnicalControlTO technicalControl = new TechnicalControlTO { Comment = "Nothing" };

            //ACT
            var addedTechnicalControl = technicalControlRepository.Insert(technicalControl);
            context.SaveChanges();

            addedTechnicalControl.Comment = "Refused";
            technicalControlRepository.Update(addedTechnicalControl);
            context.SaveChanges();

            //ASSERT
            Assert.IsNotNull(addedTechnicalControl);
            Assert.AreNotEqual(0, addedTechnicalControl.Id);
            Assert.AreEqual("Refused", addedTechnicalControl.Comment);
        }
    }
}