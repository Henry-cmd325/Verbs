using VerbsAPI.Context;
using Microsoft.EntityFrameworkCore;
using VerbsAPI.Services;

var builder = WebApplication.CreateBuilder(args);
string connString = builder.Configuration.GetConnectionString("EnglishConnection")!;

// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddDbContext<EnglishContext>
(
    opt => opt.UseMySql(connString, ServerVersion.AutoDetect(connString))
);

builder.Services.AddScoped<IUsuarioService, UsuarioService>();

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
