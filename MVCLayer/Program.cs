using Amazon.Runtime;
using Amazon.S3;
using Application.Helpers;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using DTOS.IdentitiesDTO;
using Infastructure.Data;
using Infastructure.Interfaces;
using Infastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

# region DbContext

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")),
    ServiceLifetime.Scoped);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

#endregion

#region Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Password requirements settings
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<AppDBContext>()
              .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });
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

#region Application Services

builder.Services.AddControllers();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<MousePadsInterface, MousePadsRepository>();
builder.Services.AddTransient<PowerSuppliesInterface, PowerSuppliesRepository>();
builder.Services.AddTransient<RAMInterface, RAMRepository>();
builder.Services.AddTransient<TablesForGamersInterface, TablesForGamersRepository>();


builder.Services.AddTransient<IPowerSuppliesService, PowerSuppliesService>();
builder.Services.AddTransient<IMousePadsService, MousePadsService>();
builder.Services.AddTransient<IRAMService, RAMService>();
builder.Services.AddTransient<IAccessoriesService, AccessoriesService>();
builder.Services.AddTransient<ITablesForGamersService, TablesForGamersService>();
builder.Services.AddScoped<IIdentityService, IdentityService>();


builder.Services.AddTransient<IArmchairsService, ArmchairsService>();
builder.Services.AddTransient<ICoolerService, CoolerService>();
builder.Services.AddTransient<IDrivesService, DrivesService>();
builder.Services.AddTransient<IGamingBuildsService, GamingBuildsService>();
builder.Services.AddTransient<IHeadphonesService, HeadphonesService>();


builder.Services.AddTransient<IMonitorService, MonitorService>();
builder.Services.AddTransient<IHousingService, HousingService>();
builder.Services.AddTransient<IMiceService, MiceService>();
builder.Services.AddTransient<IKeyboardService, KeyboardService>();
builder.Services.AddTransient<ILaptopService, LaptopService>();
builder.Services.AddScoped<IS3Interface, S3Service>();

#endregion


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
