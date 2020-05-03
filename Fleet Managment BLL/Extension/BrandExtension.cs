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
                //Cars = brand.Cars?.Select(x => x.ToTransfertObject()).ToList(),
                Models = brand.Models?.Select(x => x.ToTransfertObject()).ToList(),
                Name = brand.Name
            };

            if (brand.Cars != null)
            {
                brandTO.Cars = brand.Cars.Select(b => b.ToTransfertObject()).ToList();
                brandTO.Cars.Select(s => s.Brand = brandTO);
            }

            return brandTO;
        }

        public static Brand ToDomain(this BrandTO brandTO)
        {
            if (brandTO is null) throw new ArgumentNullException(nameof(brandTO));

            Brand brand = new Brand
            {
                Id = brandTO.Id,
                // Cars = brandTO.Cars?.Select(x => x.ToDomain()).ToList(),
                Models = brandTO.Models?.Select(x => x.ToDomain()).ToList(),
                Name = brandTO.Name
            };

            if (brandTO.Cars != null)
            {
                brand.Cars.Select(s => s.Brand = brand);
                brand.Cars = brandTO.Cars.Select(b => b.ToDomain()).ToList();
            }

            return brand;
        }
    }
}