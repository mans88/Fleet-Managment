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

        public IEnumerable GetAll()
        => context.Brands
            .Include(x => x.Models)
            .Select(x => x.ToTransfertObject())
            .ToList();

        public BrandTO GetByID(int id)
        => context.Brands
            .Include(x => x.Models)
            .FirstOrDefault(x => x.Id == id).ToTransfertObject();

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
            var entity = context.Set<Brand>().Find(id);
            var tracking = context.Set<Brand>().Remove(entity);
            return tracking.State == EntityState.Deleted;
        }

        public BrandTO Update(BrandTO entity)
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