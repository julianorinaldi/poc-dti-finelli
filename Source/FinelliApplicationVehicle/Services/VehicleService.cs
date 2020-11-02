using FinelliDomainVehicle;
using FinelliDomainVehicle.Repositories;
using FinelliDomainVehicle.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinelliApplicationVehicle.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public void AddItem(Vehicle vehicle)
        {
            if (String.IsNullOrWhiteSpace(vehicle?.Chassi))
                throw new Exception("id não encontrado!");

            if (vehicle?.Chassi.Length != 17)
                throw new Exception("Chassi incorreto, deverá possuir 17 caracteres");

            var get = _vehicleRepository.FindByIdAsync(vehicle.Chassi);
            if (!String.IsNullOrWhiteSpace(get.Result?.Chassi))
                throw new Exception($"Veículo já existente, não é possível adicionar mesmo chassi {get.Result?.Chassi} duplicado! Dois Veículos são considerados clonados se os seus chassi forem iguais.");

            _vehicleRepository.AddAync(vehicle);
        }

        public void DeleteItem(string chassi)
        {
            var get = _vehicleRepository.FindByIdAsync(chassi);
            if (String.IsNullOrWhiteSpace(get.Result?.Chassi))
                throw new Exception($"Veículo não existente, não é possível deletar veículo com chassi {chassi}!");

            _vehicleRepository.Remove(get.Result);
        }

        public async Task<Vehicle> GetAsync(string chassi)
        {
            return await _vehicleRepository.FindByIdAsync(chassi);
        }

        public async Task<IEnumerable<Vehicle>> ListAsync()
        {
            return await _vehicleRepository.ListAsync();
        }

        public void UpdateItem(Vehicle vehicle)
        {
            if (String.IsNullOrWhiteSpace(vehicle?.Chassi))
                throw new Exception("Veículo incompleto, sem chassi!");

            var get = _vehicleRepository.FindByIdAsync(vehicle.Chassi);
            if (!String.IsNullOrWhiteSpace(get.Result?.Chassi))
            {
                var existsItem = get.Result;
                existsItem.VehicleName = vehicle.VehicleName;
                _vehicleRepository.Update(existsItem);
            }
            else
                throw new Exception($"Veículo não encontrado com chassi {vehicle?.Chassi}!");
        }
    }
}