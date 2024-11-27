using System.Text.Json;
using Microsoft.AspNetCore.Http;
using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Shared.Exceptions;

internal sealed class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (PackItException e)
        {
            context.Response.StatusCode = 400;
            context.Response.ContentType = "application/json";

            var errorName = e.GetType().Name.Replace("Exception", string.Empty);
            var json = JsonSerializer.Serialize(new { ErrorName = errorName, e.Message });
            await context.Response.WriteAsync(json);
        }
    }
}