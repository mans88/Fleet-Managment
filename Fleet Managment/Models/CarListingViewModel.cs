using FleetManagment.Shared.Enumeration;
using FleetManagment.Shared.TransfertObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fleet_Managment.Models
{
    public class CarListingViewModel
    {
        public int IdCar { get; set; }
        public string Numberplate { get; set; }
        public DateTime Year { get; set; }
        public string Chassis { get; set; }
        public string VehicleStatus { get; set; }
        public DateTime StartDateContract { get; set; }
        public DateTime EndDateContract { get; set; }
        public int Km { get; set; }
        public ModelTO Model { get; set; }
        public Fuel Fuel { get; set; }
    }
}