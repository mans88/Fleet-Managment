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

        public List<Car> GetAll() => unitOfWork.CarRepository.GetAll().Select(c => c.ToDomain()).ToList();

        public Car GetById(int id) => unitOfWork.CarRepository.GetByID(id).ToDomain();

        public Car Insert(Car car)
        {
            if (car is null)
                throw new ArgumentNullException(nameof(car));

            return unitOfWork.CarRepository.Insert(car.ToTransfertObject()).ToDomain();
        }

        public bool RemoveById(int id) => unitOfWork.CarRepository.RemoveById(id);

        public Car Update(Car car)
        {
            if (car is null)
                throw new ArgumentNullException(nameof(car));
            return unitOfWork.CarRepository.Update(car.ToTransfertObject()).ToDomain();
        }
    }
}