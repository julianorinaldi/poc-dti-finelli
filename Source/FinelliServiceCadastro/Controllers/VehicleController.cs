using AutoMapper;
using FinelliDomainVehicle;
using FinelliDomainVehicle.Services;
using FinelliServiceCRUDVehicle.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinelliServiceCRUDVehicle.Controllers
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

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var entity = await _vehicleService.GetAsync(id);
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

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] VehicleModel value)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(id))
                    return BadRequest("Id é obrigatório!");

                var entity = _mapper.Map<Vehicle>(value);
                _vehicleService.UpdateItem(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                _vehicleService.DeleteItem(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}