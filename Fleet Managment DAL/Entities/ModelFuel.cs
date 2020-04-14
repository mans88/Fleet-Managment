using System;
using System.Collections.Generic;

namespace Fleet_Managment_DAL.Entities
{
    public class ModelFuel
    {
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public int FuelId { get; set; }
        public Fuel Fuel { get; set; }
    }
}