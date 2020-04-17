using Fleet_Managment_DAL.Entities;
using FleetManagment.Shared.TransfertObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fleet_Managment_DAL.Extensions
{
    public static class FuelExtensions
    {
        public static FuelTO ToTransfertObject(this Fuel fuel)
        {
            if (fuel is null) throw new ArgumentNullException(nameof(fuel));

            return new FuelTO
            {
                Id = fuel.Id,
                Name = fuel.Name,
                Models = fuel.ModelFuels?.Select(x => x.Model?.ToTransfertObject()).ToList()
            };
        }

        public static Fuel ToEntity(this FuelTO fuel)
        {
            if (fuel is null) throw new ArgumentNullException(nameof(fuel));

            return new Fuel
            {
                Id = fuel.Id,
                Name = fuel.Name,
                ModelFuels = fuel?.CreatingKind()
            };
        }

        public static ICollection<ModelFuel> CreatingKind(this FuelTO fuel)
        {
            ICollection<ModelFuel> kinds = new List<ModelFuel>();

            if (fuel.Models == null)
                return kinds;
            foreach (var model in fuel.Models)
            {
                var kind = new ModelFuel
                {
                    FuelId = fuel.Id,
                    ModelId = model.Id,
                };
                kinds.Add(kind);
            }

            return kinds;
        }
    }
}