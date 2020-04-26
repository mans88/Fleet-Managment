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

namespace FleetManagment.DAL.Test.Fuel_Repository
{
    [TestClass]
    public class GetFuel
    {
        [TestMethod]
        public void GetFuel_ById()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FleetManagmentContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FleetManagmentContext(options);

            IFuelRepository fuelRepository = new FuelRepository(context);
            FuelTO fuel = new FuelTO
            {
                Name = "diesel",
            };

            FuelTO fuel2 = new FuelTO
            {
                Name = "essence",
            };

            //ACT
            var addedFuel = fuelRepository.Insert(fuel);
            var addedFuel2 = fuelRepository.Insert(fuel2);
            context.SaveChanges();

            //ASSERT
            Assert.IsNotNull(addedFuel);
            Assert.AreNotEqual(0, addedFuel.Id);
            Assert.AreEqual("diesel", addedFuel.Name);
            Assert.AreEqual(1, fuelRepository.GetByID(1).Id);
        }

        [TestMethod]
        public void Get_All_Fuel()
        {
            var options = new DbContextOptionsBuilder<FleetManagmentContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FleetManagmentContext(options);

            IFuelRepository fuelRepository = new FuelRepository(context);

            FuelTO fuel = new FuelTO
            {
                Name = "diesel",
            };

            FuelTO fuel2 = new FuelTO
            {
                Name = "essence",
            };

            List<FuelTO> fuels = new List<FuelTO>();

            //ACT
            var addedFuel = fuelRepository.Insert(fuel);
            var addedFuel2 = fuelRepository.Insert(fuel2);
            context.SaveChanges();

            fuels = fuelRepository.GetAll().ToList();

            //ASSERT
            Assert.IsNotNull(addedFuel);
            Assert.AreNotEqual(0, addedFuel.Id);
            Assert.AreEqual("diesel", addedFuel.Name);
            Assert.AreEqual(2, fuels.Count);
        }
    }
}