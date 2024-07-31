using SEGE_Case.Domain.Entities;

namespace SEGE_Case.Services.Services;

public class BattleSimulator
{
    // Bir savaş simülasyonu yapar ve sonuçları BattleResult nesnesi olarak döner.

    public BattleSimulationResults SimulateBattle(Hero hero, Enemy enemy, int numberOfRounds)
    {
        var result = new BattleSimulationResults
        {
            HeroName = hero.Name,
            EnemyName = enemy.Name
        };

        for (int round = 1; round <= numberOfRounds; round++)
        {
            int heroDamage = CalculateDamage(hero, enemy);
            int enemyDamage = CalculateDamage(enemy, hero);

            result.RoundResults.Add(new RoundResult
            {
                RoundNumber = round,
                HeroDamage = heroDamage,
                EnemyDamage = enemyDamage,
                Status = "Ongoing"
            });

            hero.HP -= enemyDamage;
            enemy.HP -= heroDamage;

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
        return Math.Max(0, hero.ATK - enemy.DEF);
    }

    private int CalculateDamage(Enemy enemy, Hero hero)
    {
        return Math.Max(0, enemy.ATK - hero.DEF);
    }
}

public class BattleSimulationResults
{
    public string HeroName { get; set; }
    public string EnemyName { get; set; }
    public List<RoundResult> RoundResults { get; set; } = new List<RoundResult>();
    public string FinalOutcome { get; set; }
}

public class RoundResult
{
    public int RoundNumber { get; set; }
    public int HeroDamage { get; set; }
    public int EnemyDamage { get; set; }
    public string Status { get; set; }
}
