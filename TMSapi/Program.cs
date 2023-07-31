using Microsoft.EntityFrameworkCore;
using NLog.Web;
using TMSapi.Models;
using TMSapi.Repositories;
using TMSapi.Serices;
using TMSapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Insert dependency injection for Logger
builder.Logging.ClearProviders();
builder.Host.UseNLog();

builder.Services.AddTransient<IEventRepository, EventRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IVenueRepository, VenueRepository>();
builder.Services.AddTransient<IEventTypeRepository, EventTypeRepository>();
builder.Services.AddTransient<ITicketCategoryRepository, TicketCategoryRepository>();
builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IVenueService, VenueService>();
builder.Services.AddTransient<IEventTypeService, EventTypeService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

