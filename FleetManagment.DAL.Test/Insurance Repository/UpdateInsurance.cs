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

namespace FleetManagment.DAL.Test.Insurance_Repository
{
    [TestClass]
    public class UpdateInsurance
    {
        [TestMethod]
        public void UpdapteInsurance_With_Correct_Parameter()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FleetManagmentContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FleetManagmentContext(options);

            IInsuranceRepository insuranceRepository = new InsuranceRepository(context);

            InsuranceTO insurance = new InsuranceTO { Name = "AG" };

            //ACT
            var addedInsurance = insuranceRepository.Insert(insurance);
            context.SaveChanges();

            addedInsurance.Name = "Ethias";
            insuranceRepository.Update(addedInsurance);
            context.SaveChanges();

            //ASSERT
            Assert.IsNotNull(addedInsurance);
            Assert.AreNotEqual(0, addedInsurance.Id);
            Assert.AreEqual("Ethias", addedInsurance.Name);
        }
    }
}