using Fleet_Managment_BLL.Domain;
using Fleet_Managment_BLL.Extension;
using Fleet_Managment_BLL.Interfaces;
using Fleet_Managment_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fleet_Managment_BLL.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork unitOfWork;

        public CarService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll() => unitOfWork.CarRepository.GetAll().Select(c => c.ToDomain()).ToList();

        public Car GetById(int id) => unitOfWork.CarRepository.GetByID(id).ToDomain();

        public Car Insert(Car car)
        {
            throw new NotImplementedException();
        }
    }
}