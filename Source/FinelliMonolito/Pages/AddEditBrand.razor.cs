using FinelliApplicationMonolito.Services;
using FinelliDomainMonolito;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace FinelliMonolito.Pages
{
    public class AddEditBrandModel : ComponentBase
    {
        [Inject]
        protected IBrandService Service { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected string Title = "Adicionar";

        public Brand brand = new Brand();

        protected override async Task OnParametersSetAsync()
        {
            if (!String.IsNullOrWhiteSpace(Id))
            {
                Title = "Editar";
                brand = await Service.GetByIdAsync(Id);
            }
        }

        protected async Task Save()
        {
            if (!String.IsNullOrWhiteSpace(brand.Id))
            {
                var brandExist = Service.GetByIdAsync(brand.Id);
                if (brandExist.Result != null)
                {
                    brandExist.Result.Decription = brand.Decription;
                    brandExist.Result.Name = brand.Name;
                    await Task.Run(() =>
                    {
                        Service.UpdateItem(brandExist.Result);
                    });
                }
                else
                {
                    await Task.Run(() =>
                    {
                        Service.AddItem(brand);
                    });
                }
            }
            Refresh();
        }

        public void Refresh()
        {
            UrlNavigationManager.NavigateTo("/fetchbrand");
        }
    }
}