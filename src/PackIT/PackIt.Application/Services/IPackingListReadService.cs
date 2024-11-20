using PackIt.Application.DTO;

namespace PackIt.Application.Services;

public interface IPackingListReadService
{
    Task<bool> ExistsByNameAsync(string name);
}