using Amazon.Runtime;
using Amazon.S3;
using Application.Helpers;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Infastructure.Data;
using Infastructure.Interfaces;
using Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

# region DbContext

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")),
    ServiceLifetime.Scoped);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

#endregion

#region Mapper

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion

#region AWS Configuration

var accessKey = builder.Configuration["AWS:AccessKey"];
var secretKey = builder.Configuration["AWS:SecretAccessKey"];

var awsCredentials = new BasicAWSCredentials(accessKey, secretKey);
builder.Services.AddSingleton<IAmazonS3>(new AmazonS3Client(awsCredentials, Amazon.RegionEndpoint.EUNorth1));

#endregion

#region Redis
builder.Services.Configure<ConfigurationOptions>(builder.Configuration.GetSection("RedisCacheOptions"));
builder.Services.AddStackExchangeRedisCache(setupAction =>
{
    setupAction.Configuration = builder.Configuration.GetConnectionString("RedisConnectionString");
});
#endregion

#region CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
        });
});
#endregion

#region DI Container

builder.Services.AddControllers();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<MousePadsInterface, MousePadsRepository>();
builder.Services.AddTransient<PowerSuppliesInterface,PowerSuppliesRepository>();
builder.Services.AddTransient<RAMInterface,RAMRepository>();
builder.Services.AddTransient<TablesForGamersInterface,TablesForGamersRepository>();


builder.Services.AddTransient<IPowerSuppliesService,PowerSuppliesService>();
builder.Services.AddTransient<IMousePadsService, MousePadsService>();
builder.Services.AddTransient<IRAMService, RAMService>();
builder.Services.AddTransient<IAccessoriesService, AccessoriesService>();
builder.Services.AddTransient<ITablesForGamersService, TablesForGamersService>();


builder.Services.AddTransient<IArmchairsService,ArmchairsService>();
builder.Services.AddTransient<ICoolerService,CoolerService>();
builder.Services.AddTransient<IDrivesService,DrivesService>();
builder.Services.AddTransient<IGamingBuildsService, GamingBuildsService>();
builder.Services.AddTransient<IHeadphonesService, HeadphonesService>();


builder.Services.AddTransient<IMonitorService, MonitorService>();
builder.Services.AddTransient<IHousingService, HousingService>();
builder.Services.AddTransient<IMiceService, MiceService>();
builder.Services.AddTransient<IKeyboardService, KeyboardService>();
builder.Services.AddTransient<ILaptopService, LaptopService>();
builder.Services.AddScoped<IS3Interface, S3Service>();


#endregion


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
