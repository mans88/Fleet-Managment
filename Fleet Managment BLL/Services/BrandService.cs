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
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork unitOfWork;

        public BrandService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public List<Brand> GetAll() => unitOfWork.BrandRepository.GetAll().Select(c => c.ToDomain()).ToList();

        public Brand GetById(int id) => unitOfWork.BrandRepository.GetByID(id).ToDomain();

        public Brand Insert(Brand brand)
        {
            if (brand is null)
                throw new ArgumentNullException(nameof(brand));

            return unitOfWork.BrandRepository.Insert(brand.ToTransfertObject()).ToDomain();
        }

        public bool RemoveById(int id) => unitOfWork.BrandRepository.RemoveById(id);

        public Brand Update(Brand brand)
        {
            if (brand is null)
                throw new ArgumentNullException(nameof(brand));
            return unitOfWork.BrandRepository.Update(brand.ToTransfertObject()).ToDomain();
        }
    }
}