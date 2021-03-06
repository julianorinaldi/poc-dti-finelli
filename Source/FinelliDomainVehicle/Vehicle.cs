﻿using FinelliDomainCore.Entities;

namespace FinelliDomainVehicle
{
    public class Vehicle : EntityBase
    {
        public string Chassi { get; set; }
        public string VehicleName { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public string Color { get; set; }
    }
}