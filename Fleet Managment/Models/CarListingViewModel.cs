using FleetManagment.Shared.Enumeration;
using FleetManagment.Shared.TransfertObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fleet_Managment.Models
{
    public class CarListingViewModel
    {
        public int IdCar { get; set; }
        public string Numberplate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Year { get; set; }

        public string Chassis { get; set; }
        public string VehicleStatus { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDateContract { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDateContract { get; set; }

        public int Km { get; set; }
        public ModelTO Model { get; set; }
        public Fuel Fuel { get; set; }
    }
}