using Fleet_Managment_BLL.Domain;
using Fleet_Managment_BLL.Services;
using Fleet_Managment_DAL.Interfaces;
using FleetManagment.Shared.TransfertObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace FleetManagment.BLL.Test.Model_Tests
{
    [TestClass]
    public class AddModelServiceTests
    {
        [TestMethod]
        public void Add_ValidModel__ReturnsModel_NotNull()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.Setup(x => x.ModelRepository.Insert(It.IsAny<ModelTO>())).Returns(new ModelTO { Id = 1, Name = "diesel" });

            var modelSrv = new ModelService(mockUnitOfWork.Object);
            //ACT
            var added = modelSrv.Insert(new ModelTO { Name = "diesel" });

            //ASSERT
            Assert.IsNotNull(added);
            Assert.AreEqual("diesel", added.Name);
            Assert.AreEqual(1, added.Id);
            mockUnitOfWork.Verify(x => x.ModelRepository.Insert(It.IsAny<ModelTO>()), Times.Once);
        }
    }
}