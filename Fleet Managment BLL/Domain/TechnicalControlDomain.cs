using System;

namespace Fleet_Managment_BLL.Domain
{
    public class TechnicalControlDomain
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; }
        public CarDomain Car { get; set; }
    }
}