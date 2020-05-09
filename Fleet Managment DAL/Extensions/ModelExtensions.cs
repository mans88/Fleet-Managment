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
                Brand = model.Brand.ToTransfertObject(),
                //Cars = model.Cars?.Select(c => c.ToTransfertObject()).ToList(),
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
                Cars = model.Cars?.Select(c => c.ToEntity()).ToList(),
            };
        }
    }
}