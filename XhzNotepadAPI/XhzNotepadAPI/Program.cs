using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddCors(op => {
//    op.AddPolicy("Allow", builder =>
//    {
//        builder.AllowAnyOrigin()
//        .AllowAnyMethod
//        ().AllowAnyHeader();
//    });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.("http://*:7053");
app.UseHttpsRedirection();

app.UseAuthorization();
//app.UseCors("Allow");
app.MapControllers();

app.Run();


//namespace MyWebApi
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            CreateHostBuilder(args).Build().Run();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureServices((hostContext, services) =>
//                {
//                    services.AddControllers();

//                    // ¿çÓòÅäÖÃ
//                    services.AddCors(options =>
//                    {
//                        options.AddPolicy("AllowAnyOrigin", builder =>
//                            builder.AllowAnyOrigin()
//                                .AllowAnyHeader()
//                                .AllowAnyMethod());
//                    });
//                })
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.Configure(app =>
//                    {
//                        app.UseRouting();

//                        // ÆôÓÃ¿çÓòÖÐ¼ä¼þ
//                        app.UseCors("AllowAnyOrigin");

//                        app.UseEndpoints(endpoints =>
//                        {
//                            endpoints.MapControllers();
//                        });
//                    });
//                });
//    }
//}