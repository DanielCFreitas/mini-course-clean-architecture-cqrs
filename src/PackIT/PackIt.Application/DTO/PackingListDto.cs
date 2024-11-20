using PackIt.Domain.ValueObjects;

namespace PackIt.Application.DTO;

public class PackingListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Localization localization { get; set; }
    public IEnumerable<PackingItemDto> Items { get; set; }
}