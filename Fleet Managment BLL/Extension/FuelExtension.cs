using Fleet_Managment_BLL.Domain;
using FleetManagment.Shared.TransfertObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fleet_Managment_BLL.Extension
{
    public static class FuelExtension
    {
        public static FuelTO ToTransfertObject(this Fuel fuel)
        {
            if (fuel is null) throw new ArgumentNullException(nameof(fuel));

            return new FuelTO
            {
                Id = fuel.Id,
                Name = fuel.Name,
                Models = fuel.Models?.Select(x => x.ToTransfertObject()).ToList()
            };
        }

        public static Fuel ToDomain(this FuelTO fuel)
        {
            if (fuel is null) throw new ArgumentNullException(nameof(fuel));

            return new Fuel
            {
                Id = fuel.Id,
                Name = fuel.Name,
                Models = fuel.Models?.Select(x => x.ToDomain()).ToList()
            };
        }
    }
}