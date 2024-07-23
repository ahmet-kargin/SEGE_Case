using SEGE_Case.Domain.Entities;
using SEGE_Case.Infrastructure.Repositories;
using SEGE_Case.Services.Stats;

namespace SEGE_Case.Services.Services;

public class BattleSimulator
{
    public BattleResult SimulateBattle(Hero hero, Enemy enemy, int numberOfRounds)
    {
        var result = new BattleResult
        {
            HeroName = hero.Name,
            EnemyName = enemy.Name
        };

        for (int round = 1; round <= numberOfRounds; round++)
        {
            // Example logic for damage calculation
            int heroDamage = CalculateDamage(hero, enemy);
            int enemyDamage = CalculateDamage(enemy, hero);

            result.RoundResults.Add(new RoundResult
            {
                RoundNumber = round,
                HeroDamage = heroDamage,
                EnemyDamage = enemyDamage,
                Status = "Ongoing" // Update status based on the outcome
            });

            // Update HPs based on damage
            hero.HP -= enemyDamage;
            enemy.HP -= heroDamage;

            // Check if either has been defeated
            if (hero.HP <= 0)
            {
                result.RoundResults[result.RoundResults.Count - 1].Status = "Hero Defeated";
                break;
            }
            if (enemy.HP <= 0)
            {
                result.RoundResults[result.RoundResults.Count - 1].Status = "Enemy Defeated";
                break;
            }
        }

        return result;
    }

    private int CalculateDamage(Hero hero, Enemy enemy)
    {
        // Simplified damage calculation
        return Math.Max(0, hero.ATK - enemy.DEF);
    }

    private int CalculateDamage(Enemy enemy, Hero hero)
    {
        // Simplified damage calculation
        return Math.Max(0, enemy.ATK - hero.DEF);
    }
}

public class BattleResult
{
    public string HeroName { get; set; }
    public string EnemyName { get; set; }
    public List<RoundResult> RoundResults { get; set; } = new List<RoundResult>();
    public string FinalOutcome { get; set; } // Sonuç: "Hero Defeated", "Enemy Defeated", "Draw"
}

public class RoundResult
{
    public int RoundNumber { get; set; }
    public int HeroDamage { get; set; }
    public int EnemyDamage { get; set; }
    public int HeroHP { get; set; }
    public int EnemyHP { get; set; }
    public string Status { get; set; } // e.g., "Hero Defeated", "Enemy Defeated", "Ongoing"
}
