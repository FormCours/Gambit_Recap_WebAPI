using Gambit.API.Handlers;
using Gambit.Domain.Repositories;
using Gambit.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ProductHandler>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllers();

// Authentification
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    // ↓ Si utilisation d'un serveur d'authentification
                    options.Authority = "https://localhost:7250/";
                    options.Audience = "MaxWebAPI_Audience";

                    // ↓ Si la clef est connu par l'application
                    //options.TokenValidationParameters = new TokenValidationParameters
                    //{
                    //    ValidAudience = "Audience",
                    //    ValidateAudience = true,
                    //    ValidIssuer = "Issuer",
                    //    ValidateIssuer = true,
                    //    ValidateLifetime = true,
                    //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Clef")),
                    //    ValidateIssuerSigningKey = true
                    //};
                });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
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
