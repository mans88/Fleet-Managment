using Fleet_Managment_DAL.Entities;
using FleetManagment.Shared.TransfertObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fleet_Managment_DAL.Extensions
{
    public static class ModelExtensions
    {
        public static ModelTO ToTransfertObject(this Model model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));

            return new ModelTO
            {
                Id = model.Id,
                Name = model.Name,
                Brand = model.Brand?.ToTransfertObject(),
                Fules = model.ModelFuels?.Select(x => x.Fuel.ToTransfertObject()).ToList()
            };
        }

        public static Model ToEntity(this ModelTO model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));

            return new Model
            {
                Id = model.Id,
                Name = model.Name,
                Brand = model.Brand?.ToEntity(),
                ModelFuels = model?.CreatingKind(),
            };
        }

        public static ICollection<ModelFuel> CreatingKind(this ModelTO model)
        {
            ICollection<ModelFuel> kinds = new List<ModelFuel>();
            if (model.Fules == null)
                return kinds;
            foreach (var fuel in model.Fules)
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