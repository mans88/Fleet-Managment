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

            return new BrandTO
            {
                Id = brand.Id,
                Cars = brand.Cars?.Select(x => x.ToTransfertObject()).ToList(),
                Models = brand.Models?.Select(x => x.ToTransfertObject()).ToList(),
                Name = brand.Name
            };
        }

        public static Brand ToDomain(this BrandTO brand)
        {
            if (brand is null) throw new ArgumentNullException(nameof(brand));

            return new Brand
            {
                Id = brand.Id,
                Cars = brand.Cars?.Select(x => x.ToDomain()).ToList(),
                Models = brand.Models?.Select(x => x.ToDomain()).ToList(),
                Name = brand.Name
            };
        }
    }
}