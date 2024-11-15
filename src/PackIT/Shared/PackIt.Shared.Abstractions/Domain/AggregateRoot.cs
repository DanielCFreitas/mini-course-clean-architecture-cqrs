namespace PackIt.Shared.Abstractions.Domain;

public abstract class AggregateRoot<T>
{
    public T Id { get; protected set; }
    public int Version { get; protected set; }
    public IEnumerable<IDomainEvent> Events => _events;

    private readonly List<IDomainEvent> _events = [];
    private bool _versionIncremented;

    protected void AddEvent(IDomainEvent @event)
    {
        if (!_events.Any() && !_versionIncremented)
        {
            Version++;
            _versionIncremented = true;
            _events.Add(@event);
        }
    }

    public void Clear() => _events.Clear();
    
    protected void IncremeentVersion()
    {
        if (_versionIncremented) return;
        
        Version++;
        _versionIncremented = true;
    }
}