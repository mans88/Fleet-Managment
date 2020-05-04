using System.Collections.Generic;

namespace Fleet_Managment_BLL.Domain
{
    public class BrandDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CarDomain> Cars { get; set; }
        public ICollection<ModelDomain> Models { get; set; }
    }
}