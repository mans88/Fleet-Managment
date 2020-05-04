using System;

namespace Fleet_Managment_BLL.Domain
{
    public class InsuranceDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CarDomain Car { get; set; }
    }
}