using Microsoft.AspNetCore.Authentication.JwtBearer;
using RoofStacks.EmployeeAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

#region Token Settings


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
    opts.AddPolicy("ReadEmployee", policy =>
    {
        policy.RequireClaim("scope", "employee.read");
    });
    opts.AddPolicy("WriteEmployee", policy =>
    {
        policy.RequireClaim("scope", "employee.write");
    });
    opts.AddPolicy("UpdateOrCreateEmployee", policy =>
    {
        policy.RequireClaim("scope", "employee.update");
    });
    opts.AddPolicy("DeleteEmployee", policy =>
    {
        policy.RequireClaim("scope", "employee.delete");
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
