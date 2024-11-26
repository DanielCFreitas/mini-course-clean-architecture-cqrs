using PackIt.Application.DTO;
using PackIt.Infrastructure.EF.Models;

namespace PackIt.Infrastructure.Queries;

internal static class Extensions
{
    public static PackingListDto AsDto(this PackingListReadModel readModel)
        => new()
        {
            Id = readModel.Id,
            Name = readModel.Name,
            Localization = new LocalizationDto()
            {
                City = readModel.Localization?.City,
                Country = readModel.Localization?.Country
            },
            Items = readModel.Items?.Select(pi => new PackingItemDto()
            {
              Name  = pi.Name,
              Quantity = pi.Quantity,
              IsPacked = pi.IsPacked,
            })?? new List<PackingItemDto>()
        };
}