using Fleet_Managment_DAL.Entities;
using FleetManagment.Shared.TransfertObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace FleetManagment.DAL.Test
{
    public static class Tools
    {
        public static CarTO InitCar()
        {
            List<TechnicalControlTO> tech = new List<TechnicalControlTO>();
            List<InsuranceTO> la = new List<InsuranceTO>();
            la.Add(InitInsurance());
            tech.Add(InitTechnical());
            CarTO car = new CarTO
            {
                Chassis = "1d3zfr57ze8f898zefmap8",
                StartDateContract = DateTime.Now,
                EndDateContract = DateTime.Now.AddDays(231),
                Km = 12351,
                Numberplate = "1-DQE-297",
                VehicleStatus = "new",
                Year = DateTime.Now,
                IdBrandNavigation = InitBrand(),
                Insurances = la,
                Technicalcontrols = tech
            };
            return car;
        }

        public static FuelTO InitFuel()
        {
            FuelTO fuel = new FuelTO
            {
                Name = "diesel",
            };

            return fuel;
        }

        public static BrandTO InitBrand()
        {
            List<CarTO> lc = new List<CarTO>();
            List<ModelTO> lm = new List<ModelTO>();

            lc.Add(InitCar());
            lm.Add(InitModel());

            BrandTO brand = new BrandTO
            {
                Name = "VW",
                Cars = lc,
                Models = lm,
            };

            return brand;
        }

        public static ModelTO InitModel()
        {
            List<FuelTO> lf = new List<FuelTO>();
            lf.Add(InitFuel());

            ModelTO mod = new ModelTO
            {
                Brand = InitBrand(),
                Name = "polo",
                Fules = lf,
            };

            return mod;
        }

        public static InsuranceTO InitInsurance()
        {
            InsuranceTO insurance = new InsuranceTO
            {
                Car = InitCar(),
                Name = "AG",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(365)
            };
            return insurance;
        }

        public static TechnicalControlTO InitTechnical()
        {
            TechnicalControlTO technic = new TechnicalControlTO
            {
                Comment = "no comment",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(365),
                Car = InitCar()
            };

            return technic;
        }
    }
}