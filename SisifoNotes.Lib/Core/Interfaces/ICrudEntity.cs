using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SisifoNotes.Lib.Core.Interfaces
{
    public interface ICrudEntity<T> where T: Entity
    {
        IQueryable<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        bool Delete(Guid id);
    }
}
