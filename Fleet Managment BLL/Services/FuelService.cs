using Fleet_Managment_BLL.Domain;
using Fleet_Managment_BLL.Extension;
using Fleet_Managment_BLL.Interfaces;
using Fleet_Managment_DAL.Interfaces;
using FleetManagment.Shared;
using FleetManagment.Shared.TransfertObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fleet_Managment_BLL.Services
{
    public class FuelService : IFuelService
    {
        private IUnitOfWork unitOfWork;

        public FuelService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public List<Fuel> GetAll() => unitOfWork.FuelRepository.GetAll().Select(c => c.ToDomain()).ToList();

        public Fuel GetById(int id) => unitOfWork.FuelRepository.GetByID(id).ToDomain();

        public Fuel Insert(Fuel fuel)
        {
            if (fuel is null)
                throw new ArgumentNullException(nameof(fuel));

            return unitOfWork.FuelRepository.Insert(fuel.ToTransfertObject()).ToDomain();
        }

        public bool RemoveById(int id) => unitOfWork.FuelRepository.RemoveById(id);

        public Fuel Update(Fuel fuel)
        {
            if (fuel is null)
                throw new ArgumentNullException(nameof(fuel));
            return unitOfWork.FuelRepository.Update(fuel.ToTransfertObject()).ToDomain();
        }
    }
}