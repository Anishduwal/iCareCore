using iCareCore.Application.Services;
using iCareCore.Core.Interface;
using iCareCore.Core.IRepo;
using iCareCore.Infrasructure.Repo;
using iCareCore.Infrastructure.DbHelper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DbConn.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IDBANRepo, DBANRepo>();
builder.Services.AddScoped<IDBANService, DBANService>();
builder.Services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                 .AllowAnyMethod()
                                                                  .AllowAnyHeader()));
DbConn.DBANUsername = builder.Configuration.GetValue<string>("DBANUsername");
DbConn.DBANPassword = builder.Configuration.GetValue<string>("DBANPassword");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
