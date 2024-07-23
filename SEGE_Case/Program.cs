using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using Amazon.DynamoDBv2.DataModel;
using SEGE_Case.Application.Interfaces;
using SEGE_Case.Infrastructure.Repositories;
using SEGE_Case.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add AWS services to the container.
var awsOptions = builder.Configuration.GetAWSOptions();
builder.Services.AddDefaultAWSOptions(awsOptions);
builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddSingleton<IDynamoDBContext, DynamoDBContext>();

builder.Services.AddScoped<IHeroRepository, HeroRepository>();
builder.Services.AddScoped<IEnemyRepository, EnemyRepository>();

builder.Services.AddScoped<BattleSimulator>();
builder.Services.AddScoped<HeroService>();
builder.Services.AddScoped<EnemyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
