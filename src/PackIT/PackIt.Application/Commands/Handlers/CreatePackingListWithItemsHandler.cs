using PackIt.Application.Exceptions;
using PackIt.Application.Services;
using PackIt.Domain.Factories;
using PackIt.Domain.Repositories;
using PackIt.Domain.ValueObjects;
using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands.Handlers;

public class CreatePackingListWithItemsHandler : ICommandHandler<CreatePackingListWithItems>
{
    private readonly IPackingListRepository _repository;
    private readonly IPackingListFactory _factory;
    private readonly IPackingListReadService _readService;
    private readonly IWeatherApiService _weatherApiService;

    public CreatePackingListWithItemsHandler(IPackingListRepository repository, IPackingListFactory factory,
        IPackingListReadService readService, IWeatherApiService weatherApiService)
    {
        _repository = repository;
        _factory = factory;
        _readService = readService;
        _weatherApiService = weatherApiService;
    }

    public async Task HandlerAsync(CreatePackingListWithItems command)
    {
        var (id, name, days, gender, localizationWriteModel) = command;

        if (await _readService.ExistsByNameAsync(name))
            throw new PackingListAlreadyExistsException(name);

        var localization = new Localization(localizationWriteModel.City, localizationWriteModel.Country);
        var weather = await _weatherApiService.GetWeatherAsync(localization);

        if (weather is null)
            throw new MissingLocalizationWeatherException(localization);

        var packingList = _factory.CreateWithDefaultItems(id, name, days, gender, weather.Temperature, localization);

        await _repository.AddAsync(packingList);
    }
}