using Fleet_Managment_DAL.Entities;
using Fleet_Managment_DAL.Extensions;
using Fleet_Managment_DAL.Interfaces;
using FleetManagment.Shared.TransfertObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fleet_Managment_DAL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private FleetManagmentContext context;

        public CarRepository(FleetManagmentContext context)
        {
            this.context = context;
        }

        public IEnumerable<CarTO> GetAll()
        {
            var s = context.Cars
            .Include(m => m.Model)
            .ThenInclude(b => b.Brand)
            .Select(x => x.ToTransfertObject());

            return s;
        }

        public CarTO GetByID(int id)
        => context.Cars
            .Include(m => m.Model)
            .ThenInclude(b => b.Brand)
            .FirstOrDefault(x => x.Id == id)
            .ToTransfertObject();

        public CarTO Insert(CarTO car)
        {
            if (car is null) throw new ArgumentNullException(nameof(car));
            var model = context.Models.Find(car.Model.Id);
            var entityCar = car.ToEntity();
            entityCar.Model = model;

            return context.Cars.Add(entityCar).Entity.ToTransfertObject();
        }

        public bool Remove(CarTO entity)
        {
            return RemoveById(entity.Id);
        }

        public bool RemoveById(int id)
        {
            var entity = context.Set<Car>().Find(id);
            var tracking = context.Set<Car>().Remove(entity);
            return tracking.State == EntityState.Deleted;
        }

        public CarTO Update(CarTO car)
        {
            if (car is null) throw new ArgumentException(nameof(car));
            var updated = context.Cars.Find(car.Id);
            var modelUpdated = context.Models.Find(car.Model.Id);
            updated.Model = modelUpdated;
            updated.Chassis = car.Chassis;
            updated.EndDateContract = car.EndDateContract;
            updated.Insurances = car.Insurances?.Select(x => x.ToEntity()).ToList();
            updated.Km = car.Km;
            updated.Numberplate = car.Numberplate;
            updated.StartDateContract = car.StartDateContract;
            updated.TechnicalControls = car.Technicalcontrols?.Select(x => x.ToEntity()).ToList();
            updated.VehicleStatus = car.VehicleStatus;
            updated.Year = car.Year;
            updated.Fuel = car.Fuel;

            return updated.ToTransfertObject();
        }
    }
}