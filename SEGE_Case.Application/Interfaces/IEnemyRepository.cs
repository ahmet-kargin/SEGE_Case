using SEGE_Case.Domain.Entities;

namespace SEGE_Case.Application.Interfaces;

// IEnemyRepository arayüzü, düşman (Enemy) varlıklarıyla ilgili CRUD (Create, Read, Update, Delete) işlemlerini tanımlar.
public interface IEnemyRepository
{
    // Belirtilen kimliğe (id) sahip düşmanı asenkron olarak getirir.
    Task<Enemy> GetEnemyByIdAsync(string id);

    // Verilen düşmanı (enemy) asenkron olarak kaydeder.
    Task SaveEnemyAsync(Enemy enemy);

    // Belirtilen kimliğe (id) sahip düşmanı asenkron olarak siler.
    Task DeleteEnemyAsync(string id);

    // Tüm düşmanları (Enemy) asenkron olarak getirir.
    Task<IEnumerable<Enemy>> GetAllEnemiesAsync();
}

