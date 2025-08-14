using Microsoft.AspNetCore.SignalR;

namespace BrowserGames.Hubs;

public class PretenderHub : Hub
{
    public override Task OnConnectedAsync()
    {
        Console.WriteLine("[PretenderHub] New Connection: " + Context.ConnectionId);
        return Task.CompletedTask;
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine("[PretenderHub] Disconnected: " + Context.ConnectionId);
        return Task.CompletedTask;
    }

    public async Task CreateLobby()
    {
        Console.WriteLine("[PretenderHub] Creating Lobby: " + Context.ConnectionId);
        await Clients.All.SendAsync("LobbyCreated", Guid.NewGuid());
    }
}