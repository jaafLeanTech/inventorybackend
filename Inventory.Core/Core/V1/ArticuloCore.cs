using AutoMapper;
using Inventory.Contracts.Repository;
using Inventory.Core.Core.Handlers;
using Inventory.DataAccess.Context;
using Inventory.Entities.DTOs;
using Inventory.Entities.Entities;
using Inventory.Entities.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Inventory.Core.Core.V1
{
    public class ArticuloCore
    {
        private readonly IArticuloRepository _context;
        private readonly ILogger<Articulo> _logger;
        private readonly ErrorHandler<Articulo> _errorHandler;
        private readonly IMapper _mapper;

        public ArticuloCore(ILogger<Articulo> logger, IMapper mapper, IArticuloRepository context)
        {
            _logger = logger;
            _errorHandler = new ErrorHandler<Articulo>(logger);
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseService<List<Articulo>>> GetArticulosAsync()
        {
            try
            {
                var response = await _context.GetAllAsync();

                return new ResponseService<List<Articulo>>(false, response.Count == 0 ? "No records found" : $"{response.Count} records found", System.Net.HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {

                return _errorHandler.Error(ex, "GetClientAsync", new List<Articulo>());
            }
            
        }

        public async Task<ResponseService<Articulo>> CreateArticulosAsync(ArticuloCreateDto entity)
        {
            Articulo newArticulo = new();
            newArticulo = _mapper.Map<Articulo>(entity);

            try
            {
                var newArticuloCreated = await _context.AddAsync(newArticulo);
                                
                return new ResponseService<Articulo>(false, "Article was successfully created", HttpStatusCode.Created, newArticuloCreated.Item1);
            }
            catch (Exception ex)
            {
                return new ResponseService<Articulo>(true, $"New Article not created {ex.Message}", HttpStatusCode.InternalServerError, new Articulo());
            }
        }    

        public async Task<ResponseService<bool>> UpdateArticuloAsync(Articulo articuloToUpdated)
        {
            try
            {
                var result = await _context.UpdateAsync(articuloToUpdated);
                return new ResponseService<bool>(false, result == true ? "Record updated !!" : "Record not updated", HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "UpdateArticuloAsync", false);
            }
        }
    }
}
