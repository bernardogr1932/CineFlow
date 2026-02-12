using CineFlowAPI.service.api;
using Microsoft.EntityFrameworkCore;
using CineFlowAPI.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<SessaoService>();
builder.Services.AddScoped<FilmeService>();
builder.Services.AddScoped<SalaService>();
builder.Services.AddScoped<IngressoService>();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();