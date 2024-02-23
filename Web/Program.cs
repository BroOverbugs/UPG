using Application.Helpers;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Infastructure.Data;
using Infastructure.Interfaces;
using Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));


AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<MousePadsInterface, MousePadsRepository>();
builder.Services.AddTransient<Power_suppliesInterface,Power_SuppliesRepository>();
builder.Services.AddTransient<RAMInterface,RAMRepository>();
builder.Services.AddTransient<Tables_for_gamersInterface,Tables_for_gamersRepository>();
builder.Services.AddTransient<IPower_suppliesService,Power_suppliesService>();
builder.Services.AddTransient<IMousePadsService, MousePadsService>();
builder.Services.AddTransient<IRAMService, RAMService>();
builder.Services.AddTransient<ITables_for_gamersService, Tables_for_gamersService>();
builder.Services.AddTransient<IAccessoriesService, AccessoriesService>();


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

app.MapControllers();

app.Run();
