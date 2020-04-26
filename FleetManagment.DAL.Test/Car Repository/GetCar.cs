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
    public class GetCar
    {
        [TestMethod]
        public void GetCar_ById()
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
            Assert.AreEqual(1, carRepository.GetByID(1).Id);
        }

        [TestMethod]
        public void Get_All_Car()
        {
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

            List<CarTO> cars = new List<CarTO>();

            //ACT
            var addedCar = carRepository.Insert(car);
            var addedCar2 = carRepository.Insert(car2);
            context.SaveChanges();

            cars = carRepository.GetAll().ToList();

            //ASSERT
            Assert.IsNotNull(addedCar);
            Assert.AreNotEqual(0, addedCar.Id);
            Assert.AreEqual("1-NVR-803", addedCar.Numberplate);
            Assert.AreEqual(2, cars.Count);
        }
    }
}