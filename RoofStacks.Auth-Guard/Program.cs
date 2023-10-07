using System.Reflection;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using RoofStacks.Auth_Guard;
using RoofStacks.Auth_Guard.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var assemblyName = typeof(Program).GetTypeInfo().Assembly.GetName().Name;

#region IdentitySettings

builder.Services.AddIdentityServer()
    .AddConfigurationStore(opts =>
    {
        opts.ConfigureDbContext = c => c.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"),
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
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseIdentityServer();

app.UseAuthorization();

app.MapControllers();

app.Run();
