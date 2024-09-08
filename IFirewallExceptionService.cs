using System.Threading.Tasks;
using firewall_e.Models;

public interface IFirewallExceptionService
{
    Task SaveExceptionAsync(FirewallExceptionModel exception);
}