using UnitConverter.Interfaces;
using UnitConverter.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICategoryConverter, LengthConverter>();
builder.Services.AddScoped<ICategoryConverter, WeightConverter>();
builder.Services.AddScoped<ICategoryConverter, TemperatureConverter>();
builder.Services.AddScoped<IConversionService, ConversionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
