using System.Collections.Generic;

namespace Fleet_Managment_BLL.Domain
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}