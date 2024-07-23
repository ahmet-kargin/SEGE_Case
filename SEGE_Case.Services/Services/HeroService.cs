using Amazon.DynamoDBv2.DataModel;
using SEGE_Case.Domain.Entities;
using SEGE_Case.Services.Stats;

namespace SEGE_Case.Services.Services;

public class HeroService
{
    // Yapıcı metod: IDynamoDBContext nesnesini alır ve _context alanına atar.
    private readonly IDynamoDBContext _context;
    
    public HeroService(IDynamoDBContext context)
    {
        _context = context;
    }
    // Kahramanın istatistiklerini hesaplar ve kahraman nesnesine atar.
    public void CalculateHeroStats(Hero hero)
    {
        // HeroStatsCalculator sınıfından bir örnek oluşturur.
        var calculator = new HeroStatsCalculator();

        // Kahramanın HP (sağlık puanı) istatistiğini hesaplar.
        hero.HP = calculator.HeroHP(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception, hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);

        // Kahramanın ATK (saldırı gücü) istatistiğini hesaplar.
        hero.ATK = calculator.HeroATK(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception, hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);

        // Kahramanın DEF (savunma gücü) istatistiğini hesaplar.
        hero.DEF = calculator.HeroDEF(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception, hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);

        // Kahramanın SPD (hız) istatistiğini hesaplar.
        hero.SPD = calculator.HeroSPD(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception, hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);

        // Kahramanın CRATE (kritik vuruş oranı) istatistiğini hesaplar.
        hero.CRATE = calculator.HeroCRATE(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception, hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);

        // Kahramanın CDMG (kritik hasar) istatistiğini hesaplar.
        hero.CDMG = calculator.HeroCDMG(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception,
            hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);

        // Kahramanın RES (direnç) istatistiğini hesaplar.
        hero.RES = calculator.HeroRES(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception,
            hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);

        // Kahramanın ACC (doğru vuruş oranı) istatistiğini hesaplar.
        hero.ACC = calculator.HeroACC(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception,
            hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);

        
    }
}
