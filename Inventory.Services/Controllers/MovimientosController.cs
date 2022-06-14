using AutoMapper;
using Inventory.Contracts.Repository;
using Inventory.Core.Core.V1;
using Inventory.Entities.DTOs;
using Inventory.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private readonly MovimientoCore _movimientoCore;

        public MovimientosController(ILogger<Movimiento> logger, IMapper mapper, IMovimientoRepository context)
        {
            _movimientoCore = new MovimientoCore(logger, mapper, context);
        }

        // GET: api/<MovimientosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movimiento>>> Get()
        {
            var result = await _movimientoCore.GetMovimientoAsync();
            return StatusCode((int)result.StatusHttp, result);
        }

        // POST api/<MovimientosController>
        [HttpPost]
        public async Task<ActionResult<Movimiento>> Post([FromBody] MovimientoCreateDto movimiento)
        {
            var response = await _movimientoCore.CreateMovimientoAsync(movimiento);
            return StatusCode((int)response.StatusHttp, response);

        }

        // PUT api/<MovimientosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put([FromBody] Movimiento movimiento)
        {
            var response = await _movimientoCore.UpdateMovimientoAsync(movimiento);
            return StatusCode((int)response.StatusHttp, response)
;        }

        // DELETE api/<MovimientosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
