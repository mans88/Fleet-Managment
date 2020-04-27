using Fleet_Managment_BLL.Domain;
using Fleet_Managment_BLL.Extension;
using Fleet_Managment_BLL.Interfaces;
using Fleet_Managment_DAL.Interfaces;
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

        public List<Insurance> GetAll() => unitOfWork.InsuranceRepository.GetAll().Select(c => c.ToDomain()).ToList();

        public Insurance GetById(int id) => unitOfWork.InsuranceRepository.GetByID(id).ToDomain();

        public Insurance Insert(Insurance insurance)
        {
            if (insurance is null)
                throw new ArgumentNullException(nameof(insurance));

            return unitOfWork.InsuranceRepository.Insert(insurance.ToTransfertObject()).ToDomain();
        }

        public bool RemoveById(int id) => unitOfWork.InsuranceRepository.RemoveById(id);

        public Insurance Update(Insurance insurance)
        {
            if (insurance is null)
                throw new ArgumentNullException(nameof(insurance));
            return unitOfWork.InsuranceRepository.Update(insurance.ToTransfertObject()).ToDomain();
        }
    }
}