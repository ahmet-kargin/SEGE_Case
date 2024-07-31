using MongoDB.Driver;
using SEGE_Case.Infrastructure.Connection;
using SEGE_Case.Services.Stats;

namespace SEGE_Case.Services.Services;

public class HeroService
{
    private readonly IMongoCollection<Hero> _collection;
    private readonly HeroStatsCalculator _calculator;

    public HeroService(MongoDBHelper mongoDBHelper)
    {
        _collection = mongoDBHelper.GetHeroesCollection();
        _calculator = new HeroStatsCalculator();
    }

    public async Task CalculateHeroStatsAsync(string heroId)
    {
        // MongoDB'den belirli bir id ile kahramanı alır.
        var hero = await _collection.Find(h => h.HeroId.ToString() == heroId).FirstOrDefaultAsync();
        if (hero != null)
        {
            // İstatistikleri hesaplar ve günceller.
            hero.HP = _calculator.HeroHP(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception, hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);
            hero.ATK = _calculator.HeroATK(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception, hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);
            hero.DEF = _calculator.HeroDEF(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception, hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);
            hero.SPD = _calculator.HeroSPD(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception, hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);
            hero.CRATE = _calculator.HeroCRATE(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception, hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);
            hero.CDMG = _calculator.HeroCDMG(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception, hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);
            hero.RES = _calculator.HeroRES(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception, hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);
            hero.ACC = _calculator.HeroACC(hero.Alchemy, hero.Archery, hero.Dexterity, hero.Endurance, hero.Intelligence, hero.Luck, hero.Perception, hero.Resilience, hero.Stealth, hero.Strength, hero.Wisdom, hero.Level, hero.Rarity, hero.StarCount, hero.PinkStarCount);

            // Güncellenmiş kahramanı MongoDB'ye kaydeder.
            await _collection.ReplaceOneAsync(h => h.HeroId.ToString() == heroId, hero);
        }
    }

    // Tüm kahramanları döndüren metod
    public async Task<List<Hero>> GetAllHeroesAsync()
    {
        return await  _collection.Find(_ => true).ToListAsync();
    }
}
