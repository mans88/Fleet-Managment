using System;

namespace Fleet_Managment_BLL.Domain
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