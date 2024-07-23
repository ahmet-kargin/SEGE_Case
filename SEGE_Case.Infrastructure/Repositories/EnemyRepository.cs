using Amazon.DynamoDBv2.DataModel;
using SEGE_Case.Application.Interfaces;
using SEGE_Case.Domain.Entities;

namespace SEGE_Case.Infrastructure.Repositories;

public class EnemyRepository : IEnemyRepository
{
    // DynamoDB bağlamını temsil eden IDynamoDBContext nesnesini tutar.
    private readonly IDynamoDBContext _context;

    // EnemyRepository sınıfının yapıcı metodu, DynamoDB bağlamını alır.
    public EnemyRepository(IDynamoDBContext context)
    {
        _context = context;
    }

    // Belirli bir id ile bir düşmanı asenkron olarak alır.
    public async Task<Enemy> GetEnemyByIdAsync(string id)
    {
        // DynamoDB'den belirli bir id ile düşmanı yükler ve döner.
        return await _context.LoadAsync<Enemy>(id);
    }

    // Bir Enemy nesnesini asenkron olarak kaydeder.
    public async Task SaveEnemyAsync(Enemy enemy)
    {
        // DynamoDB'ye verilen düşmanı kaydeder.
        await _context.SaveAsync(enemy);
    }

    // Belirli bir id ile düşmanı asenkron olarak siler.
    public async Task DeleteEnemyAsync(string id)
    {
        // Silinecek düşmanı id'ye göre alır.
        var enemy = await GetEnemyByIdAsync(id);
        if (enemy != null)
        {
            // Düşmanı DynamoDB'den siler.
            await _context.DeleteAsync(enemy);
        }
    }

    // Tüm düşmanları asenkron olarak alır.
    public async Task<IEnumerable<Enemy>> GetAllEnemiesAsync()
    {
        // DynamoDB'de Enemy tablosundaki tüm verileri tarar.
        var search = _context.ScanAsync<Enemy>(new List<ScanCondition>());

        // Tarama sonuçlarını alır ve döner.
        var results = await search.GetNextSetAsync();
        return results;
    }
}
