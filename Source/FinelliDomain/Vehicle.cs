using FinelliDomain.Entities;

namespace FinelliDomain
{
    public class Vehicle : EntityBase
    {
        public string Chassi { get; set; }
        public string VehicleName { get; set; }
        public string Brand { get; set; }
        public int Capacity { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
    }
}