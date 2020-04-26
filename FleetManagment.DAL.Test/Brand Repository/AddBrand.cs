using Fleet_Managment_DAL.Entities;
using Fleet_Managment_DAL.Interfaces;
using Fleet_Managment_DAL.Repositories;
using FleetManagment.Shared.TransfertObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace FleetManagment.DAL.Test.Brand_Repository
{
    [TestClass]
    public class AddBrand
    {
        [TestMethod]
        public void AddBrand_With_Correct_Parameter()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FleetManagmentContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FleetManagmentContext(options);

            IBrandRepository brandRepository = new BrandRepository(context);
            BrandTO brand = new BrandTO
            {
                Cars = new List<CarTO>(),
                Models = new List<ModelTO>(),
                Name = "VW",
            };

            BrandTO brand2 = new BrandTO
            {
                Cars = new List<CarTO>(),
                Models = new List<ModelTO>(),
                Name = "Audi",
            };

            //ACT
            var addedBrand = brandRepository.Insert(brand);
            var addedBrand2 = brandRepository.Insert(brand2);
            context.SaveChanges();
            //ASSERT
            Assert.IsNotNull(addedBrand);
            Assert.AreNotEqual(0, addedBrand.Id);
            Assert.AreEqual("VW", addedBrand.Name);
        }

        [TestMethod]
        public void AddBrand_ThrowsException_WhenNullIsProvided()
        {
            var options = new DbContextOptionsBuilder<FleetManagmentContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FleetManagmentContext(options);

            IBrandRepository brandRepository = new BrandRepository(context);
            BrandTO brand = new BrandTO
            {
                Id = 1,
                Cars = new List<CarTO>(),
                Models = new List<ModelTO>(),
                Name = "VW",
            };

            //ACT
            var addedBrand = brandRepository.Insert(brand);
            context.SaveChanges();
            //ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => brandRepository.Insert(null));
        }
    }
}