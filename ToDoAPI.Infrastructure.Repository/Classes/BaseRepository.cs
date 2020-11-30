using System;
using System.Collections.Generic;
using System.Text;
using ToDoAPI.Infrastructure.Connections.Contexts;

namespace ToDoAPI.Infrastructure.Repository.Classes
{
    public class BaseRepository
    {
        //ONLY ITS CHILDREN CAN ACCESS TO THIS PROP
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
