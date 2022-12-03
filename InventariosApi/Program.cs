using InventariosApi;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<InventariosDbContext>(options =>
                                                    options.UseSqlServer(builder.Configuration.GetConnectionString("ApiConnection")));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options=>
                 options.TokenValidationParameters=new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                 {
                     ValidateIssuer= true,
                     ValidateAudience= true,
                     ValidateLifetime= true,
                     ValidateIssuerSigningKey= true,
                     ValidIssuer = builder.Configuration["JWT:Issuer"],
                     ValidAudience= builder.Configuration["JWT:Audience"],
                     IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                 });

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

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
