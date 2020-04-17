using Fleet_Managment_DAL.Entities;
using Fleet_Managment_DAL.Repositories;
using FleetManagment.Shared;
using FleetManagment.Shared.TransfertObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FleetManagment.DAL.Test.Model_Repository
{
    [TestClass]
    public class GetModel
    {
        [TestMethod]
        public void GetModel_ById()
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
            Assert.AreEqual(1, modelRepository.GetByID(1).Id);
        }

        [TestMethod]
        public void Get_All_Model()
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

            ModelTO model2 = new ModelTO
            {
                Name = "golf",
            };

            List<ModelTO> models = new List<ModelTO>();

            //ACT
            var addedModel = modelRepository.Insert(model);
            var addedModel2 = modelRepository.Insert(model2);
            context.SaveChanges();

            models = modelRepository.GetAll().ToList();

            //ASSERT
            Assert.IsNotNull(addedModel);
            Assert.AreNotEqual(0, addedModel.Id);
            Assert.AreEqual("polo", addedModel.Name);
            Assert.AreEqual(2, models.Count);
        }
    }
}