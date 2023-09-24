using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;
using TransactionAPI;
using TransactionAPI.Context;
using TransactionAPI.Models;
using TransactionAPI.Repositories;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWTSettings"));


// DbContexts
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));


builder.Services.AddDbContext<TransactionDetailContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CustomConnection")));

builder.Services.AddDbContext<AppDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("TCustomConnection")));


// Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddScoped<IGroupRepository, GroupRepository>();




// JWT Configuration
var secretKey = builder.Configuration.GetSection("JWTSettings:SecretKey").Value;
var issuer = builder.Configuration.GetSection("JWTSettings:Issuer").Value;
var audience = builder.Configuration.GetSection("JWTSettings:Audience").Value;
var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = signingKey,
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidateAudience = true,
        ValidAudience = audience
    };
})
.AddCookie(options =>
{
    options.Events = new CookieAuthenticationEvents
    {
        OnRedirectToLogin = context =>
        {
            if (context.Request.Path.StartsWithSegments("/api") && context.Response.StatusCode == (int)HttpStatusCode.OK)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                context.Response.Redirect(context.RedirectUri);
            }
            return Task.CompletedTask;
        }
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
options.WithOrigins("http://10.0.9.31:4200")
.AllowAnyMethod()
.AllowAnyHeader());


app.UseAuthentication();
//app.UseAuthorization();


app.MapControllers();

app.Run();

// Add to Main method
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetService<AppDbContext>();
    SeedData.Initialize(db);
}