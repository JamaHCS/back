using API.Extensions;
using Repository.Extensions;
using Service.Extensions;
using Domain.Extensions;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Data;
using System.Collections.ObjectModel;
using Serilog.Events;
using API.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Globalization;
using API.Middlewares;
using Domain.Entities.Global;

CultureInfo cultureInfo = new CultureInfo("es");
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
ValidatorOptions.Global.LanguageManager = new SpanishLanguageManager();
ValidatorOptions.Global.LanguageManager.Culture = cultureInfo;

var columnOptions = new ColumnOptions
{
    AdditionalColumns = new Collection<SqlColumn>
        {
            new SqlColumn("UserId", SqlDbType.UniqueIdentifier, true),
            new SqlColumn("LogSubjectId", SqlDbType.Int, false),
            new SqlColumn("RequestId", SqlDbType.NVarChar, true),
            new SqlColumn("ClientIp", SqlDbType.NVarChar, true),
            new SqlColumn("UserAgent", SqlDbType.NVarChar, true),
            new SqlColumn("UserRole", SqlDbType.NVarChar, true),
            new SqlColumn("ServiceName", SqlDbType.NVarChar, true),
            new SqlColumn("MethodName", SqlDbType.NVarChar, true),
            new SqlColumn("Path", SqlDbType.NVarChar, true),
            new SqlColumn("Method", SqlDbType.NVarChar, true)
        }
};

Log.Logger = new LoggerConfiguration()
    .Enrich.WithProperty("LogSubjectId", 1)
    .MinimumLevel.Debug()
    .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Debug)
    .WriteTo.MSSqlServer(
        connectionString: Environment.GetEnvironmentVariable("CONNECTION_STRING"),
        sinkOptions: new MSSqlServerSinkOptions
        {
            TableName = "Logs",
            SchemaName = "pim",
            AutoCreateSqlTable = false 
        },
        restrictedToMinimumLevel: LogEventLevel.Debug,
        columnOptions: columnOptions
    )
    .CreateLogger();

try
{
    Log.Information("Starting web host");
    builder.Host.UseSerilog();

    var apiVersion = builder.Configuration["ApiVersion"] ?? "0.0.1";

    Result.SetApiVersion(apiVersion);


    builder.Services.addAutoMappers();
    builder.Services.AddConnection(configuration);
    builder.Services.AddAuthenticationConf(configuration);
    builder.Services.SwaggerConfiguration(configuration);
    builder.Services.registerRepositories();
    builder.Services.registerServices();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddFluentValidationAutoValidation();
    builder.Services.AddFluentValidationClientsideAdapters();
    builder.Services.addFluentValidations();
    builder.Services.AddHttpContextAccessor();


    var app = builder.Build();

    app.UseMiddleware<LogContextMiddleware>();
    app.UseMiddleware<ExceptionMiddleware>();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}