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

namespace FleetManagment.DAL.Test.Fuel_Repository
{
    [TestClass]
    public class UpdateFuel
    {
        [TestMethod]
        public void UpdapteFuel_With_Correct_Parameter()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FleetManagmentContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FleetManagmentContext(options);

            IFuelRepository fuelRepository = new FuelRepository(context);

            FuelTO fuel = new FuelTO { Name = "diesel" };

            //ACT
            var addedFuel = fuelRepository.Insert(fuel);
            context.SaveChanges();

            addedFuel.Name = "essence";
            fuelRepository.Update(addedFuel);
            context.SaveChanges();

            //ASSERT
            Assert.IsNotNull(addedFuel);
            Assert.AreNotEqual(0, addedFuel.Id);
            Assert.AreEqual("essence", addedFuel.Name);
        }
    }
}