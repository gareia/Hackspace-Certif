using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAPI.Infrastructure.UnitOfWork.Interfaces
{
    //PATRON UNIT OF WORK - ASEGURAR LA PERSISTENCIA
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
