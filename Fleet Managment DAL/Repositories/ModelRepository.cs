using Fleet_Managment_DAL.Entities;
using Fleet_Managment_DAL.Extensions;
using Fleet_Managment_DAL.Interfaces;
using FleetManagment.Shared.TransfertObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
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
            => context.Models
            .Include(b => b.Brand)
            .FirstOrDefault(m => m.Id == modelId)
            .ToTransfertObject();

        public IEnumerable<ModelTO> GetAll()
        => context.Models
            .Include(b => b.Brand)
            // .AsNoTracking()
            .Select(f => f.ToTransfertObject())
            .ToList();

        public ModelTO Insert(ModelTO model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));

            var brand = context.Brands.Find(model.Brand.Id);
            var modelEntity = model.ToEntity();

            modelEntity.Brand = brand;

            return context.Models.Add(modelEntity).Entity.ToTransfertObject();
        }

        public bool Remove(ModelTO model)
        {
            return RemoveById(model.Id);
        }

        public bool RemoveById(int id)
        {
            var toRemove = context
              .Models
              .FirstOrDefault(f => f.Id == id);

            var removed = context
                .Models
                .Remove(toRemove);

            return removed.State == EntityState.Deleted;
        }

        public ModelTO Update(ModelTO entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            var updated = context.Models.FirstOrDefault(x => x.Id == entity.Id);
            updated.Name = entity.Name;
            updated.Brand = entity.Brand?.ToEntity();

            return updated.ToTransfertObject();
        }
    }
}