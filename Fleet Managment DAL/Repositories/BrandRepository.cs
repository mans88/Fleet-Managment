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
            .Include(m => m.Models)
            //.AsNoTracking()
            .FirstOrDefault(x => x.Id == id)
            .ToTransfertObject();

        public BrandTO Insert(BrandTO brand)
        {
            if (brand is null) throw new ArgumentNullException(nameof(brand));

            var brandEntity = brand.ToEntity();

            if (brand.Models != null)
            {
                var models = context.Models.Select(c => c.Brand.Id == brand.Id);

                brandEntity.Models = (List<Model>)models;
            }

            return context.Brands.Add(brandEntity).Entity.ToTransfertObject();
        }

        public bool Remove(BrandTO brand)
        {
            if (brand is null) throw new ArgumentException(nameof(brand));
            return RemoveById(brand.Id);
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

        public BrandTO Update(BrandTO brand)
        {
            if (brand is null) throw new ArgumentException(nameof(brand));

            var modified = context.Brands.FirstOrDefault(b => b.Id == brand.Id);
            modified.Models = brand.Models?.Select(c => c.ToEntity()).ToList();
            modified.Name = brand.Name;
            return modified.ToTransfertObject();
        }
    }
}