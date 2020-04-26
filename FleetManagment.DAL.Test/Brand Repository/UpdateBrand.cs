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

namespace FleetManagment.DAL.Test.Brand_Repository
{
    [TestClass]
    public class UpdateBrand
    {
        [TestMethod]
        public void UpdapteBrand_With_Correct_Parameter()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FleetManagmentContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FleetManagmentContext(options);

            IBrandRepository brandRepository = new BrandRepository(context);

            BrandTO brand = new BrandTO { Name = "VW" };

            //ACT
            var addedBrand = brandRepository.Insert(brand);
            context.SaveChanges();

            addedBrand.Name = "Ferrari";
            brandRepository.Update(addedBrand);
            context.SaveChanges();

            //ASSERT
            Assert.IsNotNull(addedBrand);
            Assert.AreNotEqual(0, addedBrand.Id);
            Assert.AreEqual("Ferrari", addedBrand.Name);
        }
    }
}