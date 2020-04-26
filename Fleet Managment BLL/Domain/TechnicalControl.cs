using System;

namespace Fleet_Managment_BLL.Domain
{
    public class TechnicalControl
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; }
        public Car Car { get; set; }
    }
}