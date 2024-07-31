using Amazon.DynamoDBv2.DataModel;
using MongoDB.Driver;
using SEGE_Case.Application.Interfaces;
using SEGE_Case.Domain.Entities;
using SEGE_Case.Infrastructure.Connection;

namespace SEGE_Case.Infrastructure.Repositories;

// HeroRepository sınıfı, IHeroRepository arayüzünü implement eder ve Hero nesneleri ile ilgili CRUD işlemlerini gerçekleştirir.
public class HeroRepository : IHeroRepository
{
    private readonly IMongoCollection<Hero> _collection;

    public HeroRepository(MongoDBHelper mongoDBHelper)
    {
        _collection = mongoDBHelper.GetHeroesCollection();
    }

    public async Task<Hero> GetHeroByIdAsync(string id)
    {
        // MongoDB'den belirli bir id ile kahramanı alır.
        return await _collection.Find(h => h.HeroId.ToString() == id).FirstOrDefaultAsync();
    }

    public async Task<Hero> GetHeroByNameAsync(string name)
    {
        // MongoDB'den belirli bir id ile kahramanı alır.
        return await _collection.Find(h => h.Name.ToString() == name).FirstOrDefaultAsync();
    }

    public async Task SaveHeroAsync(Hero hero)
    {
        // MongoDB'ye verilen kahramanı kaydeder.
        await _collection.ReplaceOneAsync(h => h.HeroId == hero.HeroId, hero, new ReplaceOptions { IsUpsert = true });
    }

    public async Task DeleteHeroAsync(string id)
    {
        // MongoDB'den belirli bir Name ile kahramanı siler.
        await _collection.DeleteOneAsync(h => h.Name.ToString() == id);
    }

    public async Task<IEnumerable<Hero>> GetAllHeroesAsync()
    {
        // MongoDB'deki tüm kahramanları alır.
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task CreateHeroAsync(Hero hero)
    {
        await _collection.InsertOneAsync(hero);
    }
    public async Task UpdateHeroAsync(Hero hero)
    {
        // MongoDB'de belirli bir id ile kahramanı günceller.
        var filter = Builders<Hero>.Filter.Eq(h => h.HeroId, hero.HeroId);
        var update = Builders<Hero>.Update
            .Set(h => h.Name, hero.Name)
            .Set(h => h.Alchemy, hero.Alchemy)
            .Set(h => h.Archery, hero.Archery)
            .Set(h => h.Dexterity, hero.Dexterity)
            .Set(h => h.Endurance, hero.Endurance)
            .Set(h => h.Intelligence, hero.Intelligence)
            .Set(h => h.Luck, hero.Luck)
            .Set(h => h.Perception, hero.Perception)
            .Set(h => h.Resilience, hero.Resilience)
            .Set(h => h.Stealth, hero.Stealth)
            .Set(h => h.Strength, hero.Strength)
            .Set(h => h.Wisdom, hero.Wisdom)
            .Set(h => h.Level, hero.Level)
            .Set(h => h.Rarity, hero.Rarity)
            .Set(h => h.StarCount, hero.StarCount)
            .Set(h => h.PinkStarCount, hero.PinkStarCount);

        await _collection.UpdateOneAsync(filter, update);
    }
}
