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

namespace FleetManagment.DAL.Test.Insurance_Repository
{
    [TestClass]
    public class RemoveInsurance
    {
        [TestMethod]
        public void DeleteInsurance_With_InsuranceTO_Parameter()
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

            var addedInsurance = insuranceRepository.Insert(insurance);
            var addedInsurance2 = insuranceRepository.Insert(insurance2);
            context.SaveChanges();

            //List<InsuranceTO> insurances = new List<InsuranceTO>();
            var insurances = insuranceRepository.GetAll().ToList();

            //ACT
            insuranceRepository.Remove(addedInsurance);
            context.SaveChanges();
            insurances = insuranceRepository.GetAll().ToList();

            //ASSERT
            Assert.IsNotNull(addedInsurance);
            Assert.IsNotNull(addedInsurance2);
            Assert.AreNotEqual(0, addedInsurance.Id);
            Assert.AreNotEqual(0, addedInsurance2.Id);
            Assert.AreEqual("AG", addedInsurance.Name);
            Assert.AreEqual("Ethias", addedInsurance2.Name);
            Assert.AreEqual(1, insurances.Count);
        }

        [TestMethod]
        public void DeleteInsurance_With_Insurance_ID_As_Parameter()
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

            var addedInsurance = insuranceRepository.Insert(insurance);
            var addedInsurance2 = insuranceRepository.Insert(insurance2);
            context.SaveChanges();

            //ACT
            insuranceRepository.RemoveById(1);
            context.SaveChanges();
            var insurances = insuranceRepository.GetAll().ToList();

            //ASSERT
            Assert.IsNotNull(addedInsurance);
            Assert.IsNotNull(addedInsurance2);
            Assert.AreNotEqual(0, addedInsurance.Id);
            Assert.AreNotEqual(0, addedInsurance2.Id);
            Assert.AreEqual("AG", addedInsurance.Name);
            Assert.AreEqual("Ethias", addedInsurance2.Name);
            Assert.AreEqual(1, insurances.Count);
        }
    }
}