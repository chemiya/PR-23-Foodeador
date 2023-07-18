using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using NetCoreAPIMysql.data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
                      policy =>
                      {
                          policy.WithOrigins("*");
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var mysqlConnection = new MySQLConfiguration(builder.Configuration.GetConnectionString("conexion"));
builder.Services.AddSingleton(mysqlConnection);

//builder.Services.AddSingleton(new MySqlConnection(builder.Configuration.GetConnectionString("conexion")));

builder.Services.AddScoped<IFoodeadorRepository, FoodeadorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthorization();

app.MapControllers();

app.Run();
