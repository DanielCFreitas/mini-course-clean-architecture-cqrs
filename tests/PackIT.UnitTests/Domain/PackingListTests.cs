using System.Diagnostics.Tracing;
using PackIt.Domain.Entities;
using PackIt.Domain.Events;
using PackIt.Domain.Exceptions;
using PackIt.Domain.Factories;
using PackIt.Domain.Policies;
using PackIt.Domain.ValueObjects;
using Shouldly;

namespace PackIT.UnitTests.Domain;

public class PackingListTests
{
    [Fact]
    public void AddItem_Throws_PackingItemAlreadyExistsException_When_There_Is_Already_Item_With_The_Same_Name()
    {
        // Arrange
        var packingList = GetPackingList();
        packingList.AddItem(new PackingItem("Item 1", 1));

        // Act
        var exception = Record.Exception(() => packingList.AddItem(new PackingItem("Item 1", 1)));

        // Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<PackingItemAlreadyExistsException>();
    }

    [Fact]
    public void AddItem_Adds_PackingItemAdded_Domain_Event_On_Success()
    {
        // Arrange
        var packingList = GetPackingList();
        
        // Act
        var exception = Record.Exception(() => packingList.AddItem(new PackingItem("Item 1", 1)));
        
        // Assert
        exception.ShouldBeNull();
        packingList.Events.Count().ShouldBe(1);
        
        var @event = packingList.Events.FirstOrDefault() as PackingItemAdded;
        @event.ShouldNotBeNull();
        @event.PackingItem.Name.ShouldBe("Item 1");
    }

    #region ARRANGE

    private readonly IPackingListFactory _factory;

    public PackingListTests()
    {
        _factory = new PackingListFactory(Enumerable.Empty<IPackingItemsPolicy>());
    }

    private PackingList GetPackingList()
    {
        var packingList = _factory.Create(Guid.NewGuid(), "My List", Localization.Create("Warsaw, Poland"));
        packingList.ClearEvents();
        return packingList;
    }

    #endregion
}