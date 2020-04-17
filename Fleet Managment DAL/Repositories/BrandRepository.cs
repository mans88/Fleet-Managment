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
    public class BrandRepository : IBrandRepository
    {
        private FleetManagmentContext context;

        public BrandRepository(FleetManagmentContext context)
        {
            this.context = context;
        }

        public IEnumerable<BrandTO> GetAll()
        => context
            .Brands
            .AsNoTracking()
            .Select(x => x.ToTransfertObject())
            .ToList();

        public BrandTO GetByID(int id)
        => context.Brands
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id)
            .ToTransfertObject();

        public BrandTO Insert(BrandTO entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return context.Brands.Add(entity.ToEntity()).Entity.ToTransfertObject();
        }

        public bool Remove(BrandTO entity)
        {
            if (entity is null) throw new ArgumentException(nameof(entity));
            return RemoveById(entity.Id);
        }

        public bool RemoveById(int id)
        {
            var toRemove = context
                .Brands
                .FirstOrDefault(f => f.Id == id);

            var removed = context
                .Brands
                .Remove(toRemove);

            return removed.State == EntityState.Deleted;
        }

        public BrandTO Update(BrandTO entity)
        {
            if (entity is null) throw new ArgumentException(nameof(entity));

            var modified = context.Brands.FirstOrDefault(b => b.Id == entity.Id);
            modified.Cars = entity.Cars?.Select(c => c.ToEntity()).ToList();
            modified.Models = entity.Models?.Select(c => c.ToEntity()).ToList();
            modified.Name = entity.Name;
            return modified.ToTransfertObject();
        }
    }
}