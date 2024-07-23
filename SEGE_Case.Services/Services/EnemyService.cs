using Amazon.DynamoDBv2.DataModel;
using SEGE_Case.Domain.Entities;
using SEGE_Case.Services.Stats;

namespace SEGE_Case.Services.Services;

public class EnemyService
{
    private readonly IDynamoDBContext _context;
    // Yapıcı metod: IDynamoDBContext nesnesini alır ve _context alanına atar.
    public EnemyService(IDynamoDBContext context)
    {
        _context = context;
    }
    // Düşman istatistiklerini hesaplar ve veritabanına kaydeder.
    public async Task SaveEnemyStatsAsync(Enemy enemy)
    {
        // EnemyStatsCalculator sınıfından bir örnek oluşturur.
        var calculator = new EnemyStatsCalculator();

        // Düşmanın HP (sağlık puanı) istatistiğini hesaplar.
        enemy.HP = calculator.EnemyHP(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);

        // Düşmanın ATK (saldırı gücü) istatistiğini hesaplar.
        enemy.ATK = calculator.EnemyATK(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);

        // Düşmanın DEF (savunma gücü) istatistiğini hesaplar.
        enemy.DEF = calculator.EnemyDEF(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);

        // Düşmanın SPD (hız) istatistiğini hesaplar.
        enemy.SPD = calculator.EnemySPD(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);

        // Düşmanın CRATE (kritik vuruş oranı) istatistiğini hesaplar.
        enemy.CRATE = calculator.EnemyCRATE(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);

        // Düşmanın CDMG (kritik hasar) istatistiğini hesaplar.
        enemy.CDMG = calculator.EnemyCDMG(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);

        // Düşmanın RES (direnç) istatistiğini hesaplar.
        enemy.RES = calculator.EnemyRES(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);

        // Düşmanın ACC (doğru vuruş oranı) istatistiğini hesaplar.
        enemy.ACC = calculator.EnemyACC(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);



        // Hesaplanan düşman istatistiklerini veritabanına asenkron olarak kaydeder.
        await _context.SaveAsync(enemy);
    }
}
