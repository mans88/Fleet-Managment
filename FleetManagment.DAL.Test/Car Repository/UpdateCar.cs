using Fleet_Managment_DAL.Entities;
using Fleet_Managment_DAL.Interfaces;
using Fleet_Managment_DAL.Repositories;
using FleetManagment.Shared;
using FleetManagment.Shared.TransfertObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FleetManagment.DAL.Test.Car_Repository
{
    [TestClass]
    public class UpdateCar
    {
        [TestMethod]
        public void UpdapteCar_With_Correct_Parameter()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FleetManagmentContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FleetManagmentContext(options);

            ICarRepository carRepository = new CarRepository(context);

            CarTO car = new CarTO { Numberplate = "1-HRV-803" };

            //ACT
            var addedCar = carRepository.Insert(car);
            context.SaveChanges();

            addedCar.Numberplate = "Mans";
            carRepository.Update(addedCar);
            context.SaveChanges();

            //ASSERT
            Assert.IsNotNull(addedCar);
            Assert.AreNotEqual(0, addedCar.Id);
            Assert.AreEqual("Mans", addedCar.Numberplate);
        }
    }
}