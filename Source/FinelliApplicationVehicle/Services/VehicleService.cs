﻿using FinelliDomainVehicle;
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
            if (String.IsNullOrWhiteSpace(vehicle?.Id))
                throw new Exception("Id não encontrado!");

            if (vehicle?.Chassi.Length != 17)
                throw new Exception("Chassi incorreto, deverá possuir 17 caracteres");

            var get = _vehicleRepository.FindByIdAsync(vehicle.Chassi);
            if (!String.IsNullOrWhiteSpace(get.Result?.Chassi))
                throw new Exception($"Veículo já existente, não é possível adicionar mesmo chassi {get.Result?.Chassi} duplicado! Dois Veículos são considerados clonados se os seus chassi forem iguais.");

            _vehicleRepository.AddAync(vehicle);
        }

        public void DeleteItem(string id)
        {
            var get = _vehicleRepository.FindByIdAsync(id);
            if (String.IsNullOrWhiteSpace(get.Result?.Id))
                throw new Exception($"Veículo não existente, não é possível deletar veículo com chassi {id}!");

            _vehicleRepository.Remove(get.Result);
        }

        public async Task<Vehicle> GetAsync(string id)
        {
            return await _vehicleRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Vehicle>> ListAsync()
        {
            return await _vehicleRepository.ListAsync();
        }

        public void UpdateItem(Vehicle vehicle)
        {
            if (String.IsNullOrWhiteSpace(vehicle?.Chassi))
                throw new Exception("Veículo incompleto, sem chassi!");

            var get = _vehicleRepository.FindByIdAsync(vehicle.Id);
            if (!String.IsNullOrWhiteSpace(get.Result?.Id))
            {
                var existsItem = get.Result;
                existsItem.VehicleName = vehicle.VehicleName;
                existsItem.Description = vehicle.Description;
                existsItem.Color = vehicle.Color;
                existsItem.Capacity = vehicle.Capacity;
                _vehicleRepository.Update(existsItem);
            }
            else
                throw new Exception($"Veículo não encontrado com chassi {vehicle?.Chassi}!");
        }
    }
}