using FinelliApplicationMonolito.Services;
using FinelliDomainMonolito;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinelliMonolito.Pages
{
    public class BrandDataModel : ComponentBase
    {
        [Inject]
        protected IBrandService Service { get; set; }

        protected List<Brand> brandList = new List<Brand>();
        protected List<Brand> searchData = new List<Brand>();
        protected Brand brand = new Brand();
        protected string SearchString { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetAll();
        }

        protected async Task GetAll()
        {
            brandList = (List<Brand>)await Service.ListAsync();
            searchData = brandList;
        }

        protected void Filter()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                brandList = searchData.Where(x => x.Name.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
            else
            {
                brandList = searchData;
            }
        }

        protected void DeleteConfirm(string id)
        {
            brand = brandList.FirstOrDefault(x => x.Id == id);
        }

        protected async Task Delete(string id)
        {
            await Task.Run(() =>
            {
                Service.DeleteItem(id);
            });
            await GetAll();
        }
    }
}