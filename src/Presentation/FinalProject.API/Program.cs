using FinalProject.Application;
using FinalProject.Infrastructure;
using FinalProject.Persistence;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddResponseCaching();

builder.Services.AddPersistenceServices(builder.Configuration, builder.Environment.EnvironmentName);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddSwaggerGen(options =>//Swagger arayüzünde Authentication kullanabilmek için arayüz ekliyoruz.
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "ATTEMPT (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});





var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseResponseCaching();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
