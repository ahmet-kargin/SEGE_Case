using SEGE_Case.Domain.Entities;

namespace SEGE_Case.WebUI.Models
{
    public class UpdateEntityViewModel
    {
        public bool IsHero { get; set; }
        public Hero Hero { get; set; }
        public Enemy Enemy { get; set; }
    }

}
