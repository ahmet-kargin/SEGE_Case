namespace SEGE_Case.Application.Interfaces;

// IHeroRepository arayüzü, kahraman (Hero) varlıklarıyla ilgili CRUD (Create, Read, Update, Delete) işlemlerini tanımlar.
public interface IHeroRepository
{
    // Belirtilen kimliğe (id) sahip kahramanı asenkron olarak getirir.
    Task<Hero> GetHeroByIdAsync(string id);

    // Verilen kahramanı (hero) asenkron olarak kaydeder.
    Task SaveHeroAsync(Hero hero);

    // Belirtilen kimliğe (id) sahip kahramanı asenkron olarak siler.
    Task DeleteHeroAsync(string id);

    // Tüm kahramanları (Hero) asenkron olarak getirir.
    Task<IEnumerable<Hero>> GetAllHeroesAsync();
}
