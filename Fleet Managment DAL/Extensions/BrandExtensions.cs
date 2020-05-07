using Fleet_Managment_DAL.Entities;
using FleetManagment.Shared.TransfertObject;
using System;
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
                //Models = brand.Models?.Select(x => x.ToTransfertObject()).ToList(),
                Name = brand.Name,
            };
            return brandTO;
        }

        public static Brand ToEntity(this BrandTO brandTO)
        {
            if (brandTO is null) throw new ArgumentNullException(nameof(brandTO));

            Brand brand = new Brand
            {
                Id = brandTO.Id,
                Name = brandTO.Name,
                Models = brandTO.Models?.Select(m => m.ToEntity()).ToList()
            };
            return brand;
        }
    }
}