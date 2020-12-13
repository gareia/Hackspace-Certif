using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoAPI.Infrastructure.Connections.Contexts;

namespace ToDoAPI.Infrastructure.Repository.Classes
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;
        protected readonly string _connectionString; //
        public BaseRepository(IConfiguration configuration, AppDbContext context)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _context = context;
        }

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
