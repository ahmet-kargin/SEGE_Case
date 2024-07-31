using SEGE_Case.Services.Services;

namespace SEGE_Case.WebUI.Models;

public class BattleSimulation
{
    public string HeroName { get; set; }
    public string EnemyName { get; set; }
    public List<Round> RoundResults { get; set; } = new List<Round>();
    public string FinalOutcome { get; set; }
}