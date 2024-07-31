
namespace SEGE_Case.WebUI.Models;

public class BattleViewModel
{
    public IEnumerable<HeroViewModel>? Heroes { get; set; }
    public IEnumerable<EnemyViewModel>? Enemies { get; set; }
    public string HeroId { get; set; }
    public string EnemyId { get; set; }
    public int Level { get; set; }
    public int Rarity { get; set; }
    public int StarCount { get; set; }
    public int PinkStarCount { get; set; }
    public int NumberOfRounds { get; set; }
    public BattleResults? BattleResult { get; set; }
}
