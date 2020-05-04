using Fleet_Managment_BLL.Domain;
using Fleet_Managment_BLL.Extension;
using Fleet_Managment_BLL.Interfaces;
using Fleet_Managment_DAL.Interfaces;
using FleetManagment.Shared.TransfertObject;
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

        public List<CarTO> GetAll() => unitOfWork.CarRepository.GetAll().Select(c => c.ToDomain().ToTransfertObject()).ToList();

        public CarTO GetById(int id) => unitOfWork.CarRepository.GetByID(id).ToDomain().ToTransfertObject();

        public CarTO Insert(CarTO car)
        {
            if (car is null)
                throw new ArgumentNullException(nameof(car));
            var carAdded = unitOfWork.CarRepository.Insert(car.ToDomain().ToTransfertObject());
            unitOfWork.SaveChanges();
            return carAdded; ;
        }

        public bool RemoveById(int id) => unitOfWork.CarRepository.RemoveById(id);

        public CarTO Update(CarTO car)
        {
            if (car is null)
                throw new ArgumentNullException(nameof(car));
            return unitOfWork.CarRepository.Update(car.ToDomain().ToTransfertObject());
        }
    }
}