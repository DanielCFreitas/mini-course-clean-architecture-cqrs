using Microsoft.EntityFrameworkCore;
using PackIt.Application.DTO;
using PackIt.Application.Queries;
using PackIt.Infrastructure.EF.Contexts;
using PackIt.Infrastructure.EF.Models;
using PackIt.Shared.Abstractions.Queries;

namespace PackIt.Infrastructure.Queries.Handlers;

internal sealed class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
{
    private readonly DbSet<PackingListReadModel> _packingLists;

    public GetPackingListHandler(ReadDbContext context)
        => _packingLists = context.PackingLists;

    public async Task<PackingListDto> HandleAsync(GetPackingList query)
        => await _packingLists
            .Include(pl => pl.Items)
            .Where(pl => pl.Id == query.Id)
            .Select(pl => pl.AsDto())
            .AsNoTracking()
            .SingleAsync();
}