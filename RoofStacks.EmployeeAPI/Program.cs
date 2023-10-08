using Microsoft.AspNetCore.Authentication.JwtBearer;
using RoofStacks.EmployeeAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

#region Authentication Settings

// Configure authentication settings for the application using JWT (JSON Web Tokens).
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)  // Add authentication middleware
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
    {
        // Set the authority to validate the tokens. Typically, this is your Identity Server URL.
        opts.Authority = builder.Configuration["JwtSettings:AuthServerUrl"];

        // Set the audience that tokens must have to be considered valid.
        opts.Audience = builder.Configuration["JwtSettings:AudProp"];
    });

#endregion

#region Authorization Settings

// Configure authorization settings for the application.
builder.Services.AddAuthorization(opts =>
{
    // Add a policy for read operations, requiring the "company.read" scope claim.
    opts.AddPolicy("Read", policy =>
    {
        // Require a scope claim with value "company.read"
        policy.RequireClaim("scope", "company.read");
    });

    // Add a policy for write operations, requiring the "company.write" scope claim.
    opts.AddPolicy("Write", policy =>
    {
        // Require a scope claim with value "company.write"
        policy.RequireClaim("scope", "company.write");
    });

    // Add a policy for delete operations, requiring the "company.delete" scope claim.
    opts.AddPolicy("Delete", policy =>
    {
        // Require a scope claim with value "company.delete"
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
