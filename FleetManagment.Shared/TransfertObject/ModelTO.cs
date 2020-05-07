using System.Collections.Generic;

namespace FleetManagment.Shared.TransfertObject
{
    public class ModelTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BrandTO Brand { get; set; }
        public ICollection<CarTO> Cars { get; set; }
    }
}