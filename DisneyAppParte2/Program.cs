global using Microsoft.EntityFrameworkCore;
global using DisneyAppParte2.Business.Services.EmailService;
using DisneyAppParte2.Business.Services.CharacterService;
using DisneyAppParte2.Business.Services.MovieSerieService;
using DisneyAppParte2.Business.Services.TokenService;
using DisneyAppParte2.Business.Services.UserService;
using DisneyAppParte2.DataAccess.Data;
using DisneyAppParte2.DataAccess.Repositories.CharacterRepository;
using DisneyAppParte2.DataAccess.Repositories.MovieSerieRepository;
using DisneyAppParte2.DataAccess.Repositories.UserRepository;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Mailjet.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Starndard Authorization header using the Bearer Scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

//Add authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("TokenKey").Value)),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});
// Email 
builder.Services.AddHttpClient<IMailjetClient, MailjetClient>(client =>
{
    //set BaseAddress, MediaType, UserAgent
    client.SetDefaultSettings();
    //or
    client.UseBasicAuthentication(builder.Configuration.GetSection("apiKey").Value, builder.Configuration.GetSection("apiSecret").Value);
});

// Add Repositories
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<IMovieSerieRepository, MovieSerieRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Add services to the container.
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IMovieSerieService, MovieSerieService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ITokenService, TokenService>();

// Add controllers
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(routing => routing.LowercaseUrls = true);
builder.Services.AddDbContext<DisneyAppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
