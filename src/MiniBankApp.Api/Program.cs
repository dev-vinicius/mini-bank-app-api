using MiniBankApp.Api.Extensions;
using MiniBankApp.Api.Filters;
using MiniBankApp.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddConfiguration();
builder.AddUseCases();

builder.Services.AddMvc(options =>
    options.Filters.Add(typeof(ExceptionFilter)));

builder.RegisterInfrastructureServices();

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
