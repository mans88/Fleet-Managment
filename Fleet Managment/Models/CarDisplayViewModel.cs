using FleetManagment.Shared.Enumeration;
using FleetManagment.Shared.TransfertObject;
using System;
using System.Collections.Generic;

namespace Fleet_Managment.Models
{
    public class CarDisplayViewModel
    {
        public string Numberplate { get; set; }
        public DateTime Year { get; set; }
        public string Chassis { get; set; }
        public string VehicleStatus { get; set; }
        public DateTime StartDateContract { get; set; }
        public DateTime EndDateContract { get; set; }
        public int Km { get; set; }
        public List<BrandTO> Brands { get; set; }
        public List<ModelTO> Models { get; set; }
        public Fuel Fuel { get; set; }
    }
}