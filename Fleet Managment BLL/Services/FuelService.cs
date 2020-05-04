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
    public class FuelService : IFuelService
    {
        private IUnitOfWork unitOfWork;

        public FuelService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public List<FuelTO> GetAll() => unitOfWork.FuelRepository.GetAll().Select(c => c.ToDomain().ToTransfertObject()).ToList();

        public FuelTO GetById(int id) => unitOfWork.FuelRepository.GetByID(id).ToDomain().ToTransfertObject();

        public FuelTO Insert(FuelTO fuel)
        {
            if (fuel is null)
                throw new ArgumentNullException(nameof(fuel));

            return unitOfWork.FuelRepository.Insert(fuel.ToDomain().ToTransfertObject());
        }

        public bool RemoveById(int id) => unitOfWork.FuelRepository.RemoveById(id);

        public FuelTO Update(FuelTO fuel)
        {
            if (fuel is null)
                throw new ArgumentNullException(nameof(fuel));
            return unitOfWork.FuelRepository.Update(fuel.ToDomain().ToTransfertObject());
        }
    }
}