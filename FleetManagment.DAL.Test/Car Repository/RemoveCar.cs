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

namespace FleetManagment.DAL.Test.Car_Repository
{
    [TestClass]
    public class RemoveCar
    {
        [TestMethod]
        public void DeleteCar_With_CarTO_Parameter()
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

            var addedCar = carRepository.Insert(car);
            var addedCar2 = carRepository.Insert(car2);
            context.SaveChanges();

            //List<CarTO> cars = new List<CarTO>();
            var cars = carRepository.GetAll().ToList();

            //ACT
            carRepository.Remove(addedCar);
            context.SaveChanges();
            cars = carRepository.GetAll().ToList();

            //ASSERT
            Assert.IsNotNull(addedCar);
            Assert.IsNotNull(addedCar2);
            Assert.AreNotEqual(0, addedCar.Id);
            Assert.AreNotEqual(0, addedCar2.Id);
            Assert.AreEqual("1-NVR-803", addedCar.Numberplate);
            Assert.AreEqual("1-DQE-297", addedCar2.Numberplate);
            Assert.AreEqual(1, cars.Count);
        }

        [TestMethod]
        public void DeleteCar_With_Car_ID_As_Parameter()
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
            var addedCar = carRepository.Insert(car);
            var addedCar2 = carRepository.Insert(car2);
            context.SaveChanges();

            //ACT
            carRepository.RemoveById(1);
            context.SaveChanges();
            var cars = carRepository.GetAll().ToList();

            //ASSERT
            Assert.IsNotNull(addedCar);
            Assert.IsNotNull(addedCar2);
            Assert.AreNotEqual(0, addedCar.Id);
            Assert.AreNotEqual(0, addedCar2.Id);
            Assert.AreEqual("1-NVR-803", addedCar.Numberplate);
            Assert.AreEqual("1-DQE-297", addedCar2.Numberplate);
            Assert.AreEqual(1, cars.Count);
        }
    }
}