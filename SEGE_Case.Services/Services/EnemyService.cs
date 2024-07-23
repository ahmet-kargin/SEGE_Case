using Amazon.DynamoDBv2.DataModel;
using SEGE_Case.Domain.Entities;
using SEGE_Case.Services.Stats;

namespace SEGE_Case.Services.Services;

public class EnemyService
{
    private readonly IDynamoDBContext _context;

    public EnemyService(IDynamoDBContext context)
    {
        _context = context;
    }

    public async Task SaveEnemyStatsAsync(Enemy enemy)
    {
        var calculator = new EnemyStatsCalculator();
        enemy.HP = calculator.EnemyHP(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);
        enemy.ATK = calculator.EnemyATK(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);
        enemy.DEF = calculator.EnemyDEF(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);
        enemy.SPD = calculator.EnemySPD(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);
        enemy.CRATE = calculator.EnemyCRATE(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);
        enemy.CDMG = calculator.EnemyCDMG(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);
        enemy.RES = calculator.EnemyRES(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);
        enemy.ACC = calculator.EnemyACC(enemy.Alchemy, enemy.Archery, enemy.Dexterity, enemy.Endurance, enemy.Intelligence, enemy.Luck, enemy.Perception, enemy.Resilience, enemy.Stealth, enemy.Strength, enemy.Wisdom, enemy.Level, enemy.Rarity, enemy.StarCount, enemy.PinkStarCount);

        await _context.SaveAsync(enemy);
    }
}
