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

            BrandTO brandTO = new BrandTO
            {
                Id = brand.Id,
                //Cars = brand.Cars?.Select(x => x.ToTransfertObject()).ToList(),
                Models = brand.Models?.Select(x => x.ToTransfertObject()).ToList(),
                Name = brand.Name
            };

            if (brandTO.Cars != null)
            {
                brandTO.Cars = brand.Cars.Select(b => b.ToTransfertObject()).ToList();
                brandTO.Cars.Select(s => s.Brand = brandTO);
            }

            return brandTO;
        }

        public static Brand ToEntity(this BrandTO brandTO)
        {
            if (brandTO is null) throw new ArgumentNullException(nameof(brandTO));

            Brand brand = new Brand
            {
                Id = brandTO.Id,
                Name = brandTO.Name,
                // Cars = brand.Cars?.Select(c => c.ToEntity()).ToList(),
                Models = brandTO.Models?.Select(m => m.ToEntity()).ToList()
            };

            if (brandTO.Cars != null)
            {
                brand.Cars.Select(s => s.Brand = brand);
                brand.Cars = brandTO.Cars.Select(b => b.ToEntity()).ToList();
            }

            return brand;
        }
    }
}