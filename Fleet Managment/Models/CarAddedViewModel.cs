using System;

namespace Fleet_Managment.Models
{
    public class CarAddedViewModel
    {
        public string Numberplate { get; set; }
        public DateTime Year { get; set; }
        public string Chassis { get; set; }
        public string VehicleStatus { get; set; }
        public DateTime StartDateContract { get; set; }
        public DateTime EndDateContract { get; set; }
        public int Km { get; set; }
        public int idBrand { get; set; }
        public int idModel { get; set; }
        public int idFuel { get; set; }
    }
}