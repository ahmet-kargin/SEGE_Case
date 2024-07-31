using Amazon.DynamoDBv2.DataModel;
using MongoDB.Driver;
using SEGE_Case.Domain.Entities;
using SEGE_Case.Infrastructure.Connection;
using SEGE_Case.Services.Stats;

namespace SEGE_Case.Services.Services;

public class EnemyService
{
    private readonly IMongoCollection<Enemy> _collection;
    private readonly EnemyStatsCalculator _calculator;

    public EnemyService(MongoDBHelper mongoDBHelper)
    {
        _collection = mongoDBHelper.GetEnemiesCollection();
        _calculator = new EnemyStatsCalculator();
    }

    public async Task SaveEnemyStatsAsync(Enemy enemy)
    {
        // Düşmanın HP (sağlık puanı) istatistiğini hesaplar.
        enemy.HP = _calculator.EnemyHP(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);

        // Düşmanın ATK (saldırı gücü) istatistiğini hesaplar.
        enemy.ATK = _calculator.EnemyATK(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);

        // Düşmanın DEF (savunma gücü) istatistiğini hesaplar.
        enemy.DEF = _calculator.EnemyDEF(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);

        // Düşmanın SPD (hız) istatistiğini hesaplar.
        enemy.SPD = _calculator.EnemySPD(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);

        // Düşmanın CRATE (kritik vuruş oranı) istatistiğini hesaplar.
        enemy.CRATE = _calculator.EnemyCRATE(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);

        // Düşmanın CDMG (kritik hasar) istatistiğini hesaplar.
        enemy.CDMG = _calculator.EnemyCDMG(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);

        // Düşmanın RES (direnç) istatistiğini hesaplar.
        enemy.RES = _calculator.EnemyRES(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);

        // Düşmanın ACC (doğru vuruş oranı) istatistiğini hesaplar.
        enemy.ACC = _calculator.EnemyACC(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);

        // Hesaplanan düşman istatistiklerini MongoDB'ye asenkron olarak kaydeder.
        await _collection.ReplaceOneAsync(
            filter: Builders<Enemy>.Filter.Eq(e => e.EnemyId, enemy.EnemyId),
            replacement: enemy,
            options: new ReplaceOptions { IsUpsert = true } // Eğer kayıt bulunamazsa yeni bir kayıt ekler.
        );
    }

    // Tüm düşmanları döndüren metod
    public async Task<List<Enemy>> GetAllEnemiesAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }
}
