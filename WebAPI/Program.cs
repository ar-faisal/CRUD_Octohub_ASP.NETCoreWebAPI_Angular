using DAL;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddDbContext<BCDbContext>(opt => opt.UseSqlServer(configuration.GetSection("BC:ssConStr").Value));

builder.Services.AddTransient<IBCDb, BCDb>();

var app = builder.Build();




app.UseExceptionHandler(options =>
{
    options.Run(async context => //Here we are creating the object of HTTP context which has predefined Request and response,status code,etc.
    {
        context.Response.StatusCode = 500;//Internal Server Error //Here we are creating the response
        context.Response.ContentType = "application/json";
        var ex = context.Features.Get<IExceptionHandlerFeature>();
        if (ex != null)
        { //ex.Error
            var msg = (ex.Error.InnerException != null) ? ex.Error.InnerException.Message : ex.Error.Message;
            await context.Response.WriteAsync("Admin is working on it at application level " + msg); //writing the response directly
        }
    });
}
);

//Step 3: Add mapControllers
app.UseCors(x => x.WithOrigins("http://localhost:4200")
                              .AllowAnyMethod()
                              .AllowAnyHeader()
                              .AllowCredentials());

app.MapControllers();

app.Run();