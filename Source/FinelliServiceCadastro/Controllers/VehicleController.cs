using AutoMapper;
using FinelliDomain;
using FinelliDomain.Services;
using FinelliServiceCadastro.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinelliServiceCadastro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        private readonly IMapper _mapper;

        public VehicleController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<VehicleModel>> Get()
        {
            var entities = await _vehicleService.ListAsync();

            var models = _mapper.Map<IEnumerable<VehicleModel>>(entities);

            return Ok(models);
        }

        [HttpGet("{sku}")]
        public async Task<ActionResult> Get(string chassi)
        {
            var entity = await _vehicleService.GetAsync(chassi);
            if (entity == null)
                return NotFound();

            var model = _mapper.Map<VehicleModel>(entity);
            return Ok(model);
        }

        [HttpPost]
        public ActionResult Post([FromBody] VehicleModel value)
        {
            try
            {
                var entity = _mapper.Map<Vehicle>(value);
                _vehicleService.AddItem(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPut("{chassi}")]
        public ActionResult Put(string chassi, [FromBody] VehicleModel value)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(chassi) || chassi != value?.Chassi)
                    return BadRequest("Chassi incorreto!");

                var entity = _mapper.Map<Vehicle>(value);
                _vehicleService.UpdateItem(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpDelete("{chassi}")]
        public ActionResult Delete(string chassi)
        {
            try
            {
                _vehicleService.DeleteItem(chassi);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}