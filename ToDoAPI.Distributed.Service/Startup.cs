using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ToDoAPI.Application.Service.Classes;
using ToDoAPI.Application.Service.Interfaces;
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
            //services.AddControllersWithViews().AddNewtonsoftJson(); //

            //*************
            services.AddDbContext<AppDbContext>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            //*************

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
            services.AddScoped<IToDoItemService, ToDoItemService>();
            services.AddAutoMapper(typeof(Startup));
            AddSwagger(services);
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Todo items API",
                    Version = groupName,
                    Description = "Daily todo items API",
                    Contact = new OpenApiContact
                    {
                        Name = "Hackspace",
                        Email = string.Empty//,
                        //Url = new Uri("url"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TODO ITEMS API V1")); //search engine

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
