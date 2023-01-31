using Microsoft.EntityFrameworkCore;
using webapi.Domain.Contracts;
using webapi.CQRS;
using webapi.Infrastructure.Database.Contexts;
using MediatR;
using webapi.AppService;
using webapi.Infrastructure.Database.Repository;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(typeof(_ForCQRSAssemblyLoadOnly).Assembly);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextFactory<AppDbContext>(o =>
           o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")),
           ServiceLifetime.Scoped);

builder.Services.AddAutoMapper(typeof(_ForAppServiceAssemblyLoadOnly).Assembly);
builder.Services.AddMediatR(typeof(_ForCQRSAssemblyLoadOnly).Assembly);
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>(); //added 1:50pm 1/24/2023
builder.Services.AddScoped<IOrderRepository, OrderRepository>();


builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options => {
        options.SuppressModelStateInvalidFilter = true;
    });




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
