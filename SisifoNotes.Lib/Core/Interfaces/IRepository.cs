using SisifoNotes.Lib.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SisifoNotes.Lib.Core
{
    public interface IRepository<T> : ICrudEntity<T> where T : Entity
    {
    }
}
