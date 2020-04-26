using Fleet_Managment_BLL.Domain;
using FleetManagment.Shared.TransfertObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Fleet_Managment_BLL.Extension
{
    public static class ModelExtension
    {
        public static ModelTO ToTransfertObject(this Model model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));

            return new ModelTO
            {
                Id = model.Id,
                Name = model.Name,
                Brand = model.Brand?.ToTransfertObject(),
                Fules = model.Fuels?.Select(x => x.ToTransfertObject()).ToList()
            };
        }

        public static Model ToDomain(this ModelTO model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));

            return new Model
            {
                Id = model.Id,
                Name = model.Name,
                Brand = model.Brand?.ToDomain(),
                Fuels = model.Fules?.Select(x => x.ToDomain()).ToList()
            };
        }
    }
}