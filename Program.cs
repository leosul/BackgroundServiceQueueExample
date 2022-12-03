using BackgroundServiceQueueExample.Interfaces;
using BackgroundServiceQueueExample.Models;
using BackgroundServiceQueueExample.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<IBackgroundQueue<List<Customer>>, BackgroundQueue<List<Customer>>>();
builder.Services.AddHostedService<CustomerBackgroundWorker>();
builder.Services.AddScoped<ICustomerPublisher, CustomerPublisher>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
