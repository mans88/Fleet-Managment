using Fleet_Managment_BLL.Domain;
using Fleet_Managment_BLL.Extension;
using Fleet_Managment_DAL.Interfaces;
using FleetManagment.Shared;
using FleetManagment.Shared.TransfertObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fleet_Managment_BLL.Services
{
    public class FuelService
    {
        private IUnitOfWork unitOfWork;

        public FuelService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public List<Fuel> GetFuels() => unitOfWork
                .FuelRepository
                .GetAll()
                .Select(f => f.ToDomain())
                .ToList();

        public bool CreateFuel(Fuel fuel)
        {
            if (fuel is null)
                throw new ArgumentNullException(nameof(fuel));

            var addedFuel = unitOfWork.FuelRepository.Insert(fuel.ToTransfertObject());

            return fuel.Id != 0;
        }
    }
}