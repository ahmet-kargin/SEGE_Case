using Microsoft.AspNetCore.Mvc;
using SEGE_Case.Domain.Entities;
using SEGE_Case.Models;
using SEGE_Case.Services.Services;
using System.Diagnostics;

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
        _heroService.CalculateHeroStats(hero);
        await _enemyService.SaveEnemyStatsAsync(enemy);

        // Simulate the battle
        var result = _battleSimulator.SimulateBattle(hero, enemy, numberOfRounds);

        // Return the battle result view with the result
        return View("BattleResult", result);
    }
}
