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
                new SqlColumn("UserId", SqlDbType.UniqueIdentifier)
                {
                    AllowNull = true
                },
                new SqlColumn("LogSubjectId", SqlDbType.Int)
                {
                    AllowNull = false
                }
            }
};

Log.Logger = new LoggerConfiguration()
    .Enrich.WithProperty("LogSubjectId", 1)
    .MinimumLevel.Debug()
    .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Debug)
    .WriteTo.MSSqlServer(
        connectionString: builder.Configuration.GetConnectionString("ContafacilServerConnection"),
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

    builder.Services.addAutoMappers();
    builder.Services.AddConnection(configuration);
    builder.Services.AddAuthenticationConf(configuration);
    builder.Services.registerRepositories();
    builder.Services.registerServices();
    builder.Services.AddControllers(options =>
    {
        options.ModelValidatorProviders.Clear();
    });
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddFluentValidationAutoValidation();
    builder.Services.AddFluentValidationClientsideAdapters();
    builder.Services.addFluentValidations();

    var app = builder.Build();

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