using Microsoft.Extensions.Logging;
using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Infrastructure.Logging;

internal sealed class LogginCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    where TCommand : class, ICommand
{
    private readonly ICommandHandler<TCommand> _commandHandler;
    private readonly ILogger<LogginCommandHandlerDecorator<TCommand>> _logger;

    public LogginCommandHandlerDecorator(ICommandHandler<TCommand> commandHandler,
        ILogger<LogginCommandHandlerDecorator<TCommand>> logger)
    {
        _commandHandler = commandHandler;
        _logger = logger;
    }

    public async Task HandlerAsync(TCommand command)
    {
        var commandType = command.GetType().Name;

        try
        {
            _logger.LogInformation("Started Proccessing {CommandType} command", commandType);
            await _commandHandler.HandlerAsync(command);
            _logger.LogInformation("Finished Proccessing {CommandType} command", commandType);
        }
        catch (Exception e)
        {
            _logger.LogError("Failed to Proccess {CommandType} command", commandType);
            throw;
        }
    }
}