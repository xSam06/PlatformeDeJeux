namespace PlatformeDeJeux.Models;

public class Morpion
{
    public string[,] Board { get; set; } = new string[3, 3];
    public string CurrentPlayer { get; set; } = "X";
    public bool IsGameOver { get; set; } = false;
    public string Winner { get; set; } = null;

    public string? LobbyId { get; set; }
    public bool MakeMove(int row, int col)
    {
        if (Board[row, col] == null && !IsGameOver)
        {
            Board[row, col] = CurrentPlayer;
            CheckGameStatus();
            CurrentPlayer = CurrentPlayer == "X" ? "O" : "X";
            return true;
        }
        return false;
    }


    private void CheckGameStatus()
    {
        // Vérifie lignes, colonnes, diagonales
        for (int i = 0; i < 3; i++)
        {
            if (Board[i, 0] == CurrentPlayer && Board[i, 1] == CurrentPlayer && Board[i, 2] == CurrentPlayer ||
                Board[0, i] == CurrentPlayer && Board[1, i] == CurrentPlayer && Board[2, i] == CurrentPlayer)
            {
                IsGameOver = true;
                Winner = CurrentPlayer;
                return;
            }
        }

        if (Board[0, 0] == CurrentPlayer && Board[1, 1] == CurrentPlayer && Board[2, 2] == CurrentPlayer ||
            Board[0, 2] == CurrentPlayer && Board[1, 1] == CurrentPlayer && Board[2, 0] == CurrentPlayer)
        {
            IsGameOver = true;
            Winner = CurrentPlayer;
            return;
        }

        // Match nul
        bool isDraw = true;
        foreach (var cell in Board)
        {
            if (cell == null)
            {
                isDraw = false;
                break;
            }
        }

        if (isDraw)
        {
            IsGameOver = true;
            Winner = "Draw";
        }
    }

    public void SwitchPlayer()
    {
        CurrentPlayer = CurrentPlayer == "X" ? "O" : "X";
    }


    public void Reset(){

    
            Board = new string[3,3];
            Winner = null;
            IsGameOver = false;
            CurrentPlayer = CurrentPlayer == "X" ? "O" : "X";


        
    }
}