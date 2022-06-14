using Inventory.Contracts.Repository;
using Inventory.DataAccess.Context;
using Inventory.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repositories.ImplementRepositories
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly SqlServerContext _context;

        public MovimientoRepository()
        {
            _context = new SqlServerContext();
        }

        public async Task<Tuple<Movimiento, bool>> AddAsync(Movimiento entity)
        {
            try
            {
                var result = _context.Movimientos.Add(entity);
                await _context.SaveChangesAsync();

                return Tuple.Create(result.Entity, true);

            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<List<Movimiento>> GetAllAsync()
        {
            try
            {
                return await _context.Movimientos.ToListAsync();
            }
            catch
            {
                throw;
            }
            
        }

        public async Task<Movimiento> GetBtIdAsync(int id)
        {
            try
            {
                return await _context.Movimientos.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Movimiento>> GetByFilterAsync(Expression<Func<Movimiento, bool>> expressionFilter = null)
        {
            try
            {
                return await _context.Movimientos.Where<Movimiento>(expressionFilter).ToListAsync();
            }
            catch(Exception)
            { 
                throw; 
            } 
        }

        public async Task<bool> UpdateAsync(Movimiento entity)
        {
            try
            {
                var result = _context.Movimientos.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
