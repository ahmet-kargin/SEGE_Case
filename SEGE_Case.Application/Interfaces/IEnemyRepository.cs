using SEGE_Case.Domain.Entities;

namespace SEGE_Case.Application.Interfaces;

public interface IEnemyRepository
{
    Task<Enemy> GetEnemyByIdAsync(string id);
    Task SaveEnemyAsync(Enemy enemy);
    Task DeleteEnemyAsync(string id);
    Task<IEnumerable<Enemy>> GetAllEnemiesAsync();

}
