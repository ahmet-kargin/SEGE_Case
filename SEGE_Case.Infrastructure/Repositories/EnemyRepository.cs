using Amazon.DynamoDBv2.DataModel;
using MongoDB.Driver;
using SEGE_Case.Application.Interfaces;
using SEGE_Case.Domain.Entities;
using SEGE_Case.Infrastructure.Connection;

namespace SEGE_Case.Infrastructure.Repositories;

public class EnemyRepository : IEnemyRepository
{
    private readonly IMongoCollection<Enemy> _collection;

    public EnemyRepository(MongoDBHelper mongoDBHelper)
    {
        _collection = mongoDBHelper.GetEnemiesCollection();
    }

    public async Task<Enemy> GetEnemyByIdAsync(string id)
    {
        // MongoDB'den belirli bir id ile düşmanı alır.
        return await _collection.Find(e => e.EnemyId.ToString() == id).FirstOrDefaultAsync();
    }

    public async Task<Enemy> GetEnemyByNameAsync(string name)
    {
        // MongoDB'den belirli bir id ile düşmanı alır.
        return await _collection.Find(e => e.Name.ToString() == name).FirstOrDefaultAsync();
    }

    public async Task SaveEnemyAsync(Enemy enemy)
    {
        // MongoDB'ye düşmanı kaydeder.
        await _collection.ReplaceOneAsync(e => e.EnemyId == enemy.EnemyId, enemy, new ReplaceOptions { IsUpsert = true });
    }

    public async Task DeleteEnemyAsync(string id)
    {
        // MongoDB'den belirli bir id ile düşmanı siler.
        await _collection.DeleteOneAsync(e => e.Name.ToString() == id);
    }


    public async Task<IEnumerable<Enemy>> GetAllEnemiesAsync()
    {
        // MongoDB'deki tüm düşmanları alır.
        return await _collection.Find(_ => true).ToListAsync();
    }
    // MongoDB'ye düşmanı ekler.
    public async Task CreateEnemyAsync(Enemy enemy)
    {
        await _collection.InsertOneAsync(enemy);
    }

    public async Task UpdateEnemyAsync(Enemy enemy)
    {
        // MongoDB'de belirli bir id ile düşmanı günceller.
        var filter = Builders<Enemy>.Filter.Eq(e => e.EnemyId, enemy.EnemyId);
        var update = Builders<Enemy>.Update
            .Set(e => e.Name, enemy.Name)
            .Set(e => e.Alchemy, enemy.Alchemy)
            .Set(e => e.Archery, enemy.Archery)
            .Set(e => e.Dexterity, enemy.Dexterity)
            .Set(e => e.Endurance, enemy.Endurance)
            .Set(e => e.Intelligence, enemy.Intelligence)
            .Set(e => e.Luck, enemy.Luck)
            .Set(e => e.Perception, enemy.Perception)
            .Set(e => e.Resilience, enemy.Resilience)
            .Set(e => e.Stealth, enemy.Stealth)
            .Set(e => e.Strength, enemy.Strength)
            .Set(e => e.Wisdom, enemy.Wisdom)
            .Set(e => e.Level, enemy.Level)
            .Set(e => e.Rarity, enemy.Rarity)
            .Set(e => e.StarCount, enemy.StarCount)
            .Set(e => e.PinkStarCount, enemy.PinkStarCount);

        await _collection.UpdateOneAsync(filter, update);
    }
}
