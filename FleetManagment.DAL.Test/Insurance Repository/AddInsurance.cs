using Fleet_Managment_DAL.Entities;
using Fleet_Managment_DAL.Repositories;
using FleetManagment.Shared;
using FleetManagment.Shared.TransfertObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FleetManagment.DAL.Test.Insurance_Repository
{
    [TestClass]
    public class AddInsurance
    {
        [TestMethod]
        public void AddInsuranceWith_Correct_Parameter()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FleetManagmentContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FleetManagmentContext(options);

            IInsuranceRepository insuranceRepository = new InsuranceRepository(context);

            InsuranceTO insurance = new InsuranceTO
            {
                Name = "AG",
            };

            InsuranceTO insurance2 = new InsuranceTO
            {
                Name = "Ethias",
            };

            //ACT

            var addedInsurance = insuranceRepository.Insert(insurance);
            var addedInsurance2 = insuranceRepository.Insert(insurance2);
            context.SaveChanges();

            //ASSERT
            Assert.IsNotNull(addedInsurance);
            Assert.AreNotEqual(0, addedInsurance.Id);
            Assert.AreEqual("AG", addedInsurance.Name);
        }

        [TestMethod]
        public void AddInsurancerance_Throws_Exception_WhenNullIsProvided()
        {
            var options = new DbContextOptionsBuilder<FleetManagmentContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FleetManagmentContext(options);

            IInsuranceRepository insuranceRepository = new InsuranceRepository(context);

            //ACT
            //ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => insuranceRepository.Insert(null));
        }
    }
}