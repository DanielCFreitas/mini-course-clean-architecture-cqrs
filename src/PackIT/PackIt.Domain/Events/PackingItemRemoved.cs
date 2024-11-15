using PackIt.Domain.Entities;
using PackIt.Domain.ValueObjects;
using PackIt.Shared.Abstractions.Domain;

namespace PackIt.Domain.Events;

public class PackingItemRemoved(PackingList PackingList, PackingItem PackingItem) : IDomainEvent;