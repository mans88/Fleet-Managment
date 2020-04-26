using Fleet_Managment_BLL.Domain;
using FleetManagment.Shared.TransfertObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fleet_Managment_BLL.Extension
{
    public static class InsuranceExtension
    {
        public static InsuranceTO ToTransfertObject(this Insurance insurance)
        {
            if (insurance is null) throw new ArgumentNullException(nameof(insurance));

            return new InsuranceTO
            {
                Id = insurance.Id,
                Name = insurance.Name,
                StartDate = insurance.StartDate,
                EndDate = insurance.EndDate,
                Car = insurance.Car.ToTransfertObject()
            };
        }

        public static Insurance ToDomain(this InsuranceTO insurance)
        {
            if (insurance is null) throw new ArgumentNullException(nameof(insurance));

            return new Insurance
            {
                Id = insurance.Id,
                Name = insurance.Name,
                StartDate = insurance.StartDate,
                EndDate = insurance.EndDate,
                Car = insurance.Car.ToDomain()
            };
        }
    }
}