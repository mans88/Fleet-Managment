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
    public class AddCar
    {
        [TestMethod]
        public void AddCarWith_Correct_Parameter()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FleetManagmentContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FleetManagmentContext(options);

            ICarRepository carRepository = new CarRepository(context);

            CarTO car = new CarTO
            {
                Numberplate = "1-NVR-803",
            };

            CarTO car2 = new CarTO
            {
                Numberplate = "1-DQE-297",
            };

            //ACT

            var addedCar = carRepository.Insert(car);
            var addedCar2 = carRepository.Insert(car2);
            context.SaveChanges();

            //ASSERT
            Assert.IsNotNull(addedCar);
            Assert.AreNotEqual(0, addedCar.Id);
            Assert.AreEqual("1-NVR-803", addedCar.Numberplate);
        }

        [TestMethod]
        public void AddCarrance_Throws_Exception_WhenNullIsProvided()
        {
            var options = new DbContextOptionsBuilder<FleetManagmentContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FleetManagmentContext(options);

            ICarRepository carRepository = new CarRepository(context);

            //ACT
            //ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => carRepository.Insert(null));
        }
    }
}