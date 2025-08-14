using Microsoft.AspNetCore.SignalR;

namespace BrowserGames.Hubs;

public class UsernameHub : Hub
{
    private readonly Dictionary<string, string> _connections = [];

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _connections.Remove(Context.ConnectionId);
        return Task.CompletedTask;
    }
    
    public Task Register(string username)
    {
        _connections[username] = Context.ConnectionId;
        return Task.CompletedTask;
    }

}