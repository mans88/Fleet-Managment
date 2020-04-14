using System;

namespace FleetManagment.Shared.TransfertObject
{
    public class TechnicalControlTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; }
        public CarTO Car { get; set; }
    }
}