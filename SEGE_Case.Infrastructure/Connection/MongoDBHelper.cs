using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SEGE_Case.Domain.Entities;

namespace SEGE_Case.Infrastructure.Connection;

public class MongoDBHelper
{
    private readonly IMongoDatabase _database;

    // Yapılandırıcı metot, IConfiguration arayüzü üzerinden yapılandırma ayarlarını alır
    public MongoDBHelper(IConfiguration configuration)
    {
        // MongoDB bağlantı dizesi ve veri tabanı adını ayarları
        var connectionString = "mongodb+srv://Sege_Case:Sege_CaseDeneme@sege.qchyfhk.mongodb.net/?retryWrites=true&w=majority&appName=SEGE";
        var databaseName = "Sege_Case";
        

        // Null kontrolü yap
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString), "MongoDB connection string is not configured.");
        }

        if (string.IsNullOrEmpty(databaseName))
        {
            throw new ArgumentNullException(nameof(databaseName), "MongoDB database name is not configured.");
        }

        // MongoDB istemcisini oluştur
        var client = new MongoClient(connectionString);

        // İlgili veri tabanını al
        _database = client.GetDatabase(databaseName);
    }

    // Heroes koleksiyonunu alacak metot
    public IMongoCollection<Hero> GetHeroesCollection()
    {
        return _database.GetCollection<Hero>("Heroes");
    }

    // Enemies koleksiyonunu alacak metot
    public IMongoCollection<Enemy> GetEnemiesCollection()
    {
        return _database.GetCollection<Enemy>("Enemies");
    }

    // BattleResults koleksiyonunu alacak metot
    //public IMongoCollection<BattleResult> GetBattleResultsCollection()
    //{
    //    return _database.GetCollection<BattleResult>("BattleResults");
    //}

}