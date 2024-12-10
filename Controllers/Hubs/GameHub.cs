using Microsoft.AspNetCore.SignalR;

public class GameHub : Hub
{
    public async Task SendMove(string player, int row, int col)
    {
        // Notifie tous les clients du mouvement
        await Clients.Others.SendAsync("ReceiveMove", player, row, col);
    }
}
