using ControleFinanceiro.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private readonly Context _context;

        public GenericRepository(Context context)
        {

            _context = context;

        }

        public async Task Delete(string id)
        {

            try
            {

                var entity = await GetById(id);
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task Delete(int id)
        {
            try
            {

                var entity = await GetById(id);
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {

                return _context.Set<TEntity>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> GetById(int id)
        {
            try
            {

                var entity = await _context.Set<TEntity>().FindAsync(id);
                return entity;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<TEntity> GetById(string id)
        {
            try
            {

                var entity = await _context.Set<TEntity>().FindAsync(id);
                return entity;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Insert(TEntity entity)
        {
            try
            {

                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Insert(List<TEntity> entities)
        {
            try
            {

                await _context.AddRangeAsync(entities);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(TEntity entity)
        {
            try
            {

                var record = _context.Set<TEntity>().Update(entity);
                record.State = EntityState.Modified;
                await _context.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
