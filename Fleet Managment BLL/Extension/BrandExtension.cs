using Fleet_Managment_BLL.Domain;
using FleetManagment.Shared.TransfertObject;
using System;
using System.Linq;

namespace Fleet_Managment_BLL.Extension
{
    public static class BrandExtension
    {
        public static BrandTO ToTransfertObject(this Brand brand)
        {
            if (brand is null) throw new ArgumentNullException(nameof(brand));

            BrandTO brandTO = new BrandTO
            {
                Id = brand.Id,
                //Models = brand.Models?.Select(x => x.ToTransfertObject()).ToList(),
                Name = brand.Name
            };
            return brandTO;
        }

        public static Brand ToDomain(this BrandTO brandTO)
        {
            if (brandTO is null) throw new ArgumentNullException(nameof(brandTO));

            Brand brand = new Brand
            {
                Id = brandTO.Id,
                Models = brandTO.Models?.Select(x => x.ToDomain()).ToList(),
                Name = brandTO.Name
            };

            return brand;
        }
    }
}