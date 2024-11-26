using Microsoft.EntityFrameworkCore;
using PackIt.Application.Services;
using PackIt.Infrastructure.EF.Contexts;
using PackIt.Infrastructure.EF.Models;

namespace PackIt.Infrastructure.EF.Services;

internal sealed class PostgresPackingListReadService : IPackingListReadService
{
    private readonly DbSet<PackingListReadModel> _packingList;

    public PostgresPackingListReadService(ReadDbContext context)
        => _packingList = context.PackingLists;
    

    public async Task<bool> ExistsByNameAsync(string name)
        => await _packingList.AnyAsync(x => x.Name == name);
}