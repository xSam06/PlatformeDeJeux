using Microsoft.AspNetCore.Mvc;
using PlatformeDeJeux.Models;
using System.Linq;

public class LobbyController : Controller
{
    private readonly LobbyManager _lobbyManager;

    public LobbyController(LobbyManager lobbyManager)
    {
        _lobbyManager = lobbyManager;
    }

    public IActionResult Index()
    {
        var lobbies = _lobbyManager.Lobbies.Where(l => !l.IsFull).ToList();
        return View(lobbies);
    }

    [HttpPost]
    public IActionResult CreateLobby(string gameType)
    {
        var lobby = _lobbyManager.CreateLobby();
        return RedirectToAction("JoinLobby", new { lobbyId = lobby.Id });
    }

    public IActionResult JoinLobby(string lobbyId, string playerName)
    {
        var lobby = _lobbyManager.GetLobby(lobbyId);
        if (lobby == null) return NotFound();

        lobby.AddPlayer(playerName);
        if (lobby.IsFull)
        {
            // Redirige vers le jeu après remplissage du lobby
            return RedirectToAction("StartGame", new { lobbyId = lobby.Id });
        }

        return View(lobby);
    }

    public IActionResult StartGame(string lobbyId)
    {
        var lobby = _lobbyManager.GetLobby(lobbyId);
        if (lobby == null) return NotFound();

        // Redirige vers le contrôleur correspondant au jeu
        return RedirectToAction("Index", "Morpion");
        
    }
}
