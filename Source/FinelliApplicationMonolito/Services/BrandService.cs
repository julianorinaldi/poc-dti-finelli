using FinelliApplicationMonolito.Repositories;
using FinelliDomain;
using FinelliDomain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinelliApplicationMonolito.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;

        public BrandService(IBrandRepository repository)
        {
            _repository = repository;
        }

        public void AddItem(Brand brand)
        {
            if (String.IsNullOrWhiteSpace(brand?.Name))
                throw new Exception("Marca não encontrado!");

            _repository.AddAync(brand);
        }

        public void DeleteItem(string name)
        {
            var get = _repository.FindByIdAsync(name);
            if (String.IsNullOrWhiteSpace(get.Result?.Name))
                throw new Exception($"Marca não existente, não é possível deletar {name}!");

            _repository.Remove(get.Result);
        }

        public async Task<Brand> GetAsync(string name)
        {
            return await _repository.FindByIdAsync(name);
        }

        public async Task<IEnumerable<Brand>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public void UpdateItem(Brand brand)
        {
            if (String.IsNullOrWhiteSpace(brand?.Name))
                throw new Exception("Marca incompleto!");

            var get = _repository.FindByIdAsync(brand.Name);
            if (!String.IsNullOrWhiteSpace(get.Result?.Name))
            {
                var existsItem = get.Result;
                existsItem.Decription = brand.Decription;
                _repository.Update(existsItem);
            }
            else
                throw new Exception($"Marca não encontrado com {brand?.Name}!");
        }
    }
}