using Fleet_Managment_DAL.Entities;
using Fleet_Managment_DAL.Extensions;
using FleetManagment.Shared;
using FleetManagment.Shared.TransfertObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Fleet_Managment_DAL.Repositories
{
    public class FuelRepository : IFuelRepository
    {
        // Context
        private readonly FleetManagmentContext context;

        public FuelRepository(FleetManagmentContext context)
        {
            this.context = context ?? throw new ArgumentNullException($"{nameof(context)} in FuelRepository");
        }

        public IEnumerable<FuelTO> GetAll()
        => context.Fuels
            //.Include(x => x.ModelFuels)
            //.ThenInclude(x => x.Model)
            .AsNoTracking().Select(f => f.ToTransfertObject()).ToList();

        public FuelTO GetByID(int fuelId)
            => context.Fuels
            //.Include(x => x.ModelFuels)
            //.ThenInclude(x => x.Model)
            .AsNoTracking().FirstOrDefault(f => f.Id == fuelId).ToTransfertObject();

        public FuelTO Insert(FuelTO fuel)
        {
            if (fuel is null) throw new ArgumentNullException(nameof(fuel));

            return context.Fuels.Add(fuel.ToEntity()).Entity.ToTransfertObject();
        }

        public bool Remove(FuelTO fuel)
        {
            return RemoveById(fuel.Id);
        }

        public bool RemoveById(int id)
        {
            var entity = context.Set<Fuel>().Find(id);
            var tracking = context.Set<Fuel>().Remove(entity);
            return tracking.State == EntityState.Deleted;
        }

        public FuelTO Update(FuelTO entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            var updated = context.Fuels.FirstOrDefault(x => x.Id == entity.Id);
            updated.Name = entity.Name;
            return updated.ToTransfertObject();
        }
    }
}