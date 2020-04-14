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
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly FleetManagmentContext context;

        public InsuranceRepository(FleetManagmentContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable GetAll()
            => context.Insurances
               .Include(x => x.Car)
               .ThenInclude(x => x.Brand)
               .ThenInclude(x => x.Models)
               .AsNoTracking().Select(x => x.ToTransfertObject());

        public InsuranceTO GetByID(int id)
         => context.Insurances
                .Include(x => x.Car)
                .ThenInclude(x => x.Brand)
                .AsNoTracking().FirstOrDefault(x => x.Id == id).ToTransfertObject();

        public InsuranceTO Insert(InsuranceTO entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            return context.Insurances.Add(entity.ToEntity()).Entity.ToTransfertObject();
        }

        public bool Remove(InsuranceTO entity)
        => RemoveById(entity.Id);

        public bool RemoveById(int id)
        {
            var entity = context.Set<Insurance>().Find(id);
            var tracking = context.Set<Insurance>().Remove(entity);
            return tracking.State == EntityState.Deleted;
        }

        public InsuranceTO Update(InsuranceTO entity)
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