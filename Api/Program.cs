using Application;
using Infrastructure;

const string _openApiName = "v1";

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterInfrastructure(builder.Configuration.GetConnectionString("DB"));
builder.Services.RegisterApplication();

builder.Services.AddControllers();
builder.Services.AddOpenApi(_openApiName);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint($"/openapi/{_openApiName}.json", _openApiName);
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run("http://localhost:5293");
