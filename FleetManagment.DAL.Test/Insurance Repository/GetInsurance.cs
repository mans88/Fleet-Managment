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

namespace FleetManagment.DAL.Test.Insurance_Repository
{
    [TestClass]
    public class GetInsurance
    {
        [TestMethod]
        public void GetBrand_ById()
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
            var addedinsurance = insuranceRepository.Insert(insurance);
            var addedinsurance2 = insuranceRepository.Insert(insurance2);
            context.SaveChanges();

            //ASSERT
            Assert.IsNotNull(addedinsurance);
            Assert.AreNotEqual(0, addedinsurance.Id);
            Assert.AreEqual("AG", addedinsurance.Name);
            Assert.AreEqual(1, insuranceRepository.GetByID(1).Id);
        }

        [TestMethod]
        public void Get_All_Insurance()
        {
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

            List<InsuranceTO> insurances = new List<InsuranceTO>();

            //ACT
            var addedInsurance = insuranceRepository.Insert(insurance);
            var addedInsurance2 = insuranceRepository.Insert(insurance2);
            context.SaveChanges();

            insurances = insuranceRepository.GetAll().ToList();

            //ASSERT
            Assert.IsNotNull(addedInsurance);
            Assert.AreNotEqual(0, addedInsurance.Id);
            Assert.AreEqual("AG", addedInsurance.Name);
            Assert.AreEqual(2, insurances.Count);
        }
    }
}