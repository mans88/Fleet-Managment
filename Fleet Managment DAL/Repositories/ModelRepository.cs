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
    public class ModelRepository : IModelRepository
    {
        // Context
        private readonly FleetManagmentContext context;

        public ModelRepository(FleetManagmentContext context)
        {
            this.context = context ?? throw new ArgumentNullException($"{nameof(context)} in ModelRepository");
        }

        public ModelTO GetByID(int modelId)
            => context.Models.Include(x => x.ModelFuels)
            .ThenInclude(x => x.Fuel)
            .AsNoTracking().FirstOrDefault(f => f.Id == modelId).ToTransfertObject();

        public IEnumerable GetAll()
        => context.Models
            .Include(x => x.ModelFuels)
            .ThenInclude(x => x.Fuel)
            .AsNoTracking().Select(f => f.ToTransfertObject()).ToList();

        public ModelTO Insert(ModelTO model)
        {
            if (model is null) throw new ArgumentException(nameof(model));

            return context.Models.Add(model.ToEntity()).Entity.ToTransfertObject();
        }

        public bool Remove(ModelTO model)
        {
            return RemoveById(model.Id);
        }

        public bool RemoveById(int id)
        {
            var entity = context.Set<Brand>().Find(id);
            var tracking = context.Set<Brand>().Remove(entity);
            return tracking.State == EntityState.Deleted;
        }

        public ModelTO Update(ModelTO entity)
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