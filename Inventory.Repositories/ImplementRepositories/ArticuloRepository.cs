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
    public class ArticuloRepository : IArticuloRepository
    {

        private readonly SqlServerContext _context;

        public ArticuloRepository()
        {
            _context = new SqlServerContext();
        }
        public async Task<Tuple<Articulo, bool>> AddAsync(Articulo entity)
        {
            try
            {
                var result = _context.Articulo.Add(entity);
                await _context.SaveChangesAsync();

                return Tuple.Create(result.Entity, true);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<List<Articulo>> GetAllAsync()
        {
            try
            {
                return await _context.Articulo.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Articulo> GetBtIdAsync(int id)
        {
            try
            {
                return await _context.Articulo.FindAsync(id);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<List<Articulo>> GetByFilterAsync(Expression<Func<Articulo, bool>> expressionFilter = null)
        {
            try
            {
                return await _context.Articulo.Where<Articulo>(expressionFilter).ToListAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Articulo entity)
        {
            try
            {
                var result = _context.Articulo.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
