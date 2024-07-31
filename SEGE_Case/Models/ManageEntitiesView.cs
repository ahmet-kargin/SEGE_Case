namespace SEGE_Case.WebUI.Models;

public class ManageEntitiesViewModel
{
    public IEnumerable<HeroViewModel> Heroes { get; set; }
    public IEnumerable<EnemyViewModel> Enemies { get; set; }
}
