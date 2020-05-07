using System.Collections.Generic;

namespace FleetManagment.Shared.TransfertObject
{
    public class BrandTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ModelTO> Models { get; set; }
    }
}