using System.Collections.Generic;

namespace Fleet_Managment_BLL.Domain
{
    public class ModelDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BrandDomain Brand { get; set; }
        public ICollection<FuelDomain> Fuels { get; set; }
    }
}