using FinelliDomainVehicle;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Net;
using Newtonsoft.Json;

namespace FinelliMonolito.Pages
{
    public class AddEditVehicleModel : ComponentBase
    {
        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }

        private string addressApi = "http://localhost:8889";
        private string apiSpecialist = "api/vehicle";

        [Parameter]
        public string Id { get; set; }

        protected string Title = "Adicionar";

        public Vehicle vehicle = new Vehicle();

        protected override async Task OnParametersSetAsync()
        {
            if (!String.IsNullOrWhiteSpace(Id))
            {
                Title = "Editar";
                var response = await Http.GetAsync($"{addressApi}/{apiSpecialist}/{Id}");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    vehicle = JsonConvert.DeserializeObject<Vehicle>(jsonString);
                }
                else
                    vehicle = null;
            }
        }

        protected async Task Save()
        {
            if (!String.IsNullOrWhiteSpace(vehicle.Id))
            {
                var response = await Http.GetAsync($"{addressApi}/{apiSpecialist}/{vehicle.Id}");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var vehicleExist = JsonConvert.DeserializeObject<Vehicle>(jsonString);
                    if (vehicleExist != null)
                    {
                        vehicleExist.VehicleName = vehicle.VehicleName;
                        vehicleExist.Chassi = vehicle.Chassi;
                        vehicleExist.Color = vehicle.Color;
                        vehicleExist.Description = vehicle.Description;
                        vehicleExist.Capacity = vehicle.Capacity;

                        await Http.PutAsJsonAsync<Vehicle>($"{addressApi}/{apiSpecialist}/" + vehicleExist.Id, vehicleExist);
                    }
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    await Http.PostAsJsonAsync<Vehicle>($"{addressApi}/{apiSpecialist}", vehicle);
                }
            }
            Refresh();
        }

        public void Refresh()
        {
            UrlNavigationManager.NavigateTo("/fetchvehicle");
        }
    }
}