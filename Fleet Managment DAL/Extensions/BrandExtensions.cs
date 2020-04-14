using Fleet_Managment_DAL.Entities;
using FleetManagment.Shared.TransfertObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fleet_Managment_DAL.Extensions
{
    public static class BrandExtensions
    {
        public static BrandTO ToTransfertObject(this Brand brand)
        {
            if (brand is null) throw new ArgumentNullException(nameof(brand));

            return new BrandTO
            {
                Cars = brand.Cars.Select(x => x.ToTransfertObject()).ToList(),
                Models = brand.Models.Select(x => x.ToTransfertObject()).ToList(),
                Name = brand.Name,
                Id = brand.Id
            };
        }

        public static Brand ToEntity(this BrandTO brand)
        {
            if (brand is null) throw new ArgumentNullException(nameof(brand));

            return new Brand
            {
                Id = brand.Id,
                Name = brand.Name,
                Cars = brand.Cars.Select(c => c.ToEntity()).ToList(),
                Models = brand.Models.Select(m => m.ToEntity()).ToList()
            };
        }
    }
}