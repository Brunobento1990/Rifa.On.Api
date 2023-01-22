using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rifa_On.Data.Repositorys;
using Rifa_On.Services.Classes;
using Rifa_On.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ApiWebConnection");

builder.Services.AddDbContext<ApiDbContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(
    opt => opt.SignIn.RequireConfirmedEmail = true)
    .AddEntityFrameworkStores<ApiDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICadastroUsuarioService, CadastroUsuarioService>();
builder.Services.AddScoped<ILoginUsuarioService, LoginUsuarioService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Mypolicy",
                      policy =>
                      {
                          policy.AllowAnyHeader().WithOrigins("*").AllowAnyMethod().AllowAnyOrigin();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("Mypolicy");

app.MapControllers();

app.Run();
