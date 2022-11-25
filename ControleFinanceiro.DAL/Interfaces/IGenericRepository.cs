﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {

        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        Task<TEntity> GetById(string id);

        Task Insert(TEntity entity);

        Task Insert(List<TEntity> entities);

        Task Update(TEntity entity);

        Task Delete(string id);

        Task Delete(int id);

    }
}
