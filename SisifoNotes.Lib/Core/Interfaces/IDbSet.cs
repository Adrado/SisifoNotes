using System;
using System.Collections.Generic;
using System.Text;

namespace SisifoNotes.Lib.Core.Interfaces
{
    public interface IDbSet<T> : ICrudEntity<T> where T: Entity
    {
    }
}
