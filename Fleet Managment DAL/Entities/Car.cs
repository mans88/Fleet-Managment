using FleetManagment.Shared.Enumeration;
using System;
using System.Collections.Generic;

namespace Fleet_Managment_DAL.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Numberplate { get; set; }
        public DateTime Year { get; set; }
        public string Chassis { get; set; }
        public string VehicleStatus { get; set; }
        public DateTime StartDateContract { get; set; }
        public DateTime EndDateContract { get; set; }
        public int Km { get; set; }
        public Model Model { get; set; }
        public Fuel Fuel { get; set; }
        public ICollection<Insurance> Insurances { get; set; }
        public ICollection<TechnicalControl> TechnicalControls { get; set; }
    }
}