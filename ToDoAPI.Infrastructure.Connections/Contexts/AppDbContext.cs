using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoAPI.Domain.Entities;

namespace ToDoAPI.Infrastructure.Connections.Contexts
{
    public class AppDbContext: DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ToDoItem>().ToTable("todoitems");
            builder.Entity<ToDoItem>().HasKey(i => i.Id);
            builder.Entity<ToDoItem>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ToDoItem>().Property(i => i.Name).IsRequired().HasMaxLength(40);
            builder.Entity<ToDoItem>().HasIndex(i => i.Name).IsUnique();
        }
    }
}
