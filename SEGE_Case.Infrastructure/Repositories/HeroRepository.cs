using Amazon.DynamoDBv2.DataModel;
using SEGE_Case.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGE_Case.Infrastructure.Repositories;

// HeroRepository sınıfı, IHeroRepository arayüzünü implement eder ve Hero nesneleri ile ilgili CRUD işlemlerini gerçekleştirir.
public class HeroRepository : IHeroRepository
{
    // DynamoDB bağlamını temsil eden IDynamoDBContext nesnesini tutar.
    private readonly IDynamoDBContext _context;

    // HeroRepository sınıfının yapıcı metodu, DynamoDB bağlamını alır.
    public HeroRepository(IDynamoDBContext context)
    {
        _context = context;
    }

    // Belirli bir id ile bir kahramanı asenkron olarak alır.
    public async Task<Hero> GetHeroByIdAsync(string id)
    {
        // DynamoDB'den belirli bir id ile kahramanı yükler ve döner.
        return await _context.LoadAsync<Hero>(id);
    }

    // Bir Hero nesnesini asenkron olarak kaydeder.
    public async Task SaveHeroAsync(Hero hero)
    {
        // DynamoDB'ye verilen kahramanı kaydeder.
        await _context.SaveAsync(hero);
    }

    // Belirli bir id ile kahramanı asenkron olarak siler.
    public async Task DeleteHeroAsync(string id)
    {
        // Silinecek kahramanı id'ye göre alır.
        var hero = await GetHeroByIdAsync(id);
        if (hero != null)
        {
            // Kahramanı DynamoDB'den siler.
            await _context.DeleteAsync(hero);
        }
    }

    // Tüm kahramanları asenkron olarak alır.
    public async Task<IEnumerable<Hero>> GetAllHeroesAsync()
    {
        // DynamoDB'de Hero tablosundaki tüm verileri tarar.
        var search = _context.ScanAsync<Hero>(new List<ScanCondition>());

        // Tarama sonuçlarını alır ve döner.
        var results = await search.GetNextSetAsync();
        return results;
    }
}
