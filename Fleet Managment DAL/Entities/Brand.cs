using System;
using System.Collections.Generic;

namespace Fleet_Managment_DAL.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Model> Models { get; set; }
    }
}