using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using SEGE_Case.Application.Interfaces;
using SEGE_Case.Infrastructure.Connection;
using SEGE_Case.Infrastructure.Repositories;
using SEGE_Case.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// AWS hizmetlerini container'a ekler.
var awsOptions = builder.Configuration.GetAWSOptions();

// Uygulama ayarlarından AWS seçeneklerini alır.
builder.Services.AddDefaultAWSOptions(awsOptions);

// Amazon DynamoDB hizmetini ekler.
builder.Services.AddAWSService<IAmazonDynamoDB>();

// IDynamoDBContext'i DynamoDBContext uygulamasıyla singleton olarak ekler.
builder.Services.AddSingleton<IDynamoDBContext, DynamoDBContext>();

// IHeroRepository'i HeroRepository uygulamasıyla scoped olarak ekler.
// Scoped: Bu servis, her HTTP isteği için yeni bir örnek oluşturur.
builder.Services.AddScoped<IHeroRepository, HeroRepository>();

// IEnemyRepository'i EnemyRepository uygulamasıyla scoped olarak ekler.
builder.Services.AddScoped<IEnemyRepository, EnemyRepository>();

// BattleSimulator sınıfını scoped olarak ekler.
builder.Services.AddScoped<BattleSimulator>();

// HeroService sınıfını scoped olarak ekler.
builder.Services.AddScoped<HeroService>();

//Scoped gelen her istekte yeni instance oluşturur.
// EnemyService sınıfını scoped olarak ekler.
builder.Services.AddScoped<EnemyService>();

//İlk istekte yeni instance oluşturur hep bunu kullanılır.
builder.Services.AddSingleton<MongoDBHelper>();
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
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
    pattern: "{controller=Home}/{action=SimulateBattle}/{id?}");

app.Run();
