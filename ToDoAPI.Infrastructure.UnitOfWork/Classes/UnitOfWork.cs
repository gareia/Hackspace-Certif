using System.Threading.Tasks;
using ToDoAPI.Infrastructure.Connections.Contexts;
using ToDoAPI.Infrastructure.Repository.Classes;
using ToDoAPI.Infrastructure.UnitOfWork.Interfaces;

namespace ToDoAPI.Infrastructure.UnitOfWork.Classes
{
    public class UnitOfWork: BaseRepository, IUnitOfWork
    {
        public UnitOfWork(AppDbContext context): base(context)
        {

        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
