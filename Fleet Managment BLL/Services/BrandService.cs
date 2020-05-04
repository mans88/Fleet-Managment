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
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork unitOfWork;

        public BrandService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public List<BrandTO> GetAll() => unitOfWork.BrandRepository.GetAll().Select(c => c.ToDomain().ToTransfertObject()).ToList();

        public BrandTO GetById(int id) => unitOfWork.BrandRepository.GetByID(id).ToDomain().ToTransfertObject();

        public BrandTO Insert(BrandTO brand)
        {
            if (brand is null)
                throw new ArgumentNullException(nameof(brand));

            return unitOfWork.BrandRepository.Insert(brand.ToDomain().ToTransfertObject());
        }

        public bool RemoveById(int id) => unitOfWork.BrandRepository.RemoveById(id);

        public BrandTO Update(BrandTO brand)
        {
            if (brand is null)
                throw new ArgumentNullException(nameof(brand));
            return unitOfWork.BrandRepository.Update(brand.ToDomain().ToTransfertObject());
        }
    }
}