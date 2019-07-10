using System;
using System.Collections.Generic;
using System.Text;

namespace SisifoNotes.Lib.Core.Interfaces
{
    public interface IRepository<T> : ICrudEntity<T> where T : Entity
    {
    }
}
