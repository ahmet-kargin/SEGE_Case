using SEGE_Case.Domain.Entities;

namespace SEGE_Case.WebUI.Models;

public class BattleResultViewModel
{
    public Hero Hero { get; set; }
    public Enemy Enemy { get; set; }
    public BattleSimulation Result { get; set; } // Simülasyon sonucu
}





