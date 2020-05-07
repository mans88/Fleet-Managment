using System;
using System.Collections.Generic;

namespace Fleet_Managment_DAL.Entities
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}