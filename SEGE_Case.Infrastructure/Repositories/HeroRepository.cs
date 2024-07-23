using Amazon.DynamoDBv2.DataModel;
using SEGE_Case.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGE_Case.Infrastructure.Repositories;

public class HeroRepository : IHeroRepository
{
    private readonly IDynamoDBContext _context;

    public HeroRepository(IDynamoDBContext context)
    {
        _context = context;
    }

    public async Task<Hero> GetHeroByIdAsync(string id)
    {
        return await _context.LoadAsync<Hero>(id);
    }

    public async Task SaveHeroAsync(Hero hero)
    {
        await _context.SaveAsync(hero);
    }

    public async Task DeleteHeroAsync(string id)
    {
        var hero = await GetHeroByIdAsync(id);
        if (hero != null)
        {
            await _context.DeleteAsync(hero);
        }
    }

    public async Task<IEnumerable<Hero>> GetAllHeroesAsync()
    {
        var search = _context.ScanAsync<Hero>(new List<ScanCondition>());
        var results = await search.GetNextSetAsync();
        return results;
    }
}
