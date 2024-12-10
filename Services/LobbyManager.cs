using System.Collections.Generic;
using System.Linq;
using PlatformeDeJeux.Models;

public class LobbyManager
{
    public List<Lobby> Lobbies { get; private set; } = new List<Lobby>();

    public Lobby CreateLobby()
    {
        var lobby = new Lobby();
        Lobbies.Add(lobby);
        return lobby;
    }

    public Lobby GetLobby(string lobbyId)
    {
        return Lobbies.FirstOrDefault(l => l.Id == lobbyId);
    }

    public void RemoveLobby(string lobbyId)
    {
        var lobby = GetLobby(lobbyId);
        if (lobby != null)
        {
            Lobbies.Remove(lobby);
        }
    }
}
