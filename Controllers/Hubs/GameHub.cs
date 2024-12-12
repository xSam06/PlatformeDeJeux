using Microsoft.AspNetCore.SignalR;

public class GameHub : Hub
{

    //rejoindre le lobby
   public async Task JoinGame(string gameId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
        await Clients.Group(gameId).SendAsync("PlayerJoined", Context.ConnectionId);
    }

    
    public async Task MakeMove(string gameId, int x, int y, string player)
    {
        await Clients.Group(gameId).SendAsync("MoveMade", x, y, player);
    }

    public async Task SendMessage(string gameId, string message)
    {
        await Clients.Group(gameId).SendAsync("ReceiveMessage", message);
    }
}
