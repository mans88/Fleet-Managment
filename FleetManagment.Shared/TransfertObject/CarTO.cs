using FleetManagment.Shared.Enumeration;
using System;
using System.Collections.Generic;

namespace FleetManagment.Shared.TransfertObject
{
    public class CarTO
    {
        public int Id { get; set; }
        public string Numberplate { get; set; }
        public DateTime Year { get; set; }
        public string Chassis { get; set; }
        public string VehicleStatus { get; set; }
        public DateTime StartDateContract { get; set; }
        public DateTime EndDateContract { get; set; }
        public int Km { get; set; }
        public ModelTO Model { get; set; }
        public Fuel Fuel { get; set; }
        public ICollection<InsuranceTO> Insurances { get; set; }
        public ICollection<TechnicalControlTO> Technicalcontrols { get; set; }
    }
}