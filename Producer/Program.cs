
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Producer.Models;
using Producer.RabbitMQ;
using Producer.Services;
using System.Text;

namespace Producer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DbConn");

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IRabbitMQProducer, RabbitMQProducer>();
            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

           
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
