namespace PlatformeDeJeux.Models;
using System.Collections.Generic;

public class Lobby
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string GameType { get; set; } 
    public List<string> Players { get; set; } = new List<string>();
    public bool IsFull => Players.Count == 2;

    public void AddPlayer(string playerName)
    {
        if (!IsFull)
        {
            Players.Add(playerName);
        }
    }
}
