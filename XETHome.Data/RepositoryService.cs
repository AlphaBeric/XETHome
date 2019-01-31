﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XETHome.Models;

namespace XETHome.Data
{
    public class RepositoryService<TEntity> : IRepositoryService<TEntity> where TEntity : class
    {
        private ApplicationDbContext _context;


        private IDbSet<TEntity> Entities
        {
            get { return this._context.Set<TEntity>(); }
        }

        public RepositoryService(ApplicationDbContext context)
        {
            this._context = context;

        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities.AsQueryable();
        }

        public TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(TEntity entity)
        {
            Entities.Add(entity);
            this._context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this._context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
            this._context.SaveChanges();
        }

        public IQueryable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            return Entities.Where(predicate).AsQueryable();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._context != null)
                {
                    this._context.Dispose();
                    this._context = null;
                }
            }
        }
    }

}
