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

namespace FleetManagment.DAL.Test.Model_Repository
{
    [TestClass]
    public class UpdateModel
    {
        [TestMethod]
        public void UpdapteModel_With_Correct_Parameter()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FleetManagmentContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FleetManagmentContext(options);

            IModelRepository modelRepository = new ModelRepository(context);

            ModelTO model = new ModelTO { Name = "polo" };

            //ACT
            var addedModel = modelRepository.Insert(model);
            context.SaveChanges();

            addedModel.Name = "golf";
            modelRepository.Update(addedModel);
            context.SaveChanges();

            //ASSERT
            Assert.IsNotNull(addedModel);
            Assert.AreNotEqual(0, addedModel.Id);
            Assert.AreEqual("golf", addedModel.Name);
        }
    }
}