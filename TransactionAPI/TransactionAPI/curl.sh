TOKEN_RESPONSE=$(curl -s -H "Content-Type: application/json" -X POST -d '{"email":
"user@example.com", "password": "123#Bruno"}' http://localhost:5280/api/Account/sign-
in)

RHQ01SW01RPTSTG+Administrator@RHQ01SW01RPTSTG MINGW64 /c/jq
$ ACCESS_TOKEN=$(echo $TOKEN_RESPONSE | grep -oP 'access_token":"\K[^"]+')

RHQ01SW01RPTSTG+Administrator@RHQ01SW01RPTSTG MINGW64 /c/jq
$ curl -H "Authorization: Bearer $ACCESS_TOKEN" http://localhost:5280/api/Transaction
Detail
[{"transactionDetailId":57,"alloC_TXN_ID":642,"deeD_INO":"DR004264023","loG_CREATED_TS
":"2022-07-25T13:08:53.691","conV_DEED_ABBREVIATION":"CNV-000-001-037","sourcE_REF_ABB
REVIATION":"TRN-000-000-488","conV_STATUS":"Verified","loT_NO":5989,"deeD_STATUS":"REG
ISTERED","deeD_TYPE":"CERTIFICATE_OF_RLT_SECTION19","deeD_OWNER_NAME":"NGWATO LAND BOA
RD","prinT_STATUS":"WAITING_FOR_PRINT"},{"transactionDetailId":60,"alloC_TXN_ID":646,"
deeD_INO":"DR004264460","loG_CREATED_TS":"2022-04-25T08:29:53.428","conV_DEED_ABBREVIA
TION":"CNV-000-000-699","sourcE_REF_ABBREVIATION":"CLM-000-395-004","conV_STATUS":"Can
celled","loT_NO":6350,"deeD_STATUS":"REGISTERED","deeD_TYPE":"CERTIFICATE_OF_RT_SECTIO
N41","deeD_OWNER_NAME":"GHANZI LAND BOARD","prinT_STATUS":"WAITING_FOR_PRINT"},{"trans
actionDetailId":61,"alloC_TXN_ID":647,"deeD_INO":"DR004264102","loG_CREATED_TS":"2021-
02-04T11:05:56.923","conV_DEED_ABBREVIATION":"CNV-000-000-126","sourcE_REF_ABBREVIATIO
N":"DSM00065/2021","conV_STATUS":"Cancelled","loT_NO":6905,"deeD_STATUS":"REGISTERED",
"deeD_TYPE":"CERTIFICATE_OF_RLT_SECTION19","deeD_OWNER_NAME":"NGWAKETSE LAND BOARD","p
rinT_STATUS":"WAITING_FOR_PRINT"},{"transactionDetailId":65,"alloC_TXN_ID":651,"deeD_I
NO":"DR004264101","loG_CREATED_TS":"2021-02-24T09:21:21.995","conV_DEED_ABBREVIATION":
"CNV-000-000-176","sourcE_REF_ABBREVIATION":"ALT-000-012-478","conV_STATUS":"Cancelled
","loT_NO":7022,"deeD_STATUS":"REGISTERED","deeD_TYPE":"DEED_TRNS_CSTM_LND_RIGHT_TLBF8
","deeD_OWNER_NAME":"REFILWE  OLORATO MAPOSA","prinT_STATUS":"WAITING_FOR_PRINT"},{"tr
ansactionDetailId":67,"alloC_TXN_ID":653,"deeD_INO":"DR004264457","loG_CREATED_TS":"20
22-09-09T09:19:47.043","conV_DEED_ABBREVIATION":"CNV-000-001-178","sourcE_REF_ABBREVIA
TION":"DSM04324/2022","conV_STATUS":"Cancelled","loT_NO":6657,"deeD_STATUS":"REGISTERE
D","deeD_TYPE":"CERTIFICATE_OF_RT_SECTION41","deeD_OWNER_NAME":"KGALAGADI LAND BOARD",
"prinT_STATUS":"WAITING_FOR_PRINT"},{"transactionDetailId":68,"alloC_TXN_ID":654,"deeD
_INO":"DR004264451","loG_CREATED_TS":"2022-04-20T14:30:09.816","conV_DEED_ABBREVIATION
":"CNV-000-000-690","sourcE_REF_ABBREVIATION":"DSM-04757/2017","conV_STATUS":"Cancelle
d","loT_NO":6322,"deeD_STATUS":"REGISTERED","deeD_TYPE":"CERTIFICATE_OF_RLT_SECTION19"
,"deeD_OWNER_NAME":"NGWAKETSE LAND BOARD","prinT_STATUS":"WAITING_FOR_PRINT"},{"transa
ctionDetailId":69,"alloC_TXN_ID":655,"deeD_INO":"DR004264103","loG_CREATED_TS":"2021-0
2-04T12:38:23.238","conV_DEED_ABBREVIATION":"CNV-000-000-129","sourcE_REF_ABBREVIATION
":"DSM00067/2021","conV_STATUS":"Cancelled","loT_NO":6916,"deeD_STATUS":"REGISTERED","
deeD_TYPE":"CERTIFICATE_OF_RST_SECTION19","deeD_OWNER_NAME":"Government of the Republi
c of Botswana","prinT_STATUS":"WAITING_FOR_PRINT"},{"transactionDetailId":72,"alloC_TX
N_ID":658,"deeD_INO":"DR004264448","loG_CREATED_TS":"2022-05-24T17:51:58.669","conV_DE
ED_ABBREVIATION":"CNV-000-000-730","sourcE_REF_ABBREVIATION":"CLM-000-263-119","conV_S
TATUS":"Verified","loT_NO":6355,"deeD_STATUS":"REGISTERED","deeD_TYPE":"CERTIFICATE_OF
_RT_SECTION41","deeD_OWNER_NAME":"TLOKWENG LAND BOARD","prinT_STATUS":"WAITING_FOR_PRI
NT"},{"transactionDetailId":74,"alloC_TXN_ID":657,"deeD_INO":"DR004264024","loG_CREATE
D_TS":"2023-09-08T13:08:53.691","conV_DEED_ABBREVIATION":"CNV-000-001-038","sourcE_REF
_ABBREVIATION":"TRN-000-000-489","conV_STATUS":"Verified","loT_NO":5990,"deeD_STATUS":
"REGISTERED","deeD_TYPE":"CERTIFICATE_OF_RLT_SECTION12","deeD_OWNER_NAME":"KWENENG LAN
D BOARD","prinT_STATUS":"PRINTED"}]

TOKEN_RESPONSE=$(curl -s -H "Content-Type: application/json" -X POST -d '{"email": "user@example.com", "password": "123#Bruno"}' http://localhost:5280/api/Account/sign-in)
ACCESS_TOKEN=$(echo $TOKEN_RESPONSE | grep -oP 'access_token":"\K[^"]+')
curl -H "Authorization: Bearer $ACCESS_TOKEN" http://localhost:5280/api/TransactionDetail

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TransactionAPI;
using TransactionAPI.Models;
using TransactionAPI.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWTSettings"));

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddDbContext<TransactionDetailContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();

var secretKey = builder.Configuration.GetSection("JWTSettings:SecretKey").Value;
var issuer = builder.Configuration.GetSection("JWTSettings:Issuer").Value;
var audience = builder.Configuration.GetSection("JWTSettings:Audience").Value;
var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = signingKey,
        ValidateAudience = true,
        ValidAudience = audience,
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ClockSkew = TimeSpan.Zero
    };
}).AddCookie(options =>
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

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", builder => builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPolicy");

app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();

