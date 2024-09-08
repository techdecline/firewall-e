using firewall_e.Models;

public class FirewallExceptionService : IFirewallExceptionService
{
    private readonly List<FirewallExceptionModel> _exceptions = new();

    public Task SaveExceptionAsync(FirewallExceptionModel exception)
    {
        _exceptions.Add(exception);
        // In a real application, you would persist this to a database
        return Task.CompletedTask;
    }

    public Task<List<FirewallExceptionModel>> GetExceptionsAsync()
    {
        return Task.FromResult(_exceptions.ToList());
    }

    public Task DeleteExceptionAsync(FirewallExceptionModel exception)
    {
        _exceptions.Remove(exception);
        // In a real application, you would delete this from a database
        return Task.CompletedTask;
    }
}