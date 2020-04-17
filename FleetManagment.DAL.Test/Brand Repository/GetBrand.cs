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
    public class GetBrand
    {
        [TestMethod]
        public void GetBrand_ById()
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
            Assert.AreEqual(1, brandRepository.GetByID(1).Id);
        }

        [TestMethod]
        public void Get_All_Brand()
        {
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

            List<BrandTO> brands = new List<BrandTO>();

            //ACT
            var addedBrand = brandRepository.Insert(brand);
            var addedBrand2 = brandRepository.Insert(brand2);
            context.SaveChanges();

            brands = brandRepository.GetAll().ToList();

            //ASSERT
            Assert.IsNotNull(addedBrand);
            Assert.AreNotEqual(0, addedBrand.Id);
            Assert.AreEqual("VW", addedBrand.Name);
            Assert.AreEqual(2, brands.Count);
        }
    }
}