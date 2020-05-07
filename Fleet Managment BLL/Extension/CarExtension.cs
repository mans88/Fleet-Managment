using Fleet_Managment_BLL.Domain;
using FleetManagment.Shared.TransfertObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fleet_Managment_BLL.Extension
{
    public static class CarExtension
    {
        public static CarTO ToTransfertObject(this Car car)
        {
            if (car is null) throw new ArgumentNullException(nameof(car));

            return new CarTO
            {
                Id = car.Id,
                Chassis = car.Chassis,
                EndDateContract = car.EndDateContract,
                Km = car.Km,
                Numberplate = car.Numberplate,
                StartDateContract = car.StartDateContract,
                Year = car.Year,
                VehicleStatus = car.VehicleStatus,
                Technicalcontrols = car.Technicalcontrols?.Select(t => t.ToTransfertObject()).ToList(),
                Insurances = car.Insurances?.Select(x => x.ToTransfertObject()).ToList(),
                Model = car.Model.ToTransfertObject(),
                Fuel = car.Fuel
            };
        }

        public static Car ToDomain(this CarTO car)
        {
            if (car is null) throw new ArgumentNullException(nameof(car));

            return new Car
            {
                Id = car.Id,
                Chassis = car.Chassis,
                EndDateContract = car.EndDateContract,
                Km = car.Km,
                Numberplate = car.Numberplate,
                StartDateContract = car.StartDateContract,
                Year = car.Year,
                VehicleStatus = car.VehicleStatus,
                Technicalcontrols = car.Technicalcontrols?.Select(t => t.ToDomain()).ToList(),
                Insurances = car.Insurances?.Select(x => x.ToDomain()).ToList(),
                Model = car.Model.ToDomain(),
                Fuel = car.Fuel
            };
        }
    }
}