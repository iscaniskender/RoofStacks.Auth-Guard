using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RoofStacks.Auth_Guard.Seed;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var assemblyName = typeof(Program).GetTypeInfo().Assembly.GetName().Name;

#region IdentitySettings

// Initialize IdentityServer with configuration options
builder.Services.AddIdentityServer()
    .AddConfigurationStore(opts =>
    {
        opts.ConfigureDbContext = c => c.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlDb"),
            sqlopts => sqlopts.MigrationsAssembly(assemblyName));
    })
    .AddDeveloperSigningCredential();
#endregion


var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var services=serviceScope.ServiceProvider;
    var context = services.GetRequiredService<ConfigurationDbContext>();
    IdentityServerSeedData.Seed(context);
};

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
app.UseHttpsRedirection();

app.UseIdentityServer();

app.UseAuthorization();

app.MapControllers();
    
app.UseMiddleware<IdentityServerLoggingMiddleware>();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.Run();
