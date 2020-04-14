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
    public class AddInsuranceTests
    {
        [TestMethod]
        public void Add_InsuranceTO_Return_NotNull()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FleetManagmentContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FleetManagmentContext(options);

            IInsuranceRepository insuranceRepository = new InsuranceRepository(context);
            ICarRepository carRepository = new CarRepository(context);
            IBrandRepository brandRepository = new BrandRepository(context);
            IModelRepository modelRepository = new ModelRepository(context);
            ITechnicalControlRepository technicalControlRepository = new TechnicalControlRepository(context);
            IFuelRepository fuelRepository = new FuelRepository(context);

            //ACT
            var resultBrand = brandRepository.Insert(Tools.InitBrand());
            var resultCar = carRepository.Insert(Tools.InitCar());
            var resultInsu = insuranceRepository.Insert(Tools.InitInsurance());
            var resultModel = modelRepository.Insert(Tools.InitModel());
            var resultTech = technicalControlRepository.Insert(Tools.InitTechnical());
            var resultFuel = fuelRepository.Insert(Tools.InitFuel());
            context.SaveChanges();
            //ASSERT
            Assert.IsNotNull(resultInsu);
            Assert.AreEqual(resultInsu.Name, "AG");
        }
    }
}