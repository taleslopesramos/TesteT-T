using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    
    internal interface ILogger<T>
    {
        void LogAdd(T entity);
        void LogRemove(T entity);
        void LogUpdate(T entity);
        void LogError(T entity, string message);
    }
}
