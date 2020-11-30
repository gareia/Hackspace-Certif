using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ToDoAPI.Application.DTO;
using ToDoAPI.Application.Service.Classes;
using ToDoAPI.Application.Service.Interfaces;
using ToDoAPI.Domain.Entities;
using ToDoAPI.Infrastructure.Connections.Contexts;
using ToDoAPI.Infrastructure.Repository.Classes;
using ToDoAPI.Infrastructure.Repository.Interfaces;
using ToDoAPI.Infrastructure.UnitOfWork.Classes;
using ToDoAPI.Infrastructure.UnitOfWork.Interfaces;

namespace ToDoAPI.Distributed.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<AppDbContext>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
            services.AddScoped<IToDoItemService, ToDoItemService>();
            services.AddAutoMapper(configuration =>
            {
                configuration.CreateMap<ToDoItem, ToDoItemDTO>();
            }, typeof(Startup));
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
