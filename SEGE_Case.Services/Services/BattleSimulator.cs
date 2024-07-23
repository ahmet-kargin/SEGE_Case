using SEGE_Case.Domain.Entities;

namespace SEGE_Case.Services.Services;

public class BattleSimulator
{
    // Bir savaş simülasyonu yapar ve sonuçları BattleResult nesnesi olarak döner.
    public BattleResult SimulateBattle(Hero hero, Enemy enemy, int numberOfRounds)
    {
        // Sonuçları tutacak BattleResult nesnesi oluşturulur.
        var result = new BattleResult
        {
            HeroName = hero.Name,  // Kahramanın adı BattleResult'a atanır.
            EnemyName = enemy.Name // Düşmanın adı BattleResult'a atanır.
        };
        // Belirtilen sayıda tur boyunca savaşı simüle eder.
        for (int round = 1; round <= numberOfRounds; round++)
        {
            // Basit bir hasar hesaplama mantığı uygulanır.
            int heroDamage = CalculateDamage(hero, enemy);
            int enemyDamage = CalculateDamage(enemy, hero);

            // Bu turun sonuçları RoundResult listesine eklenir.
            result.RoundResults.Add(new RoundResult
            {
                RoundNumber = round,    // Tur numarası
                HeroDamage = heroDamage,// Kahramanın bu turda verdiği hasar
                EnemyDamage = enemyDamage, // Düşmanın bu turda verdiği hasar
                Status = "Ongoing" // Durum, oyunun devam ettiğini belirtir.
            });

            // Hasarlara göre HP güncellenir.
            hero.HP -= enemyDamage; // Kahramanın HP'si düşman hasarı kadar azalır.
            enemy.HP -= heroDamage; // Düşmanın HP'si kahraman hasarı kadar azalır.


            // Her iki karakterden birinin HP'si sıfır veya daha düşükse, savaşın sonucunu günceller.
            if (hero.HP <= 0)
            {
                result.RoundResults[result.RoundResults.Count - 1].Status = "Hero Defeated";
                break; // Kahraman mağlup olduysa döngüden çıkılır.
            }
            if (enemy.HP <= 0)
            {
                result.RoundResults[result.RoundResults.Count - 1].Status = "Enemy Defeated";
                break; // Düşman mağlup olduysa döngüden çıkılır.
            }
        }

        return result;
    }

    // Kahramanın düşmana verdiği hasarı hesaplar.
    private int CalculateDamage(Hero hero, Enemy enemy)
    {
        // Basit hasar hesaplama: Kahramanın ATK'sinden düşmanın DEF'si çıkarılır, negatif değerler sıfır olarak kabul edilir.
        return Math.Max(0, hero.ATK - enemy.DEF);
    }

    // Düşmanın kahramana verdiği hasarı hesaplar.
    private int CalculateDamage(Enemy enemy, Hero hero)
    {
        // Basit hasar hesaplama: Düşmanın ATK'sinden kahramanın DEF'si çıkarılır, negatif değerler sıfır olarak kabul edilir.
        return Math.Max(0, enemy.ATK - hero.DEF);
    }
}

// Savaş sonucunu temsil eden sınıf.
public class BattleResult
{
    public string HeroName { get; set; }
    public string EnemyName { get; set; }
    public List<RoundResult> RoundResults { get; set; } = new List<RoundResult>();
    public string FinalOutcome { get; set; } // Sonuç: "Hero Defeated", "Enemy Defeated", "Draw"
}

// Her bir turun sonuçlarını temsil eden sınıf.
public class RoundResult
{
    public int RoundNumber { get; set; }
    public int HeroDamage { get; set; }
    public int EnemyDamage { get; set; }
    public int HeroHP { get; set; }
    public int EnemyHP { get; set; }
    public string Status { get; set; } // e.g., "Hero Defeated", "Enemy Defeated", "Ongoing"
}
