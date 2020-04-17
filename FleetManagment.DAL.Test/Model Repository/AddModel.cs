using Fleet_Managment_DAL.Entities;
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

namespace FleetManagment.DAL.Test.Model_Repository
{
    [TestClass]
    public class AddModel
    {
        [TestMethod]
        public void AddModel_With_Correct_Parameter()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FleetManagmentContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FleetManagmentContext(options);

            IModelRepository modelRepository = new ModelRepository(context);
            ModelTO model = new ModelTO
            {
                Name = "polo",
            };

            ModelTO model2 = new ModelTO
            {
                Name = "golf",
            };

            //ACT
            var addedModel = modelRepository.Insert(model);
            var addedModel2 = modelRepository.Insert(model2);
            context.SaveChanges();
            //ASSERT
            Assert.IsNotNull(addedModel);
            Assert.AreNotEqual(0, addedModel.Id);
            Assert.AreEqual("polo", addedModel.Name);
        }

        [TestMethod]
        public void AddModel_ThrowsException_WhenNullIsProvided()
        {
            var options = new DbContextOptionsBuilder<FleetManagmentContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FleetManagmentContext(options);

            IModelRepository modelRepository = new ModelRepository(context);
            ModelTO model = new ModelTO
            {
                Name = "polo",
            };

            //ACT
            var addedModel = modelRepository.Insert(model);
            context.SaveChanges();
            //ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => modelRepository.Insert(null));
        }
    }
}