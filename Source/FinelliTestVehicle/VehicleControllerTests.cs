using AutoMapper;
using FinelliApplicationVehicle.Services;
using FinelliDomainVehicle;
using FinelliDomainVehicle.Repositories;
using FinelliDomainVehicle.Services;
using FinelliServiceCRUDVehicle.Controllers;
using FinelliServiceCRUDVehicle.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FinelliTestVehicle
{
    public class VehicleControllerTests
    {
        private readonly Mock<IVehicleService> _vechicleServiceMock = new Mock<IVehicleService>();
        private readonly Mock<IVehicleRepository> _vehicleRepositoryMock = new Mock<IVehicleRepository>();
        private readonly IMapper _mapper;
        private List<Vehicle> _mockVehicle;

        public VehicleControllerTests()
        {
            _mapper = AutoMapperTest.GetMapper();

            _mockVehicle = new List<Vehicle>()
            {
                new Vehicle()
                {
                    Chassi = "12345",
                    VehicleName = "Veículo 1",
                },
                new Vehicle()
                {
                    Chassi = "54321",
                    VehicleName = "Veículo 2",
                }
            };
        }

        [Fact]
        public async Task Retrieve_GetAll_Sucess()
        {
            var controller = new VehicleController(_vechicleServiceMock.Object, _mapper);

            _vechicleServiceMock.Setup<Task<IEnumerable<Vehicle>>>(x => x.ListAsync())
                    .Returns(Task.FromResult<IEnumerable<Vehicle>>(_mockVehicle));

            var response = await controller.Get();

            Assert.NotNull(response);

            var resultOK = response.Result as OkObjectResult;

            Assert.NotNull(resultOK);

            Assert.Equal(200, resultOK.StatusCode);

            IList<VehicleModel> enumerable = (resultOK.Value as IList<VehicleModel>);
            Assert.Equal(_mockVehicle.Count, enumerable.Count);
        }

        [Fact]
        public async Task Retrieve_GetWithId_Sucess()
        {
            var controller = new VehicleController(_vechicleServiceMock.Object, _mapper);

            string chassi = "12345";

            _vechicleServiceMock.Setup<Task<Vehicle>>(x => x.GetAsync(chassi))
                    .Returns(Task.FromResult<Vehicle>(_mockVehicle.FirstOrDefault(x => x.Chassi == chassi)));

            var response = await controller.Get(chassi);
            var resultOK = response as OkObjectResult;

            Assert.NotNull(resultOK);

            Assert.Equal(200, resultOK.StatusCode);

            VehicleModel objResult = resultOK.Value as VehicleModel;
            Assert.Equal(chassi, objResult.Chassi);
        }

        [Fact]
        public void Post_CreateNew_Sucess()
        {
            var controller = new VehicleController(_vechicleServiceMock.Object, _mapper);

            var model = new VehicleModel()
            {
                Chassi = "99999",
                VehicleName = "Novo Veículo"
            };

            _vehicleRepositoryMock.Setup<Task<Vehicle>>(x => x.FindByIdAsync(model.Chassi))
                    .Returns(Task.FromResult<Vehicle>(_mockVehicle.FirstOrDefault(x => x.Chassi == model.Chassi)));

            var entity = _mapper.Map<Vehicle>(model);

            var response = controller.Post(model);
            var resultOK = response as OkResult;

            Assert.NotNull(resultOK);

            Assert.Equal(200, resultOK.StatusCode);
        }

        [Fact]
        public void Post_CreateNew_Error_Duplicate_BadRequest()
        {
            var controller = new VehicleController(new VehicleService(_vehicleRepositoryMock.Object), _mapper);

            var model = new VehicleModel()
            {
                Chassi = "12345",
                VehicleName = "Novo Veículo"
            };

            _vehicleRepositoryMock.Setup<Task<Vehicle>>(x => x.FindByIdAsync(model.Chassi))
                    .Returns(Task.FromResult<Vehicle>(_mockVehicle.FirstOrDefault(x => x.Chassi == model.Chassi)));

            var response = controller.Post(model);
            var result = response as BadRequestObjectResult;

            Assert.NotNull(result);

            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void Put_Update_Error_BadRequest()
        {
            var controller = new VehicleController(new VehicleService(_vehicleRepositoryMock.Object), _mapper);

            string chassi = "123456";

            var model = new VehicleModel()
            {
                Chassi = "12345",
                VehicleName = "Veículo Alterado!"
            };

            var response = controller.Put(chassi, model);
            var result = response as BadRequestObjectResult;

            Assert.NotNull(result);

            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void Put_Update_Error_NotFound_BadRequest()
        {
            var controller = new VehicleController(new VehicleService(_vehicleRepositoryMock.Object), _mapper);

            var model = new VehicleModel()
            {
                Chassi = "123456",
                VehicleName = "Veículo Alterado!"
            };

            _vehicleRepositoryMock.Setup<Task<Vehicle>>(x => x.FindByIdAsync(model.Chassi))
                    .Returns(Task.FromResult<Vehicle>(_mockVehicle.FirstOrDefault(x => x.Chassi == model.Chassi)));

            var response = controller.Put(model.Chassi, model);
            var result = response as BadRequestObjectResult;

            Assert.NotNull(result);

            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void Put_Update_Sucess()
        {
            var controller = new VehicleController(new VehicleService(_vehicleRepositoryMock.Object), _mapper);

            var model = new VehicleModel()
            {
                Chassi = "12345",
                VehicleName = "Veículo Alterado!"
            };

            _vehicleRepositoryMock.Setup<Task<Vehicle>>(x => x.FindByIdAsync(model.Chassi))
                    .Returns(Task.FromResult<Vehicle>(_mockVehicle.FirstOrDefault(x => x.Chassi == model.Chassi)));

            var response = controller.Put(model.Chassi, model);
            var result = response as OkResult;

            Assert.NotNull(result);

            Assert.Equal(200, result.StatusCode);

            var modelAltered = _mockVehicle.FirstOrDefault(x => x.Chassi == model.Chassi);

            Assert.Equal(model.VehicleName, modelAltered.VehicleName);
        }

        [Fact]
        public void Delete_Sucess()
        {
            var controller = new VehicleController(new VehicleService(_vehicleRepositoryMock.Object), _mapper);

            string chassi = "12345";

            _vehicleRepositoryMock.Setup<Task<Vehicle>>(x => x.FindByIdAsync(chassi))
                    .Returns(Task.FromResult<Vehicle>(_mockVehicle.FirstOrDefault(x => x.Chassi == chassi)));

            var response = controller.Delete(chassi);
            var result = response as OkResult;

            Assert.NotNull(result);

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void Delete_NotFound_BadRequest()
        {
            var controller = new VehicleController(new VehicleService(_vehicleRepositoryMock.Object), _mapper);

            string chassi = "9999";

            _vehicleRepositoryMock.Setup<Task<Vehicle>>(x => x.FindByIdAsync(chassi))
                    .Returns(Task.FromResult<Vehicle>(_mockVehicle.FirstOrDefault(x => x.Chassi == chassi)));

            var response = controller.Delete(chassi);
            var result = response as BadRequestObjectResult;

            Assert.NotNull(result);

            Assert.Equal(400, result.StatusCode);
        }
    }
}