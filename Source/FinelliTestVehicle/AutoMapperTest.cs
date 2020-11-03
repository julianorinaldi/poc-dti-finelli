using AutoMapper;
using FinelliDomainVehicle;
using FinelliServiceCRUDVehicle.Model;

namespace FinelliTestVehicle
{
    public static class AutoMapperTest
    {
        public static IMapper GetMapper()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Vehicle, VehicleModel>();
                cfg.CreateMap<VehicleModel, Vehicle>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }
    }
}