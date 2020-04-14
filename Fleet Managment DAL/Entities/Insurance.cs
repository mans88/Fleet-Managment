using System;
using System.Collections.Generic;

namespace Fleet_Managment_DAL.Entities
{
    public class Insurance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Car Car { get; set; }
    }
}