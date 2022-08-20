using MediatR;
using Microsoft.EntityFrameworkCore;
using Tenant.Application.CQRS.Commands.Request;
using Tenant.Application.Mapping;
using Tenant.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TenantDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TenantDbConn"), configure =>
    {
        configure.MigrationsAssembly("Tenant.Infrastructure");
    });
});


builder.Services.AddMediatR(typeof(CreateTenantCommandRequest).Assembly);
builder.Services.AddAutoMapper(typeof(CustomMapping));
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();