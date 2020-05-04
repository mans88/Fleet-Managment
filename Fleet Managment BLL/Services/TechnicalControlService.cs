using Fleet_Managment_BLL.Domain;
using Fleet_Managment_BLL.Extension;
using Fleet_Managment_BLL.Interfaces;
using Fleet_Managment_DAL.Interfaces;
using FleetManagment.Shared.TransfertObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fleet_Managment_BLL.Services
{
    public class TechnicalControlService : ITechnicalControl
    {
        private readonly IUnitOfWork unitOfWork;

        public TechnicalControlService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public List<TechnicalControlTO> GetAll() => unitOfWork.TechnicalControlRepository.GetAll().Select(c => c.ToDomain().ToTransfertObject()).ToList();

        public TechnicalControlTO GetById(int id) => unitOfWork.TechnicalControlRepository.GetByID(id).ToDomain().ToTransfertObject();

        public TechnicalControlTO Insert(TechnicalControlTO technicalControl)
        {
            if (technicalControl is null)
                throw new ArgumentNullException(nameof(technicalControl));

            return unitOfWork.TechnicalControlRepository.Insert(technicalControl.ToDomain().ToTransfertObject());
        }

        public bool RemoveById(int id) => unitOfWork.TechnicalControlRepository.RemoveById(id);

        public TechnicalControlTO Update(TechnicalControlTO technicalControl)
        {
            if (technicalControl is null)
                throw new ArgumentNullException(nameof(technicalControl));
            return unitOfWork.TechnicalControlRepository.Update(technicalControl.ToDomain().ToTransfertObject());
        }
    }
}