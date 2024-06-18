using SuperLoja.Api.Domain.Repository;
using SuperLoja.Api.Domain.Services;
using SuperLoja.Api.Infrastructure.Repository;
using SuperLoja.Api.Presentation.Configuration;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagerServices();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
// builder.Services.AddScoped<IVoucherRepository, VoucherRepository>();

builder.Services.AddScoped<VoucherService>();
builder.Services.AddScoped<ProdutoService>();

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

await app.RunAsync();