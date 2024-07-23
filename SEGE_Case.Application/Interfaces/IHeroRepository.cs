namespace SEGE_Case.Application.Interfaces;

public interface IHeroRepository
{
    Task<Hero> GetHeroByIdAsync(string id);
    Task SaveHeroAsync(Hero hero);
    Task DeleteHeroAsync(string id);
    Task<IEnumerable<Hero>> GetAllHeroesAsync();
}
