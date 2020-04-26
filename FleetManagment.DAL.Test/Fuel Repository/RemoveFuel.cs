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
    public class RemoveFuel
    {
        [TestMethod]
        public void DeleteFuel_With_FuelTO_Parameter()
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
            var addedFuel = fuelRepository.Insert(fuel);
            var addedFuel2 = fuelRepository.Insert(fuel2);
            context.SaveChanges();

            //List<FuelTO> fuels = new List<FuelTO>();
            var fuels = fuelRepository.GetAll().ToList();

            //ACT
            fuelRepository.Remove(addedFuel);
            context.SaveChanges();
            fuels = fuelRepository.GetAll().ToList();

            //ASSERT
            Assert.IsNotNull(addedFuel);
            Assert.IsNotNull(addedFuel2);
            Assert.AreNotEqual(0, addedFuel.Id);
            Assert.AreNotEqual(0, addedFuel2.Id);
            Assert.AreEqual("diesel", addedFuel.Name);
            Assert.AreEqual("essence", addedFuel2.Name);
            Assert.AreEqual(1, fuels.Count);
        }

        [TestMethod]
        public void DeleteFuel_With_Fuel_ID_As_Parameter()
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
            var addedFuel = fuelRepository.Insert(fuel);
            var addedFuel2 = fuelRepository.Insert(fuel2);
            context.SaveChanges();

            //ACT
            fuelRepository.RemoveById(1);
            context.SaveChanges();
            var fuels = fuelRepository.GetAll().ToList();

            //ASSERT
            Assert.IsNotNull(addedFuel);
            Assert.IsNotNull(addedFuel2);
            Assert.AreNotEqual(0, addedFuel.Id);
            Assert.AreNotEqual(0, addedFuel2.Id);
            Assert.AreEqual("diesel", addedFuel.Name);
            Assert.AreEqual("essence", addedFuel2.Name);
            Assert.AreEqual(1, fuels.Count);
        }
    }
}