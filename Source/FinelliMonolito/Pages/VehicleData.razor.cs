using FinelliDomainVehicle;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace FinelliMonolito.Pages
{
    public class VehicleDataModel : ComponentBase
    {
        [Inject]
        protected HttpClient Http { get; set; }

        private string addressApi = "http://localhost:8889";
        private string apiSpecialist = "api/vehicle";

        protected List<Vehicle> vehicleList = new List<Vehicle>();
        protected List<Vehicle> searchData = new List<Vehicle>();
        protected Vehicle vehicle = new Vehicle();
        protected string SearchString { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetAll();
        }

        protected async Task GetAll()
        {
            vehicleList = await Http.GetFromJsonAsync<List<Vehicle>>($"{addressApi}/{apiSpecialist}");
            searchData = vehicleList;
        }

        protected void Filter()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                vehicleList = searchData.Where(x => x.VehicleName.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
            else
            {
                vehicleList = searchData;
            }
        }

        protected void DeleteConfirm(string id)
        {
            vehicle = vehicleList.FirstOrDefault(x => x.Id == id);
        }

        protected async Task Delete(string id)
        {
            await Http.DeleteAsync($"{addressApi}/{apiSpecialist}/" + id);
            await GetAll();
        }
    }
}