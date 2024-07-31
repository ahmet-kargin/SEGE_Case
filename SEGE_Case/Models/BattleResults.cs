using SEGE_Case.Domain.Entities;

namespace SEGE_Case.WebUI.Models;

public class BattleResults
{
    public string HeroId { get; set; }
    public string EnemyId { get; set; }
    public IEnumerable<Round> RoundResults { get; set; }
    public string FinalOutcome { get; set; }
}
