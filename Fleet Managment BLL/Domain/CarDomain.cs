using System;
using System.Collections.Generic;

namespace Fleet_Managment_BLL.Domain
{
    public class CarDomain
    {
        public int Id { get; set; }
        public string Numberplate { get; set; }
        public DateTime Year { get; set; }
        public string Chassis { get; set; }
        public string VehicleStatus { get; set; }
        public DateTime StartDateContract { get; set; }
        public DateTime EndDateContract { get; set; }
        public int Km { get; set; }
        public BrandDomain Brand { get; set; }
        public ICollection<InsuranceDomain> Insurances { get; set; }
        public ICollection<TechnicalControlDomain> Technicalcontrols { get; set; }
    }
}