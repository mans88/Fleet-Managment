using Fleet_Managment_BLL.Domain;
using Fleet_Managment_BLL.Interfaces;
using Fleet_Managment_BLL.Services;
using Fleet_Managment_DAL.Interfaces;
using FleetManagment.Shared.TransfertObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace FleetManagment.BLL.Test.Brand_Tests
{
    [TestClass]
    public class AddBrandServiceTests
    {
        [TestMethod]
        public void NullUnitOfWork_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new BrandService(null));
        }

        [TestMethod]
        public void Add_ValidBrand__ReturnsBrand_NotNull()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            //var mockBrandService = new Mock<IBrandService>();

            mockUnitOfWork.Setup(u => u.BrandRepository.Insert(It.IsAny<BrandTO>())).Returns(new BrandTO { Id = 1, Name = "VW" });

            var brandSrv = new BrandService(mockUnitOfWork.Object);

            //ACT
            var addedBrand = brandSrv.Insert(new Brand { Name = "VW" });

            //ASSERT
            Assert.IsNotNull(addedBrand);
            Assert.AreEqual("VW", addedBrand.Name);
            Assert.AreEqual(1, addedBrand.Id);
            mockUnitOfWork.Verify(x => x.BrandRepository.Insert(It.IsAny<BrandTO>()), Times.Once);
        }
    }
}