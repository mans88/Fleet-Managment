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

namespace FleetManagment.DAL.Test.Fuel_Repository
{
    [TestClass]
    public class AddFuel
    {
        [TestMethod]
        public void AddFuel_With_Correct_Parameter()
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
        }

        [TestMethod]
        public void AddFuel_ThrowsException_WhenNullIsProvided()
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

            //ACT
            var addedFuel = fuelRepository.Insert(fuel);
            context.SaveChanges();
            //ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => fuelRepository.Insert(null));
        }
    }
}