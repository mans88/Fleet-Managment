using System;

namespace FleetManagment.Shared.TransfertObject
{
    public class InsuranceTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CarTO Car { get; set; }
    }
}