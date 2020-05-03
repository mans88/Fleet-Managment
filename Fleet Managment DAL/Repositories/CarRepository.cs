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
        => context.Cars
            //.Include(x => x.Brand)
            //.ThenInclude(x => x.Models)
            .AsNoTracking()
            .Select(x => x.ToTransfertObject());

        public CarTO GetByID(int id)
        => context.Cars
            //.Include(x => x.Brand)
            //.AsNoTracking()
            .FirstOrDefault(x => x.Id == id).ToTransfertObject();

        public CarTO Insert(CarTO car)
        {
            if (car is null) throw new ArgumentNullException(nameof(car));
            var brand = context.Brands.Find(car.Brand.Id);
            var entityCar = car.ToEntity();
            entityCar.Brand = brand;
            return context.Cars.Add(entityCar).Entity.ToTransfertObject();
            //return context.Cars.Add(car.ToEntity()).Entity.ToTransfertObject();
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

        public CarTO Update(CarTO entity)
        {
            if (entity is null) throw new ArgumentException(nameof(entity));
            var updated = context.Cars.FirstOrDefault(x => x.Id == entity.Id);
            updated.Brand = entity.Brand?.ToEntity();
            updated.Chassis = entity.Chassis;
            updated.EndDateContract = entity.EndDateContract;
            updated.Insurances = entity.Insurances?.Select(x => x.ToEntity()).ToList();
            updated.Km = entity.Km;
            updated.Numberplate = entity.Numberplate;
            updated.StartDateContract = entity.StartDateContract;
            updated.TechnicalControls = entity.Technicalcontrols?.Select(x => x.ToEntity()).ToList();
            updated.VehicleStatus = entity.VehicleStatus;
            updated.Year = entity.Year;

            return updated.ToTransfertObject();
        }
    }
}