using SEGE_Case.Domain.Entities;

namespace SEGE_Case.WebUI.Models;

public class BattleResult
{
    public Hero Hero { get; set; }
    public Enemy Enemy { get; set; }
    public List<BattleRoundResult> Rounds { get; set; }
}
