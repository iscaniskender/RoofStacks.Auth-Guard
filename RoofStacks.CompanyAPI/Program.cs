using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using RoofStacks.CompanyAPI.Model;
using RoofStacks.CompanyAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICompanyService, CompanyService>();

#region Authentication Settings
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
    {
        opts.Authority = builder.Configuration["JwtSettings:AuthServerUrl"];
        opts.Audience = builder.Configuration["JwtSettings:AudProp"];
    });


#endregion
#region Authorization Settings

builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("Read", policy =>
    {
        policy.RequireClaim("scope", "company.read");
    });
    opts.AddPolicy("Write", policy =>
    {
        policy.RequireClaim("scope", "company.write");
    });
    opts.AddPolicy("Delete", policy =>
    {
        policy.RequireClaim("scope", "company.delete");
    });
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
