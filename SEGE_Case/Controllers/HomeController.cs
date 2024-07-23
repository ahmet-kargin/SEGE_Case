using Microsoft.AspNetCore.Mvc;
using SEGE_Case.Domain.Entities;
using SEGE_Case.Services.Services;

namespace SEGE_Case.Controllers;

public class HomeController : Controller
{
    private readonly HeroService _heroService;
    private readonly EnemyService _enemyService;
    private readonly BattleSimulator _battleSimulator;

    public HomeController(HeroService heroService, EnemyService enemyService, BattleSimulator battleSimulator)
    {
        _heroService = heroService;
        _enemyService = enemyService;
        _battleSimulator = battleSimulator;
    }

    public IActionResult Index()
    {
        // Example model setup
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SimulateBattle(Hero hero, Enemy enemy, int numberOfRounds)
    {
        // Hero'nun istatistiklerini hesapla
        _heroService.CalculateHeroStats(hero);

        // Enemy'nin istatistiklerini hesapla ve kaydet
        await _enemyService.SaveEnemyStatsAsync(enemy);

        // Savaşı simüle et
        var result = _battleSimulator.SimulateBattle(hero, enemy, numberOfRounds);

        // Savaş sonucunu view'a döndür
        return View("BattleResult", result);
    }
}
