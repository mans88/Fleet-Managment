using System.Collections.Generic;

namespace Fleet_Managment_BLL.Domain
{
    public class Fuel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Model> Models;
    }
}