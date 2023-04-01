using NasaApiBackend.Services;

namespace NasaApiBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
            }));
            builder.Services.AddScoped<INeoService, NeoService>();
            builder.Services.AddScoped<IMarsRoverService, MarsRoverService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseCors("ApiCorsPolicy");
            app.MapControllers();

            app.Run();
        }
    }
}