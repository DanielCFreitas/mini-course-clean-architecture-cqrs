using Microsoft.EntityFrameworkCore;
using PackIt.Domain.Entities;
using PackIt.Domain.Repositories;
using PackIt.Domain.ValueObjects;
using PackIt.Infrastructure.EF.Contexts;

namespace PackIt.Infrastructure.EF.Repositories;

internal sealed class PostgresPackintListRepository : IPackingListRepository
{
    private readonly DbSet<PackingList> _packingLists;
    private readonly WriteDbContext _writeDbContext;

    public PostgresPackintListRepository(WriteDbContext writeDbContext)
    {
        _packingLists = writeDbContext.PackingLists;
        _writeDbContext = writeDbContext;
    }

    public async Task<PackingList> GetAsync(PackingListId id)
        => await _packingLists.Include("_items")
            .SingleAsync(pl => pl.Id == id);

    public async Task AddAsync(PackingList packingList)
    {
        await _packingLists.AddAsync(packingList);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(PackingList packingList)
    {
        _packingLists.Update(packingList);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(PackingList packingList)
    {
        _packingLists.Remove(packingList);
        await _writeDbContext.SaveChangesAsync();
    }
}