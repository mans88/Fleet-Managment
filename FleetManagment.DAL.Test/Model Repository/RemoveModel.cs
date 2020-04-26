using Fleet_Managment_DAL.Entities;
using Fleet_Managment_DAL.Interfaces;
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

namespace FleetManagment.DAL.Test.Model_Repository
{
    [TestClass]
    public class RemoveModel
    {
        [TestMethod]
        public void DeleteModel_With_ModelTO_Parameter()
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

            var addedModel = modelRepository.Insert(model);
            var addedModel2 = modelRepository.Insert(model2);
            context.SaveChanges();

            //List<ModelTO> models = new List<ModelTO>();
            var models = modelRepository.GetAll().ToList();

            //ACT
            modelRepository.Remove(addedModel);
            context.SaveChanges();
            models = modelRepository.GetAll().ToList();

            //ASSERT
            Assert.IsNotNull(addedModel);
            Assert.IsNotNull(addedModel2);
            Assert.AreNotEqual(0, addedModel.Id);
            Assert.AreNotEqual(0, addedModel2.Id);
            Assert.AreEqual("polo", addedModel.Name);
            Assert.AreEqual("golf", addedModel2.Name);
            Assert.AreEqual(1, models.Count);
        }

        [TestMethod]
        public void DeleteModel_With_Model_ID_As_Parameter()
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

            var addedModel = modelRepository.Insert(model);
            var addedModel2 = modelRepository.Insert(model2);
            context.SaveChanges();

            //ACT
            modelRepository.RemoveById(1);
            context.SaveChanges();
            var models = modelRepository.GetAll().ToList();

            //ASSERT
            Assert.IsNotNull(addedModel);
            Assert.IsNotNull(addedModel2);
            Assert.AreNotEqual(0, addedModel.Id);
            Assert.AreNotEqual(0, addedModel2.Id);
            Assert.AreEqual("polo", addedModel.Name);
            Assert.AreEqual("golf", addedModel2.Name);
            Assert.AreEqual(1, models.Count);
        }
    }
}