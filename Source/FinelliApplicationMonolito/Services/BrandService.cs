using FinelliApplicationMonolito.Repositories;
using FinelliDomainMonolito;
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

        public async Task<Brand> GetByIdAsync(string id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public async Task<Brand> GetByNameAsync(string name)
        {
            return await _repository.FindByNameAsync(name);
        }

        public async Task<IEnumerable<Brand>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public void UpdateItem(Brand brand)
        {
            if (String.IsNullOrWhiteSpace(brand?.Id))
                throw new Exception("Marca incompleto!");

            var get = _repository.FindByIdAsync(brand.Id);
            if (!String.IsNullOrWhiteSpace(get.Result?.Id))
            {
                var existsItem = get.Result;
                existsItem.Decription = brand.Decription;
                existsItem.Name = brand.Name;
                _repository.Update(existsItem);
            }
            else
                throw new Exception($"Marca não encontrado com {brand?.Id}!");
        }
    }
}