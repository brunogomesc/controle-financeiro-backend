﻿using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {

        private readonly Context _context;

        public CategoryRepository(Context context) : base(context)
        {

            _context = context;

        }

        public IQueryable<Category> FilterCategories(string nameCategory)
        {
            try
            {

               var entity = _context.Categories.Include(c => c.Type).Where(c => c.Name.Contains(nameCategory));
                return entity;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public new IQueryable<Category> GetAll()
        {

            try
            {

                return _context.Categories.Include(c => c.Type);

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public new async Task<Category> GetById(int id)
        {

            try
            {

                var entity = await _context.Categories.Include(c => c.Type).FirstOrDefaultAsync(c => c.CategoryId == id);
                return entity;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
