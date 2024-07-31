using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SEGE_Case.Application.Interfaces;
using SEGE_Case.Domain.Entities;
using SEGE_Case.Services.Services;
using SEGE_Case.WebUI.Models;

public class HomeController : Controller
{
    private readonly HeroService _heroService;
    private readonly IHeroRepository _heroRepository;
    private readonly EnemyService _enemyService;
    private readonly IEnemyRepository _enemyRepository;
    private readonly BattleSimulator _battleSimulator;

    public HomeController(HeroService heroService, EnemyService enemyService, BattleSimulator battleSimulator, IHeroRepository heroRepository, IEnemyRepository enemyRepository)
    {
        _heroService = heroService;
        _enemyService = enemyService;
        _battleSimulator = battleSimulator;
        _heroRepository = heroRepository;
        _enemyRepository = enemyRepository;
    }

    [HttpGet]
    public IActionResult CreateHero()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateHero(HeroViewModel model)
    {
        if (ModelState.IsValid)
        {
            var hero = new Hero
            {
                HeroId = ObjectId.GenerateNewId(),
                Name = model.Name,
                Alchemy = model.Alchemy,
                Archery = model.Archery,
                Dexterity = model.Dexterity,
                Endurance = model.Endurance,
                Intelligence = model.Intelligence,
                Luck = model.Luck,
                Perception = model.Perception,
                Resilience = model.Resilience,
                Stealth = model.Stealth,
                Strength = model.Strength,
                Wisdom = model.Wisdom,
                Level = model.Level,
                Rarity = model.Rarity,
                StarCount = model.StarCount,
                PinkStarCount = model.PinkStarCount
            };
            await _heroRepository.CreateHeroAsync(hero);
            return RedirectToAction("CreateHero");
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult CreateEnemy()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateEnemy(EnemyViewModel model)
    {
        if (ModelState.IsValid)
        {
            var enemy = new Enemy
            {
                EnemyId = ObjectId.GenerateNewId(),
                Name = model.Name,
                Alchemy = model.Alchemy,
                Archery = model.Archery,
                Dexterity = model.Dexterity,
                Endurance = model.Endurance,
                Intelligence = model.Intelligence,
                Luck = model.Luck,
                Perception = model.Perception,
                Resilience = model.Resilience,
                Stealth = model.Stealth,
                Strength = model.Strength,
                Wisdom = model.Wisdom,
                Level = model.Level,
                Rarity = model.Rarity,
                StarCount = model.StarCount,
                PinkStarCount = model.PinkStarCount
            };
            await _enemyRepository.CreateEnemyAsync(enemy);
            return RedirectToAction("CreateEnemy");
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> GetBattleResults(string heroId, string enemyId, int level, int rarity, int starCount, int pinkStarCount, int numberOfRounds)
    {
        var hero = await _heroRepository.GetHeroByIdAsync(heroId);
        var enemy = await _enemyRepository.GetEnemyByIdAsync(enemyId);

        if (hero != null && enemy != null)
        {
            hero.Level = level;
            hero.Rarity = rarity;
            hero.StarCount = starCount;
            hero.PinkStarCount = pinkStarCount;

            await _heroService.CalculateHeroStatsAsync(hero.HeroId.ToString());
            await _enemyService.SaveEnemyStatsAsync(enemy);

            var result = _battleSimulator.SimulateBattle(hero, enemy, numberOfRounds);
            return Json(result); // Simülasyon sonucunu JSON formatında döndür
        }
        return BadRequest("Invalid data");
    }

    [HttpGet]
    public async Task<IActionResult> SimulateBattle()
    {
        var heroes = await _heroRepository.GetAllHeroesAsync();
        var enemies = await _enemyRepository.GetAllEnemiesAsync();

        var heroViewModels = heroes.Select(hero => new HeroViewModel
        {
            Name = hero.Name,
            Alchemy = hero.Alchemy,
            Archery = hero.Archery,
            Dexterity = hero.Dexterity,
            Endurance = hero.Endurance,
            Intelligence = hero.Intelligence,
            Luck = hero.Luck,
            Perception = hero.Perception,
            Resilience = hero.Resilience,
            Stealth = hero.Stealth,
            Strength = hero.Strength,
            Wisdom = hero.Wisdom,
            Level = hero.Level,
            Rarity = hero.Rarity,
            StarCount = hero.StarCount,
            PinkStarCount = hero.PinkStarCount
        }).ToList(); // Listeyi ToList() ile döndürün

        var enemyViewModels = enemies.Select(enemy => new EnemyViewModel
        {
            Name = enemy.Name,
            Alchemy = enemy.Alchemy,
            Archery = enemy.Archery,
            Dexterity = enemy.Dexterity,
            Endurance = enemy.Endurance,
            Intelligence = enemy.Intelligence,
            Luck = enemy.Luck,
            Perception = enemy.Perception,
            Resilience = enemy.Resilience,
            Stealth = enemy.Stealth,
            Strength = enemy.Strength,
            Wisdom = enemy.Wisdom,
            Level = enemy.Level,
            Rarity = enemy.Rarity,
            StarCount = enemy.StarCount,
            PinkStarCount = enemy.PinkStarCount
        }).ToList(); // Listeyi ToList() ile döndürün

        var model = new BattleViewModel
        {
            Heroes = heroViewModels,
            Enemies = enemyViewModels,
            BattleResult = null // Başlangıçta null
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SimulateBattle(BattleViewModel model)
    {
        if (ModelState.IsValid)
        {
            var hero = await _heroRepository.GetHeroByNameAsync(model.HeroId);
            var enemy = await _enemyRepository.GetEnemyByNameAsync(model.EnemyId);

            if (hero == null || enemy == null)
            {
                ModelState.AddModelError("", "Hero or Enemy not found.");
                return View(model);
            }

            hero.Level = model.Level;
            hero.Rarity = model.Rarity;
            hero.StarCount = model.StarCount;
            hero.PinkStarCount = model.PinkStarCount;

            enemy.Level = model.Level;
            enemy.Rarity = model.Rarity;
            enemy.StarCount = model.StarCount;
            enemy.PinkStarCount = model.PinkStarCount;

             await _heroService.CalculateHeroStatsAsync(hero.HeroId.ToString());
            await _enemyService.SaveEnemyStatsAsync(enemy);

            var simulationResult = _battleSimulator.SimulateBattle(hero, enemy, model.NumberOfRounds);
            var battleResults = ConvertToBattleResults(simulationResult);
            var resultModel = new BattleViewModel
            {
                Heroes = (await _heroRepository.GetAllHeroesAsync()).Select(h => new HeroViewModel
                {
                    Name = h.Name,
                    Alchemy = h.Alchemy,
                    Archery = h.Archery,
                    Dexterity = h.Dexterity,
                    Endurance = h.Endurance,
                    Intelligence = h.Intelligence,
                    Luck = h.Luck,
                    Perception = h.Perception,
                    Resilience = h.Resilience,
                    Stealth = h.Stealth,
                    Strength = h.Strength,
                    Wisdom = h.Wisdom,
                    Level = h.Level,
                    Rarity = h.Rarity,
                    StarCount = h.StarCount,
                    PinkStarCount = h.PinkStarCount
                }),
                Enemies = (await _enemyRepository.GetAllEnemiesAsync()).Select(e => new EnemyViewModel
                {
                    Name = e.Name,
                    Alchemy = e.Alchemy,
                    Archery = e.Archery,
                    Dexterity = e.Dexterity,
                    Endurance = e.Endurance,
                    Intelligence = e.Intelligence,
                    Luck = e.Luck,
                    Perception = e.Perception,
                    Resilience = e.Resilience,
                    Stealth = e.Stealth,
                    Strength = e.Strength,
                    Wisdom = e.Wisdom,
                    Level = e.Level,
                    Rarity = e.Rarity,
                    StarCount = e.StarCount,
                    PinkStarCount = e.PinkStarCount
                }),
                HeroId = model.HeroId,
                EnemyId = model.EnemyId,
                Level = model.Level,
                Rarity = model.Rarity,
                StarCount = model.StarCount,
                PinkStarCount = model.PinkStarCount,
                NumberOfRounds = model.NumberOfRounds,
                BattleResult = battleResults // Directly assign the simulation result
            };

            return View("BattleResult", resultModel);
        }

        model.Heroes = (await _heroRepository.GetAllHeroesAsync()).Select(h => new HeroViewModel
        {
            Name = h.Name,
            Alchemy = h.Alchemy,
            Archery = h.Archery,
            Dexterity = h.Dexterity,
            Endurance = h.Endurance,
            Intelligence = h.Intelligence,
            Luck = h.Luck,
            Perception = h.Perception,
            Resilience = h.Resilience,
            Stealth = h.Stealth,
            Strength = h.Strength,
            Wisdom = h.Wisdom,
            Level = h.Level,
            Rarity = h.Rarity,
            StarCount = h.StarCount,
            PinkStarCount = h.PinkStarCount
        });
        model.Enemies = (await _enemyRepository.GetAllEnemiesAsync()).Select(e => new EnemyViewModel
        {
            Name = e.Name,
            Alchemy = e.Alchemy,
            Archery = e.Archery,
            Dexterity = e.Dexterity,
            Endurance = e.Endurance,
            Intelligence = e.Intelligence,
            Luck = e.Luck,
            Perception = e.Perception,
            Resilience = e.Resilience,
            Stealth = e.Stealth,
            Strength = e.Strength,
            Wisdom = e.Wisdom,
            Level = e.Level,
            Rarity = e.Rarity,
            StarCount = e.StarCount,
            PinkStarCount = e.PinkStarCount
        });
        return View(model);
    }


    private BattleResults ConvertToBattleResults(BattleSimulationResults simulationResult)
    {
        return new BattleResults
        {
            HeroId = simulationResult.HeroName, 
            EnemyId = simulationResult.EnemyName, 
            RoundResults = simulationResult.RoundResults.Select(rr => new Round
            {
                RoundNumber = rr.RoundNumber,
                HeroDamage = rr.HeroDamage,
                EnemyDamage = rr.EnemyDamage,
                Status = rr.Status
            }),
            FinalOutcome = simulationResult.FinalOutcome
        };
    }

    [HttpGet]
    public async Task<IActionResult> ManageEntities()
    {
        var heroes = await _heroRepository.GetAllHeroesAsync();
        var enemies = await _enemyRepository.GetAllEnemiesAsync();

        var model = new ManageEntitiesViewModel
        {
            Heroes = heroes.Select(hero => new HeroViewModel
            {
                Name = hero.Name,
                Alchemy = hero.Alchemy,
                Archery = hero.Archery,
                Dexterity = hero.Dexterity,
                Endurance = hero.Endurance,
                Intelligence = hero.Intelligence,
                Luck = hero.Luck,
                Perception = hero.Perception,
                Resilience = hero.Resilience,
                Stealth = hero.Stealth,
                Strength = hero.Strength,
                Wisdom = hero.Wisdom,
                Level = hero.Level,
                Rarity = hero.Rarity,
                StarCount = hero.StarCount,
                PinkStarCount = hero.PinkStarCount
            }).ToList(),
            Enemies = enemies.Select(enemy => new EnemyViewModel
            {
                Name = enemy.Name,
                Alchemy = enemy.Alchemy,
                Archery = enemy.Archery,
                Dexterity = enemy.Dexterity,
                Endurance = enemy.Endurance,
                Intelligence = enemy.Intelligence,
                Luck = enemy.Luck,
                Perception = enemy.Perception,
                Resilience = enemy.Resilience,
                Stealth = enemy.Stealth,
                Strength = enemy.Strength,
                Wisdom = enemy.Wisdom,
                Level = enemy.Level,
                Rarity = enemy.Rarity,
                StarCount = enemy.StarCount,
                PinkStarCount = enemy.PinkStarCount
            }).ToList()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateHero(HeroViewModel model)
    {
        if (ModelState.IsValid)
        {
            var hero = new Hero
            {
                Name = model.Name,
                Alchemy = model.Alchemy,
                Archery = model.Archery,
                Dexterity = model.Dexterity,
                Endurance = model.Endurance,
                Intelligence = model.Intelligence,
                Luck = model.Luck,
                Perception = model.Perception,
                Resilience = model.Resilience,
                Stealth = model.Stealth,
                Strength = model.Strength,
                Wisdom = model.Wisdom,
                Level = model.Level,
                Rarity = model.Rarity,
                StarCount = model.StarCount,
                PinkStarCount = model.PinkStarCount
            };

            await _heroRepository.SaveHeroAsync(hero);
        }

        return RedirectToAction("ManageEntities");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteHero(HeroViewModel model)
    {
        if (string.IsNullOrEmpty(model.Name))
        {
            return BadRequest("Hero name is required.");
        }

        await _heroRepository.DeleteHeroAsync(model.Name);
        return RedirectToAction("ManageEntities");
    }

    [HttpPost]
    public async Task<IActionResult> UpdateEnemy(EnemyViewModel model)
    {
        if (ModelState.IsValid)
        {
            var enemy = new Enemy
            {
                Name = model.Name,
                Alchemy = model.Alchemy,
                Archery = model.Archery,
                Dexterity = model.Dexterity,
                Endurance = model.Endurance,
                Intelligence = model.Intelligence,
                Luck = model.Luck,
                Perception = model.Perception,
                Resilience = model.Resilience,
                Stealth = model.Stealth,
                Strength = model.Strength,
                Wisdom = model.Wisdom,
                Level = model.Level,
                Rarity = model.Rarity,
                StarCount = model.StarCount,
                PinkStarCount = model.PinkStarCount
            };

            await _enemyRepository.SaveEnemyAsync(enemy);
        }

        return RedirectToAction("ManageEntities");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteEnemy(EnemyViewModel model)
    {
        if (string.IsNullOrEmpty(model.Name))
        {
            return BadRequest("Enemy name is required.");
        }

        await _enemyRepository.DeleteEnemyAsync(model.Name);
        return RedirectToAction("ManageEntities");
    }
}
