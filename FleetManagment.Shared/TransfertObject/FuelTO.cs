﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FleetManagment.Shared.TransfertObject
{
    public class FuelTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ModelTO> Models;
    }
}