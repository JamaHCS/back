using API.Extensions;
using Repository.Extensions;
using Service.Extensions;
using Domain.Extensions;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.addAutoMappers();
builder.Services.AddConnection(configuration);
builder.Services.AddAuthenticationConf(configuration);
builder.Services.registerRepositories();
builder.Services.registerServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
