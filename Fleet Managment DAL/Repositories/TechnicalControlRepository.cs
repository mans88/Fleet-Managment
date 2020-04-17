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
    public class TechnicalControlRepository : ITechnicalControlRepository
    {
        private FleetManagmentContext context;

        public TechnicalControlRepository(FleetManagmentContext context)
        {
            this.context = context;
        }

        public IEnumerable<TechnicalControlTO> GetAll()
        => context.TechnicalControls
            //.Include(x => x.Car)
            //    .ThenInclude(x => x.Brand)
            //    .ThenInclude(x => x.Models)
            //    .ThenInclude(x => x.ModelFuels)
            //    .ThenInclude(x => x.Fuel)
            .AsNoTracking()
            .Select(x => x.ToTransfertObject()).ToList();

        public TechnicalControlTO GetByID(int id)
        {
            if (id <= 0) throw new ArgumentException();

            return context.TechnicalControls
                //.Include(x => x.Car)
                //.ThenInclude(x => x.Brand)
                //.ThenInclude(x => x.Models)
                //.ThenInclude(x => x.ModelFuels)
                //.ThenInclude(x => x.Fuel)
                //.AsNoTracking()
                .FirstOrDefault(x => x.Id == id)
                .ToTransfertObject();
        }

        public TechnicalControlTO Insert(TechnicalControlTO entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            return context.TechnicalControls.Add(entity.ToEntity()).Entity.ToTransfertObject();
        }

        public bool Remove(TechnicalControlTO entity)
        {
            return RemoveById(entity.Id);
        }

        public bool RemoveById(int id)
        {
            var toRemove = context
               .TechnicalControls
               .FirstOrDefault(f => f.Id == id);

            var removed = context
                .TechnicalControls
                .Remove(toRemove);

            return removed.State == EntityState.Deleted;
        }

        public TechnicalControlTO Update(TechnicalControlTO entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            var updated = context.TechnicalControls.FirstOrDefault(x => x.Id == entity.Id);
            updated.Car = entity.Car?.ToEntity();
            updated.Comment = entity.Comment;
            updated.EndDate = entity.EndDate;
            updated.StartDate = entity.StartDate;

            return updated.ToTransfertObject();
        }
    }
}