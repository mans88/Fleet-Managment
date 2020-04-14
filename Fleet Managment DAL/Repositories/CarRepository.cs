using Fleet_Managment_DAL.Entities;
using Fleet_Managment_DAL.Extensions;
using FleetManagment.Shared;
using FleetManagment.Shared.TransfertObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fleet_Managment_DAL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private FleetManagmentContext context;

        public CarRepository(FleetManagmentContext context)
        {
            this.context = context;
        }

        public IEnumerable GetAll()
        => context.Cars
            .Include(x => x.Brand)
            .ThenInclude(x => x.Models)
            .AsNoTracking()
            .Select(x => x.ToTransfertObject());

        public CarTO GetByID(int id)
        => context.Cars
            .Include(x => x.Brand)
            .ThenInclude(x => x.Models)
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id).ToTransfertObject();

        public CarTO Insert(CarTO entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return context.Cars.Add(entity.ToEntity()).Entity.ToTransfertObject();
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
            try
            {
                context.Attach(entity.ToEntity()).State = EntityState.Modified;
                return entity;
            }
            catch
            {
                throw;
            }
        }
    }
}