namespace PlatformeDeJeux.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PlatformeDeJeux.Models;



public class MorpionController : Controller
{

  private static Morpion _game = new Morpion();
  private readonly LobbyManager _lobbyManager;

    public IActionResult Index()
    {
        return View(_game);
    }

    public IActionResult CreateLobby()
    {
        var lobbyId = _lobbyManager.CreateLobby();
        return RedirectToAction("Play", new { id = lobbyId });    }

     public IActionResult Play(string id)
    {
        var lobby = _lobbyManager.GetLobby(id);
        if (lobby == null)
        {
            return NotFound("Lobby non trouvé.");
        }

        return View(lobby);
    }


    [HttpPost]
    public IActionResult PlayMove(int row, int col)
    {
        _game.MakeMove(row, col);
        return RedirectToAction("Index");
    }

     [HttpPost]
    public IActionResult Replay()
    {
        _game.Reset();
        return RedirectToAction("Index");
    }


}