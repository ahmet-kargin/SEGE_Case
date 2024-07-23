using Amazon.DynamoDBv2.DataModel;
using SEGE_Case.Services.Stats;

namespace SEGE_Case.Services.Services;

public class HeroService
{
    private readonly IDynamoDBContext _context;

    public HeroService(IDynamoDBContext context)
    {
        _context = context;
    }

    public void CalculateHeroStats(Hero hero)
    {
        var calculator = new HeroStatsCalculator();
        hero.HP = calculator.HeroHP(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception, hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);
        hero.ATK = calculator.HeroATK(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception, hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);
        hero.DEF = calculator.HeroDEF(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception, hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);
        hero.SPD = calculator.HeroSPD(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception, hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);
        hero.CRATE = calculator.HeroCRATE(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception, hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);
        hero.CDMG = calculator.HeroCDMG(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception,
           hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);
        hero.RES = calculator.HeroRES(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception,
            hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);
        hero.ACC = calculator.HeroACC(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception,
            hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);
    }
}
