using System;
using System.Collections.Generic;
using System.Text;

namespace SisifoNotes.Lib.Core.Interfaces
{
    public interface ICrudService<T> : IGenericService, ICrudEntity<T> where T : Entity
    {
    }
}
