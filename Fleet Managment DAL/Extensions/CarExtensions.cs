using Fleet_Managment_DAL.Entities;
using FleetManagment.Shared.TransfertObject;
using System;
using System.Linq;

namespace Fleet_Managment_DAL.Extensions
{
    public static class CarExtensions
    {
        public static CarTO ToTransfertObject(this Car car)
        {
            if (car is null) throw new ArgumentNullException(nameof(car));

            return new CarTO
            {
                Id = car.Id,
                Chassis = car.Chassis,
                EndDateContract = car.EndDateContract,
                Brand = car.Brand?.ToTransfertObject(),
                Km = car.Km,
                Numberplate = car.Numberplate,
                StartDateContract = car.StartDateContract,
                Year = car.Year,
                VehicleStatus = car.VehicleStatus,
                Technicalcontrols = car.TechnicalControls?.Select(t => t.ToTransfertObject()).ToList(),
                Insurances = car.Insurances?.Select(x => x.ToTransfertObject()).ToList()
            };
        }

        public static Car ToEntity(this CarTO car)
        {
            if (car is null) throw new ArgumentNullException(nameof(car));

            return new Car
            {
                Id = car.Id,
                Chassis = car.Chassis,
                EndDateContract = car.EndDateContract,
                Brand = car.Brand?.ToEntity(),
                Km = car.Km,
                Numberplate = car.Numberplate,
                StartDateContract = car.StartDateContract,
                Year = car.Year,
                VehicleStatus = car.VehicleStatus,
                TechnicalControls = car.Technicalcontrols?.Select(c => c.ToEntity()).ToList(),
                Insurances = car.Insurances?.Select(c => c.ToEntity()).ToList(),
            };
        }
    }
}