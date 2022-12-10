using DormitoryApi.BLL.Services.Implementation;
using DormitoryApi.BLL.Services.Interface;
using DormitoryApi.DAL.Context;
using DormitoryApi.DAL.Models;
using DormitoryApi.DAL.Repositories.Implementation;
using DormitoryApi.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DormitoryApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // add database dependecy
            _ = builder.Services.AddDbContext<DormitoryContext>(c =>c.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IStudentService, StudentService>();

            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}