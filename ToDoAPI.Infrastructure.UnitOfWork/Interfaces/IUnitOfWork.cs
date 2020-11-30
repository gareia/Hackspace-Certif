using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAPI.Infrastructure.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
