using Amazon.DynamoDBv2.DataModel;
using SEGE_Case.Application.Interfaces;
using SEGE_Case.Domain.Entities;

namespace SEGE_Case.Infrastructure.Repositories;

public class EnemyRepository : IEnemyRepository
{
    private readonly IDynamoDBContext _context;

    public EnemyRepository(IDynamoDBContext context)
    {
        _context = context;
    }

    public async Task<Enemy> GetEnemyByIdAsync(string id)
    {
        return await _context.LoadAsync<Enemy>(id);
    }

    public async Task SaveEnemyAsync(Enemy enemy)
    {
        await _context.SaveAsync(enemy);
    }

    public async Task DeleteEnemyAsync(string id)
    {
        var enemy = await GetEnemyByIdAsync(id);
        if (enemy != null)
        {
            await _context.DeleteAsync(enemy);
        }
    }

    public async Task<IEnumerable<Enemy>> GetAllEnemiesAsync()
    {
        var search = _context.ScanAsync<Enemy>(new List<ScanCondition>());
        var results = await search.GetNextSetAsync();
        return results;
    }
}
