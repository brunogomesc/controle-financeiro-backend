﻿using ControleFinanceiro.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {

        new IQueryable<Category> GetAll();

        new Task<Category> GetById(int id);

        IQueryable<Category> FilterCategories(string nameCategory);

    }
}
