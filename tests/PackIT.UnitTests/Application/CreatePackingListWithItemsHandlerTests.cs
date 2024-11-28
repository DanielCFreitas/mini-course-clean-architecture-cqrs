using NSubstitute;
using PackIt.Application.Commands;
using PackIt.Application.Commands.Handlers;
using PackIt.Application.DTO.External;
using PackIt.Application.Exceptions;
using PackIt.Application.Services;
using PackIt.Domain.Consts;
using PackIt.Domain.Entities;
using PackIt.Domain.Factories;
using PackIt.Domain.Repositories;
using PackIt.Domain.ValueObjects;
using PackIt.Shared.Abstractions.Commands;
using Shouldly;

namespace PackIT.UnitTests.Application;

public class CreatePackingListWithItemsHandlerTests
{
    Task Act(CreatePackingListWithItems command)
        => _commandHandler.HandlerAsync(command);

    [Fact]
    public async Task HandleAsync_Throws_PackingListAlreadyExistsException_When_List_With_Same_Name_Already_Exists()
    {
        var commmand = new CreatePackingListWithItems(Guid.NewGuid(), "MyList", 10, Gender.Female, default!);
        _packingListReadService.ExistsByNameAsync(commmand.Name).Returns(true);

        var exception = await Record.ExceptionAsync(() => Act(commmand));
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<PackingListAlreadyExistsException>();
    }

    [Fact]
    public async Task HandleAsync_Throws_MissingLocalizationWeatherException_When_Weather_Is_Not_Returned_From_Service()
    {
        var commmand = new CreatePackingListWithItems(Guid.NewGuid(), "MyList", 10, Gender.Female,
            new LocalizationWriteModel("Warsam", "Poland"));
        _packingListReadService.ExistsByNameAsync(commmand.Name).Returns(false);
        _weatherApiService.GetWeatherAsync(Arg.Any<Localization>())!.Returns(default(WeatherDto));

        var exception = await Record.ExceptionAsync(() => Act(commmand));
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<MissingLocalizationWeatherException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_Repository_On_Success()
    {
        var commmand = new CreatePackingListWithItems(Guid.NewGuid(), "MyList", 10, Gender.Female,
            new LocalizationWriteModel("Warsam", "Poland"));
        _packingListReadService.ExistsByNameAsync(commmand.Name)
            .Returns(false);
        _weatherApiService.GetWeatherAsync(Arg.Any<Localization>())!
            .Returns(new WeatherDto(12));
        _packingListFactory.CreateWithDefaultItems(commmand.Id, commmand.Name, commmand.Days, commmand.Gender,
            Arg.Any<Temperature>(), Arg.Any<Localization>())
            .Returns(default(PackingList));
        
        var exception = await Record.ExceptionAsync(() => Act(commmand));
        exception.ShouldBeNull();
        await _repository.Received(1).AddAsync(Arg.Any<PackingList>());
    }

    #region ARRANGE

    private readonly ICommandHandler<CreatePackingListWithItems> _commandHandler;
    private readonly IPackingListRepository _repository;
    private readonly IWeatherApiService _weatherApiService;
    private readonly IPackingListReadService _packingListReadService;
    private readonly IPackingListFactory _packingListFactory;

    public CreatePackingListWithItemsHandlerTests()
    {
        _repository = Substitute.For<IPackingListRepository>();
        _weatherApiService = Substitute.For<IWeatherApiService>();
        _packingListReadService = Substitute.For<IPackingListReadService>();
        _packingListFactory = Substitute.For<IPackingListFactory>();

        _commandHandler = new CreatePackingListWithItemsHandler(_repository, _packingListFactory,
            _packingListReadService, _weatherApiService);
    }

    #endregion
}