using Fleet_Managment_BLL.Domain;
using Fleet_Managment_BLL.Extension;
using Fleet_Managment_BLL.Interfaces;
using Fleet_Managment_BLL.Services;
using Fleet_Managment_DAL.Interfaces;
using FleetManagment.Shared.TransfertObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace FleetManagment.BLL.Test.TechnicalControl_Tests
{
    [TestClass]
    public class AddTechnicalControlServiceTests
    {
        [TestMethod]
        public void AddTechnicalControl_NullTechnicalControlService_Submitted_ThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new TechnicalControlService(null));
        }

        [TestMethod]
        public void AddTechnicalControl_CorrectTechnicalControl_ReturnTechnicalControlNotNull()
        {
            //Arrange
            var ct = new TechnicalControl
            {
                Comment = "blabla",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1),
            };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.TechnicalControlRepository.Insert(It.IsAny<TechnicalControlTO>()))
                .Returns(ct.ToTransfertObject());
            var mockTechnicalControl = new Mock<ITechnicalControl>();
            mockTechnicalControl.Setup(x => x.Insert(It.IsAny<TechnicalControl>()))
                .Returns(ct);

            //Act
            //Assert
        }
    }
}