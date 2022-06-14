using AutoMapper;
using Inventory.Contracts.Repository;
using Inventory.Core.Core.Handlers;
using Inventory.Entities.DTOs;
using Inventory.Entities.Entities;
using Inventory.Entities.Utils;
using Inventory.Repositories.ImplementRepositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Core.V1
{
    public class MovimientoCore
    {
        private readonly IMovimientoRepository _context;
        private readonly ILogger<Movimiento> _logger;
        private readonly ErrorHandler<Movimiento> _errorHandler;
        private readonly IMapper _mapper;

        public MovimientoCore(ILogger<Movimiento> logger, IMapper mapper, IMovimientoRepository context)
        {
            _logger = logger;
            _errorHandler = new ErrorHandler<Movimiento>(logger);
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseService<List<Movimiento>>> GetMovimientoAsync()
        {
            try
            {
                var response = await _context.GetAllAsync();

                return new ResponseService<List<Movimiento>>(false, response.Count == 0 ? "No records found" : $"{response.Count} record found", System.Net.HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetClientAsync", new List<Movimiento>());
            }
        }

        public async Task<ResponseService<Movimiento>> CreateMovimientoAsync(MovimientoCreateDto entity)
        {
            Movimiento newMovimiento = new();
            newMovimiento = _mapper.Map<Movimiento>(entity);

            try
            {
                var newMovimientoCreated = await _context.AddAsync(newMovimiento);

                return new ResponseService<Movimiento>(false, "Article was successfylly created", HttpStatusCode.Created, newMovimientoCreated.Item1);
            }
            catch (Exception ex)
            {
                return new ResponseService<Movimiento>(true, $"New Article not created {ex.Message}", HttpStatusCode.InternalServerError, new Movimiento());
            }
        }

        public async Task<ResponseService<bool>> UpdateMovimientoAsync(Movimiento movimientoToUpdated)
        {
            try
            {
                var result = await _context.UpdateAsync(movimientoToUpdated);

                return new ResponseService<bool>(false, result == true ? "Record update!!" : "Record not updated", HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "UpdateMovimientoAsync", false);
            }
        }
    }
}
