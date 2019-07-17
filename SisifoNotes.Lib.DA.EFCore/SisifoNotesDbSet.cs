using Microsoft.EntityFrameworkCore;
using SisifoNotes.Lib.Core;
using SisifoNotes.Lib.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SisifoNotes.Lib.DA.EFCore
{
    public abstract class SisifoNotesDbSet<T> : IDbSet<T> where T : Entity
    {
        internal SisifoNotesContext DbContext { get; set; }

        internal DbSet<T> DbSet { get; set; }

        public T Add(T entity)
        {
            DbSet.Add(entity);
            DbContext.SaveChanges();

            return entity;
        }

        public bool Delete(Guid id)
        {
            var entityToRemove = DbSet.Find(id);
            if (entityToRemove == null)
                return false;

            DbSet.Remove(entityToRemove);
            DbContext.SaveChanges();
            return true;
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T Update (T entity)
        {
            DbSet.Update(entity);
            DbContext.SaveChanges();

            return entity;
        }
    }
}
