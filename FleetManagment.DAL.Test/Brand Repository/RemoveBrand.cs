using Fleet_Managment_DAL.Entities;
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

namespace FleetManagment.DAL.Test.Brand_Repository
{
    [TestClass]
    public class RemoveBrand
    {
        [TestMethod]
        public void DeleteBrand_With_BrandTO_Parameter()
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

            var addedBrand = brandRepository.Insert(brand);
            var addedBrand2 = brandRepository.Insert(brand2);
            context.SaveChanges();

            //List<BrandTO> brands = new List<BrandTO>();
            var brands = (List<BrandTO>)brandRepository.GetAll();

            //ACT
            brandRepository.Remove(addedBrand);
            context.SaveChanges();
            brands = brandRepository.GetAll().ToList();

            //ASSERT
            Assert.IsNotNull(addedBrand);
            Assert.IsNotNull(addedBrand2);
            Assert.AreNotEqual(0, addedBrand.Id);
            Assert.AreNotEqual(0, addedBrand2.Id);
            Assert.AreEqual("VW", addedBrand.Name);
            Assert.AreEqual("Audi", addedBrand2.Name);
            Assert.AreEqual(1, brands.Count);
        }

        [TestMethod]
        public void DeleteBrand_With_Brand_ID_As_Parameter()
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

            var addedBrand = brandRepository.Insert(brand);
            var addedBrand2 = brandRepository.Insert(brand2);
            context.SaveChanges();

            //ACT
            brandRepository.RemoveById(1);
            context.SaveChanges();
            var brands = brandRepository.GetAll().ToList();

            //ASSERT
            Assert.IsNotNull(addedBrand);
            Assert.IsNotNull(addedBrand2);
            Assert.AreNotEqual(0, addedBrand.Id);
            Assert.AreNotEqual(0, addedBrand2.Id);
            Assert.AreEqual("VW", addedBrand.Name);
            Assert.AreEqual("Audi", addedBrand2.Name);
            Assert.AreEqual(1, brands.Count);
        }
    }
}