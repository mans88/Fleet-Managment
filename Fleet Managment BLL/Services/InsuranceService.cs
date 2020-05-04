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
    public class InsuranceService : IInsuranceService
    {
        private readonly IUnitOfWork unitOfWork;

        public InsuranceService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public List<InsuranceTO> GetAll() => unitOfWork.InsuranceRepository.GetAll().Select(c => c.ToDomain().ToTransfertObject()).ToList();

        public InsuranceTO GetById(int id) => unitOfWork.InsuranceRepository.GetByID(id).ToDomain().ToTransfertObject();

        public InsuranceTO Insert(InsuranceTO insurance)
        {
            if (insurance is null)
                throw new ArgumentNullException(nameof(insurance));

            return unitOfWork.InsuranceRepository.Insert(insurance.ToDomain().ToTransfertObject());
        }

        public bool RemoveById(int id) => unitOfWork.InsuranceRepository.RemoveById(id);

        public InsuranceTO Update(InsuranceTO insurance)
        {
            if (insurance is null)
                throw new ArgumentNullException(nameof(insurance));
            return unitOfWork.InsuranceRepository.Update(insurance.ToDomain().ToTransfertObject());
        }
    }
}