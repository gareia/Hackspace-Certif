using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoAPI.Domain.Entities;
using ToDoAPI.Infrastructure.Connections.Contexts;
using ToDoAPI.Infrastructure.Repository.Interfaces;

namespace ToDoAPI.Infrastructure.Repository.Classes
{
    public class ToDoItemRepository: BaseRepository, IToDoItemRepository
    {
        public ToDoItemRepository(IConfiguration configuration, AppDbContext context) : base(configuration, context)
        {

        }
        /**
        public ToDoItemRepository(AppDbContext context): base(context)
        {
        }
        **/

        public async Task AddAsync(ToDoItem item)
        {
            //EFC: await _context.ToDoItems.AddAsync(item);

            //PROBLEMA DEL ID SE PUEDE ARREGLAR CON TRANSACTIONS
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("INSERT INTO todoitems(Name, Completed, CreatedAt, LimitDate) " +
                    "VALUES(@name, @completed, @createdAt, @limitDate);", 
                    new { item.Name, item.Completed, item.CreatedAt, item.LimitDate });
            }
                
        }

        public void Remove(long id)
        {
            //EFC: _context.Remove(item);
            //ASYNC: await connection.ExecuteAsync("DELETE FROM todoitems WHERE id= @id", new { id });

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Execute("DELETE FROM todoitems WHERE id=@id", new { id });
            }
        }

        public async Task<ToDoItem> FindByIdAsync(long id)
        {
            //EFC: return await _context.ToDoItems.FindAsync(id);

            using (var connection = new MySqlConnection(_connectionString))
            { 
                var item = await connection.QueryFirstAsync<ToDoItem>("SELECT * FROM todoitems WHERE id= @id", new { id });
                return item;
            }
        }

        public async Task<IEnumerable<ToDoItem>> ListAsync()
        {
            //EFC: return await _context.ToDoItems.ToListAsync(); //DEVUELVE UN LIST<TODOITEM>

            using (var connection = new MySqlConnection(_connectionString))
            {
                var items = await connection.QueryAsync<ToDoItem>("SELECT * FROM todoitems");
                return items;
            }
        }

        public ToDoItem Update(ToDoItem item, ToDoItem newItem)
        {
            //EFC: *** _context.ToDoItems.Update(item); return item;

            string baseQuery = "UPDATE todoitems SET ";

            if (newItem.Name != null)
            {
                item.Name = newItem.Name;
                baseQuery += "name=@Name, ";
            }
            if (newItem.Completed)
            {
                item.Completed = newItem.Completed;
                baseQuery += "completed=@Completed, ";
            }
            if (newItem.LimitDate != null)
            {
                item.LimitDate = newItem.LimitDate;
                baseQuery += "limitDate=@LimitDate";
            }

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Execute(baseQuery+" WHERE id=@Id", item);
            }

            return item;

        }

        /*
        //TODO MYSQLDATA READER CAST TYPES
        private ToDoItem MapToItem(MySqlDataReader reader)
        {
            return new ToDoItem()
            {
                Id = (long)reader["Id"],
                Name = reader["Name"].ToString(),
                Completed = (bool)reader["Completed"],
                LimitDate = (DateTime)reader["LimitDate"],
                CreatedAt = (DateTime)reader["CreatedAt"]
            };
        }*/

        /*
        //GET ALL WITH STORED PROCEDURES
        using (MySqlConnection db = new MySqlConnection(_connectionString))
        {
            string sp = "GetAllItems";

            using (MySqlCommand cmd = new MySqlCommand(sp, db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var response = new List<ToDoItem>();
                await db.OpenAsync();

                using (var reader = await cmd.BeginExecuteReader())
                {
                    while(await reader.ReadAsync())
                    {
                        response.Add(MapToItem(reader));
                    }
                }
                return response;
            }
        }*/
    }
}
