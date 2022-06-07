using AutoMapper;
using Inventory.Contracts.Repository;
using Inventory.Core.Core.V1;
using Inventory.DataAccess.Context;
using Inventory.Entities.DTOs;
using Inventory.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly ArticuloCore _articuloCore;

        public ArticulosController(ILogger<Articulo> logger, IMapper mapper, IArticuloRepository context)
        {
            _articuloCore = new ArticuloCore(logger, mapper, context);
        }

        // GET: api/<ArticuloController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulo>>> Get()
        {
            var result = await _articuloCore.GetArticulosAsync();
            return StatusCode((int)result.StatusHttp, result);
        }

        // GET api/<ArticuloController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ArticuloController>
        [HttpPost]
        public async Task<ActionResult<Articulo>> Post([FromBody] ArticuloCreateDto articulo)
        {
            var response = await _articuloCore.CreateArticulosAsync(articulo);
            return StatusCode((int)response.StatusHttp, response);
        }

        // PUT api/<ArticuloController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] Articulo articulo)
        {
            return await _articuloCore.UpdateArticulosAsync(articulo);
        }

        // DELETE api/<ArticuloController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
